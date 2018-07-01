using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RazorPagesCV.Models
{
    public class RazorPagesCVContext : DbContext
    {
        public RazorPagesCVContext (DbContextOptions<RazorPagesCVContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesCV.Models.CuriculumVitae> CuriculumVitae { get; set; }
    }
}
