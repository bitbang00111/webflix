namespace DevOpsDemo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    [Table("Movie")]
    public partial class Movie
    {
        public Movie()
        {
            Rating = new HashSet<Rating>();
            Actor = new HashSet<Actor>();
        }

        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(500)]
        public string ImgUrl { get; set; }

        public int Year { get; set; }

        [StringLength(500)]
        public string TrailerUrl { get; set; }

        public int? DirectorID { get; set; }

        public virtual Director Director { get; set; }

        public virtual ICollection<Rating> Rating { get; set; }

        public virtual ICollection<Actor> Actor { get; set; }
    }
}
