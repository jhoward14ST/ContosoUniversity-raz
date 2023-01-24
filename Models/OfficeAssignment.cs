using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
// howarj9 - raz5
namespace ContosoUniversity.Models
{
    public class OfficeAssignment
    {
        // The [Key] attribute is used to identify a property as the primary key when the
        // property name is something other than classNameID or ID
        // EF Core can't automatically recognize InstructorID as the PK of OfficeAssignment
        // because InstructorID doesn't follow the ID or classnameID naming convention
        [Key]
        public int InstructorID { get; set; }
        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }
}