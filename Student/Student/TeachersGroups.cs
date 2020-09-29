namespace Student
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TeachersGroups
    {
        public int Id { get; set; }

        public int? IdTeacher { get; set; }

        public int? IdGroup { get; set; }

        public int? IdSubject { get; set; }

        public virtual Groups Groups { get; set; }

        public virtual Subject Subject { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}
