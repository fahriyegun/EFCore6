using DBFirst.DAL;

DbContextInitializer.Build();

//aşağıdaki kullanım default ctor kullanımına örnektir.
//onconfiguring metodundan otomatik sqlservera erişir.
// parametreli ctor kullansaydık şu şekilde kullanacaktık. options'ı parametre olarak dışardan verecektir.
//using (var _context = new AppDbContext(DbContextInitializer.OptionsBuilder.Options))
//bu options da dbcontextinitializer classında yarattığımız options
using (var context = new AppDbContext())
{
    var products = context.Products.ToList();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id}:{p.Name} - {p.Price} tl - {p.Stock} adet");
    });

}