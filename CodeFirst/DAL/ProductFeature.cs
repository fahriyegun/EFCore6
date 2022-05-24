using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.DAL
{
    public class ProductFeature
    {
        [ForeignKey("Product")]
        public int Id { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Color { get; set; }
        public Product Product { get; set; } //navigation property

    }
}
