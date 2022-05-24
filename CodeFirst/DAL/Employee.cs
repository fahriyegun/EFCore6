using Microsoft.EntityFrameworkCore;

namespace CodeFirst.DAL
{
    public class Employee : Person
    {
        [Precision(18,2)]
        public decimal Salary { get; set; }
    }
}
