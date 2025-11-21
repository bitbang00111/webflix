namespace DevOpsDemo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Actor")]
    public partial class Actor
    {
        public Actor()
        {
            Movie = new HashSet<Movie>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        public virtual ICollection<Movie> Movie { get; set; }
    }
}
