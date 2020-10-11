using System;
using System.ComponentModel.DataAnnotations;

namespace DevOpsDemo.Web.ViewModels
{
    public partial class DirectorViewModel
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        public DateTime? Birthdate { get; set; }

        //public virtual ICollection<Movie> Movie { get; set; }
    }
}
