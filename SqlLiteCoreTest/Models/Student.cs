using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SqlLiteCoreTest.Models
{

    [Table("students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }


    /*
     * 

    CREATE TABLE `student` (
      `ID` int(10) UNSIGNED NOT NULL,
      `LastName` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
      `FirstMidName` varchar(50) COLLATE utf8_czech_ci DEFAULT NULL,
      `EnrollmentDate` date DEFAULT NULL
    ) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_czech_ci;

    --
    -- Klíče pro exportované tabulky
    --

    --
    -- Klíče pro tabulku `Student`
    --
    ALTER TABLE `Student`
      ADD PRIMARY KEY (`ID`);

    --
    -- AUTO_INCREMENT pro tabulky
    --

    --
    -- AUTO_INCREMENT pro tabulku `Student`
    --
    ALTER TABLE `Student`
      MODIFY `ID` int(10) UNSIGNED NOT NULL AUTO_INCREMENT;
    COMMIT;

    */

    public enum Grade
    {
        A, B, C, D, F
    }

    [Table("enrollments")]
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }
    }

    [Table("courses")]
    public class Course
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
