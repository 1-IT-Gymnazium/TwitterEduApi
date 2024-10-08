using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterEdu.Data.Entities;

namespace TwitterEdu.Data;

public class AppDbContext : DbContext
{
    public DbSet<Post> Posts { get; set; }

    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
}
