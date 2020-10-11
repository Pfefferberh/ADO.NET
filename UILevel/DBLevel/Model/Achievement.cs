namespace DBLevel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Achievement")]
    public partial class Achievement
    {
        public int Id { get; set; }

        public int? IdStudent { get; set; }

        public int? IdSubject { get; set; }

        public int? Mark { get; set; }

        public virtual Student Student { get; set; }

        public virtual Subject Subject { get; set; }
    }
}
