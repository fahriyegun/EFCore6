# EFCore6

# Yaklaşımlar:
1.	Db First
2.	Code First


# Migration:
1.	add-migration {{migrationname}}
2.	update-database
3.	remove-migration
4.	script-migration


# DBContext:
•	Metotları
1. Add/AddSync
2. Update
3. Remove
4. Find/FindAsync
5. SaveChanges/SaveChangesAsync

•	State Types : _context.Entry(p).State;
1. Added
2. Modified
3. Deleted
4. Unchanged : ilk kez çekilen veya savechanges sonrası ilk kez gelen bir kaydın statüsüdür.
5. Detached : track edilmeyen veya silinmiş artık db de olmayan bir kaydın statüsüdür.

•	Properties:
1. ChangeTracker : memoryde track edilen datalara erişmemizi sağlar. _context.ChangeTracker.Entries().ToList();
2. ContextId (Logging) : her bir dbcontext e verdiği id dir.
3. Database (connection, command, transaction, raw sql) : veritabanı ile ilgili genel işlemlerde bu propertyi kullanırız.


# DBSET<>
•	Metotları:
1. Add/AddSync
2. Update
3. Remove
4. AsNoTracking : sqlden gelen datanın track edilmemesini sağlar, memory de tutulmaz, propertyleri değişmicekse kullanılır.
5. Find /FindAsync : priary key ile aramada kullanılır.
6. FirstOrDefault  : arana kriterlerde bir yada birden fazla data varsa ilkini döner yoksa null döner.
7. SingleOrDefault : aranan kriterde birden fazla kayıt varsa hata fırlatır. yada hiç kayıt yoksa null döner. aranan kriterde tek bir data varsa onu döner.
8. First : şartı sağlayan bir tane kayıt varsa döner, yoksa hata fırlatır.
9. Single : şartı sağlayan bir tane kayıt varsa döner, yoksa yada birden fazla varsa hata fırlatır.
10. Where 

# Relations:
1.	One-to-many
2.	One-to-one
3.	Many-to-many


# Delete Behaviors
* Cascade : default gelen davranıştır. Category silinirse, bağlı olan productlardan tablodan silinir.
* Restrict: eğer categorye bağlı productlar varsa categorynin silinmesini engeller.
* SetNull : child tablosunda foreignkey nullable ise yani product tablosundaki categoryid nullable ise, category tablosundan silinen bir kayıt olursa onun bağlı olduğu productların categoryid sini null olarak set eder.
* NoAction : hiçbir şeye karışmaz.


# Related Data Load:
1.	Eager Loading : Include(), ThenInclude()
2.	Explicit Loading: Collection().Load(), Reference().Load()
3.	Lazy Loading : Microsoft.EntityFrameworkCore.Proxies ve  UseLazyLoadingProxies()


# Inheritence:
1.	TPH: table-per-hierarchy
* Base class, dbcontext classında hiç belirtilmez ve child classlar base classtan miras alarak ayrı ayrı tabloları db de oluşur, ama base classın oluşmaz.
* Base class da db context classında belirtilir. Bu durumda db de tek bir tablo olıuşur. Base classın adında bir tablo oluşur ve onu miras alan tablolardaki diğer propertyler de burada oluşur. Ek olarak da ef core discriminator diye bir kolon oluşturur ve hangi entityden geldiğini tutar.
2. TPT : table-per-type
* Base class ve tüm childlar da db de oluşsun istiyorsak burada OnModelCreating metotunda kod yazmamız gerek.

# Model:
1.	Owned Entity Types: [Owned] / OwnsOne()
2.	Keyless Entity Types: [Keyless] / HasNoKey()

# Entity Properties:
* [NotMapped] /Ignore()
* [Column(“Name”)]: [Column(TypeName=”nvarchar(200)”)] / hascolumnName(“name”).hasColumnType(“varchar(200)”)
* [Unicode(false)] : varchar / Isunicode(false); 

# Indexes:
* Normal Index  : [Index(“”)] /  HasIndex(x)
* Composed Index: [Index(“”,””)] /  HasIndex(x,y)
* Included Column : HasIndex().IncludeProperties()
* Check Constraint:  HasCheckConstraint()

# Raw Sql
* FromSqlRaw()
* FromSqlInterpolated()
* toSqlQuer()
* ToView()

# Pagination: Take() & Skip()

# Projections:
* Entity
* DTO/View Model
* Anonymous Type
