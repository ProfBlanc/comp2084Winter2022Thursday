namespace comp2084Winter2022Thursday.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Semester
    {
        public int SemesterID { get; set; }

        [Required(ErrorMessage = "Term field needed!")]
        [StringLength(10)]
        [MinLength(4, ErrorMessage = "Needs to be at least 4 chars!")]
        [MaxLength(8, ErrorMessage = "No more than 8 characters")]
        [DataType(DataType.Text)]
        [Display(Name = "Semester Term")]
        public string Term { get; set; }


        [Required]
        [Range(1990, 2050)]
        [Display(Name = "Semester Year")]
        public decimal Year { get; set; }
        
               
        public int CourseID { get; set; }

        public int ProfID { get; set; }

        public int StudentID { get; set; }

        public virtual Course Cours { get; set; }

        public virtual Prof Prof { get; set; }

        public virtual Student Student { get; set; }
    }
}
