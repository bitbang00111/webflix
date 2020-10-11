using System;
using System.ComponentModel.DataAnnotations;

namespace DevOpsDemo.Web.ViewModels
{
    public partial class RatingViewModel
    {
        public int ID { get; set; }

        public int Star { get; set; }

        public DateTime? ChangeDate { get; set; }

        public int MovieID { get; set; }

        //public virtual Movie Movie { get; set; }
    }
}
