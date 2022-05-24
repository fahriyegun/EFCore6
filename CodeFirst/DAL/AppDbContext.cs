using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CodeFirst.DAL
{
    public class AppDbContext: DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        //mapping model with function return table value
        //public IQueryable<PersonDetail> GetPersonDetails(int personId)
        //{
        //    return FromExpression(() => GetPersonDetails(personId));
        //}

        ////mapping scalar value with function return scalar value
        //public int GetPersonCount(int id)
        //{
        //    throw new NotSupportedException("bu metodu direkt kullanamazsınız");
        //}

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }
        //public DbSet<Student> Students { get; set; }
        //public DbSet<Teacher> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();

            //lazy loading
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information)
            //    .UseLazyLoadingProxies()
            //    .UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));

            optionsBuilder.UseSqlServer(Initializer.Configuration.GetConnectionString("SqlCon"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //fluent api kodları buraya yazılıyor.

            //TPT
            //modelBuilder.Entity<{classname}>().ToTable("{tablename}");
            //modelBuilder.Entity<Person>().ToTable("Persons");
            //modelBuilder.Entity<Manager>().ToTable("Managers");
            //modelBuilder.Entity<Employee>().ToTable("Employees");

            //function 
            //return table
            //modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetPersonDetails), new[] { typeof(int) })!)
            //    .HasName("fc_personDetails");

            ////return scalar value
            //modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(GetPersonCount), new[] { typeof(int) })!)
            //.HasName("fc_personDetailsWithId");

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
