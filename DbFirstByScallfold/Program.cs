using DbFirstByScallfold.Models;

using (var context = new EFCoreDBFirstContext())
{
    var products = context.Products.ToList();

    products.ForEach(p =>
    {
        Console.WriteLine($"{p.Id}:{p.Name} - {p.Price} tl - {p.Stock} adet");
    });
}