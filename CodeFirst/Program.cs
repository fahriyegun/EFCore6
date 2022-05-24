using CodeFirst;
using CodeFirst.DAL;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

Initializer.Build();

using (var context = new AppDbContext())
{
    ////ONE-TO_MANY DATA ADDING EXAMPLE
    //var category = new Category() { Name = "Kalem" };
    //var product1 = new Product()
    //{
    //    Name = "dolma kalem",
    //    Price = 3,
    //    Stock = 200,
    //    Barcode = 123,
    //    Category = category
    //};

    //context.Products.Add(product1);

    ////ONE-TO-ONE DATA ADDING EXAMPLE
    ////Product => Parent
    ////Child => ParentFeature

    //var product2 = new Product()
    //{
    //    Name = "kurşun kalem",
    //    Price = 3,
    //    Stock = 200,
    //    Barcode = 123,
    //    Category = category,
    //    ProductFeature = new ProductFeature()
    //    {
    //        Color = "Red",
    //        Height = 4,
    //        Width = 4
    //    }
    //};

    //context.Products.Add(product2);

    ////MANY-TO-MANY DATA ADDING EXAMPLE
    //var student = new Student() { Name = "Ahmet", Age = 19 };

    //student.Teachers.Add(new() { Name = "fatma öğretmen" });
    //student.Teachers.Add(new() { Name = "ali öğretmen" });

    //context.Add(student);
    //context.SaveChanges();

    ////EAGER LOADING
    ////--------------------------------------------------------------------------
    ////Include ile Category'nin product ile ilişkilerini çekeriz.
    //var categoryWithProducts = context.Categories.Include(x=>x.Products).ThenInclude(x=>x.ProductFeature).First();


    ////EXPLICIT LOADING
    ////--------------------------------------------------------------------------
    ////şimdi sadece category bilgisini çekeriz. ona bağlı ilişkileri çekmeyiz.
    //var _category = context.Categories.First();
    ////sonra iş kural gereği yada performans sorunu yaratmaması için ilerde uygun bir case'de ilişkilerini çekmek için şöyle yaparız.
    ////category'nin n tane product ilişkisi olabilir diye Collection kullanırız.
    //context.Entry(_category).Collection(x=>x.Products).Load();

    //var _product = context.Products.First();
    ////productın 1 tane productfeature'u olduğu için Reference metotu kullanılır.
    //context.Entry(_product).Reference(x=>x.ProductFeature).Load();


    ////LAZY LOADING
    ////--------------------------------------------------------------------------
    //var _category2 = context.Categories.First();
    //var _products2 = _category2.Products;
    //foreach(var item in _products2)
    //{
    //    var productFeature = item.ProductFeature;
    //}

    //TPH
    //#1
    //context.Managers.Add(new Manager() { Name="m1",Surname="m2", Age=25, Grade=1});
    //context.Employees.Add(new Employee() { Name = "e1", Surname = "e2", Age = 20, Salary = 1000 });

    //var managers = context.Managers.ToList();
    //var employees = context.Employees.ToList();
    ////#2
    //context.Persons.Add(new Manager() { Name = "m1", Surname = "m2", Age = 25, Grade = 1 });
    //context.Employees.Add(new Employee() { Name = "e1", Surname = "e2", Age = 20, Salary = 1000 });

    //SP
    ////get sp
    //var persons = context.Persons.FromSqlRaw("exec sp_get_persons").ToList();

    ////insert sp
    //var person = new Person
    //{
    //    Name = "ali",
    //    Surname = "veli",
    //    Age = 25
    //};

    //var newPersonIdParam = new SqlParameter(@"newId", System.Data.SqlDbType.Int);
    //newPersonIdParam.Direction = System.Data.ParameterDirection.Output;
    //    context.Database.ExecuteSqlInterpolated($"exec sp_insert_person {person.Name},{person.Surname}, {person.Age}, {newPersonIdParam} out");

    //var newPersonId = newPersonIdParam.Value;

    ////Function
    //table 
    //var person2 = context.GetPersonDetails(1).ToList();

    //scalar
    //var count = context.GetPersonCount(1); //hata fırlatır.

    //context.Persons.Select(x => new
    //{
    //    Name = x.Name,
    //    PersonCount = context.GetPersonCount(x.Id)
    //}); // doğru yolu

    
    context.SaveChanges();
}

//pagination
List<Person> getProducts(int page, int pageSize){
    using (var context = new AppDbContext())
    {
        //page:1, pageSize:3 => ilk 3 data => Skip:0, Take:3 => Skip=(page-1)*pageSize => (1-1)*3 = 0*3
        //page:2, pageSize:3 => ikinci 3 data => Skip:1, Take:3 => Skip=(page-1)*pageSize => (2-1)*3 = 1*3
        //page:3, pageSize:3 => üçüncü 3 data => Skip:2, Take:3 => Skip=(page-1)*pageSize => (3-1)*3 = 2*3
        return context.Persons.OrderByDescending(x => x.Id).Skip((page-1)*pageSize).Take(pageSize).ToList();
    }
}