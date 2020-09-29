using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Student
{
    class UniversityContext:DbContext       
    {
        public UniversityContext():base("name=connectionString")
        { }
        public virtual  DbSet<Student> Students { get; set; }
        public virtual  DbSet<Department> Departments { get; set; }
        public virtual  DbSet<Achievement> Achievements { get; set; }
        public virtual  DbSet<Groups> Groups { get; set; }
        public virtual  DbSet<Subject> Subjects { get; set; }
        public virtual  DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<TeachersGroups> TeachersGroups { get; set; }
    }
}
