using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ContosoUniversity.Data;
namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<SchoolContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext") ?? throw new InvalidOperationException("Connection string 'SchoolContext' not found.")));

            // Add services to the container.
            builder.Services.AddRazorPages();

            // howarj9 - raz1
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // howarj9 - raz1
            else
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            // The EnsureCreated method takes no action if a database for the context exists. If no database exists,
            // it creates the database and schema. EnsureCreated enables the following workflow for handling data model changes:
            // * Delete the database. Any existing data is lost
            // * Change the data model. For example, add an EmailAddress field
            // * Run the app
            // * EnsureCreated creates a database with a new schema
            using (var scope = app.Services.CreateScope()) 
            {
                var services = scope.ServiceProvider;

                var context = services.GetRequiredService<SchoolContext>();
                context.Database.EnsureCreated();
                // howarj9 - raz1
                DbInitializer.Initialize(context);
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}