namespace DevOpsDemo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Rating")]
    public partial class Rating
    {
        public int ID { get; set; }

        public int Star { get; set; }

        public DateTime? ChangeDate { get; set; }

        public int MovieID { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
