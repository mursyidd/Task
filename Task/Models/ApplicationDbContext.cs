using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Task.Models
{
    public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public Microsoft.EntityFrameworkCore.DbSet<SESSION_A_APPL_DTL_TBL> SESSION_A_APPL_DTL_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SESSION_B_EMPL_DTL_TBL> SESSION_B_EMPL_DTL_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SESSION_C_QUAL_DTL_TBL> SESSION_C_QUAL_DTL_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SESSION_D_PAST_EMPL_DTL_TBL> SESSION_D_PAST_EMPL_DTL_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<SESSION_E_DOC_DTL_TBL> SESSION_E_DOC_DTL_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<REF_SESSION_F_TBL> REF_SESSION_F_TBL { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<MST_APPLICATION_TBL> MST_APPLICATION_TBL { get; set; }
    }

}
