using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DevOpsDemo.Web.ViewModels
{
    public partial class MovieViewModel
    {
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

        public string DirectorName { get; set; }
        public int? DirectorID { get; set; }

        public int Rating { get; set; }

        public List<ActorViewModel> Actors { get; set; }
    }
}
