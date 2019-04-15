using DAL.FineDesignCupcakes.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.FineDesignCupcakes
{
    public class FDCDatabaseContext : DbContext
        {
            public FDCDatabaseContext(DbContextOptions<FDCDatabaseContext> options)
                : base(options)
            { }

            public DbSet<Flavors> Flavors { get; set; }
            public DbSet<Frostings> Frostings { get; set; }
            public DbSet<Toppings> Toppings { get; set; }

    }
    
}
