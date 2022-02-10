namespace comp2084Winter2022Thursday.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Courses")]
    public partial class Course
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Course()
        {
            Semesters = new HashSet<Semester>();
        }

        [Key]
        public int CourseID { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name ="Course Code")]
        public string CourseCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Course Name")]
        public string CourseName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Semester> Semesters { get; set; }
    }
}
