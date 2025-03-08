using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<Person> People { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_A_TBL> REF_SESSION_A_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_B_TBL> REF_SESSION_B_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_C_TBL> REF_SESSION_C_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_D_TBL> REF_SESSION_D_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_E_TBL> REF_SESSION_E_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_F_TBL> REF_SESSION_F_TBL { get; set; }
    }

}
