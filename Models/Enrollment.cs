// howarj9 - raz5
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
    // howarj9 - raz1
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        // howarj9 - raz5
        [DisplayFormat(NullDisplayText = "No grade")]
        public Grade? Grade { get; set; }
        // There's a many-to-many relationship between the Student and Course entities
        // The Enrollment entity functions as a many-to-many join table with payload in the 
        // database. With payload means that the Enrollment table contains additional data 
        // besides FKs for the joined tables.
        public Course Course { get; set; }
        public Student Student { get; set; }
    }
}