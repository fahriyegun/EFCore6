using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBFirst.DAL
{    
    public class DbContextInitializer
    {
        public static IConfigurationRoot Configuration; //appsettings.json dosyasını okumak için oluşturduk
        public static DbContextOptionsBuilder<AppDbContext> OptionsBuilder; //db ile ilgili optionsları belirtiriz

        public static void Build()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional:true, reloadOnChange:true);

            Configuration = builder.Build();
           // OptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
           //OptionsBuilder.UseSqlServer(Configuration.GetConnectionString("SqlCon"));
        }
    }
}
