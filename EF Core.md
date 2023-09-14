# EF Core 7.0 with Code First

## 1. Introduction
### What is Entity Framework?
### Why use Entity Framework?
### Compare EF Core & EF6
<br>

## 2. Getting Started
### How do I use?
### EF Core NuGet Packages
### First EF Core App
<br>

## 3. Entity Framework Core: DbContext
### Initialization
### Configuration
<br>

## 4. Saving & Querying Data
### Saving Data
### Basic Queriyng
### Change Tracking
<br>

## 5. Code First & Migrations
### Overview
### Managing Migrations
### Applying Migrations
### Scaffolding (Reverse Engineering)
<br>

<br>


<br>

## 1. Introduction to Entity Framework Core (EF Core)

### What is Entity Framework?
Entity Framework Core (EF Core) is an open-source, lightweight, and cross-platform Object-Relational Mapping (ORM) framework developed by Microsoft. It enables developers to work with databases using .NET objects.

`ORM Framework`: EF Core is an ORM framework, which means it bridges the gap between your application's object-oriented code and the relational database. It allows you to interact with your database using C# or other .NET languages, rather than writing raw SQL queries.

`Database Providers`: EF Core supports multiple database providers, such as SQL Server, MySQL, PostgreSQL, SQLite, and more. This flexibility allows you to work with different database systems using the same codebase.

`LINQ Integration`: EF Core seamlessly integrates with Language Integrated Query (LINQ), which allows you to write database queries using C# syntax. This makes querying and manipulating data more intuitive and type-safe.

`Dependency Injection`: EF Core can be easily integrated into applications using dependency injection, making it a natural choice for building web applications.

`Community and Support`: As an open-source project, EF Core has a vibrant community and receives regular updates and improvements from Microsoft. This ensures ongoing support and enhancements.

### Why use Entity Framework?
The Entity Framework enables developers to work with data in the form of domain-specific objects and properties, such as customers and customer addresses, without having to concern themselves with the underlying database tables and columns where this data is stored. 

`Abstraction of Database Logic`: EF abstracts the low-level database interactions, allowing developers to focus more on business logic and less on database-specific code. It eliminates the need to write complex SQL queries manually.

`Object-Relational Mapping (ORM)`: EF provides a powerful ORM framework, which means you work with .NET objects that directly map to database tables. This simplifies data access and manipulation, as you can use familiar object-oriented programming techniques.

`Cross-Database Compatibility`: EF supports various database providers, so you can switch between different databases (SQL Server, MySQL, PostgreSQL, SQLite, etc.) without rewriting your data access code.

`LINQ Integration`: You can use LINQ (Language Integrated Query) with EF, making it easy to write expressive and type-safe queries in C# or VB.NET. This improves code readability and reduces the risk of runtime errors.

`Code-First Development`: With EF Code-First, you can define your data model in code using classes and attributes. EF then generates the database schema based on your model. This approach is developer-friendly and promotes better code maintainability.

`Database Migrations`: EF Core includes a migration system that helps you manage changes to your database schema over time. You can create, update, and rollback migrations with ease, ensuring your database schema matches your code.

### Compare EF Core & EF6
#### Entity Framework Core
New versions of Entity Framework Core are shipped at the same time as new .NET versions. Entity Framework Core is the only actively developed version of Entity Framework and Microsoft recommends using it for all new code.

#### Entity Framework 6
Entity Framework 6 (EF6) is an object-relational mapper designed for .NET Framework but with support for .NET Core. EF6 is a stable, supported product, but is no longer being actively developed.

#### Compare
1. `Platform and Cross-Compatibility`:
* EF Core: EF Core is cross-platform and can run on Windows, macOS, and Linux. It's designed to be lightweight and can be used in various environments.
* EF6: EF6 is primarily designed for Windows and .NET Framework. It doesn't have the same level of cross-platform support as EF Core.

2. `.NET Ecosystem Compatibility`:
* EF Core: EF Core is designed to work with the newer .NET Core and .NET 5+ platforms. It's a good choice for modern .NET applications.
* EF6: EF6 is designed to work with the .NET Framework, which is an older technology. It's suitable for applications running on .NET Framework 4.x.

3. `Code-First Approach`: 
* EF Core: EF Core has a more advanced and flexible Code-First approach. It allows for more granular control over database schema generation and migrations.
* EF6: EF6 also supports the Code-First approach but with some limitations compared to EF Core.

4. `Database Providers`:
* EF Core: EF Core supports a broader range of database providers, including SQL Server, MySQL, PostgreSQL, Azure Cosmos DB, SQLite, In-memory and more.
* EF6: EF6 supports fewer database providers compared to EF Core.

5. `Performance and Features`:
* EF Core: EF Core is designed to be more efficient and performant, especially in terms of query execution. It includes features like query compilation and improved SQL generation.
* EF6: While EF6 is still performant, EF Core has made significant optimizations and improvements in this regard.

6. `LINQ Improvements`:
* EF Core: EF Core has better support for LINQ, with improvements in query translation and type-safety. (eg. Include with filter)
* EF6: EF6 also supports LINQ, but EF Core has made advancements in this area.

7. `Dependency Injection`:
* EF Core: EF Core is well-integrated with dependency injection, making it easy to use in ASP.NET Core applications.
* EF6: EF6 can be used with dependency injection, but it may require additional configuration in non-Core ASP.NET applications.

8. `Community and Support`:
* EF Core: EF Core is actively developed and has a growing community. It receives updates and improvements from Microsoft.
* EF6: EF6 is a stable, supported product, but is no longer being actively developed.

In summary, EF Core is a more modern and flexible ORM framework that's suitable for cross-platform and modern .NET applications, while EF6 is a well-established choice for Windows-based .NET Framework applications. The choice between them depends on your specific project requirements and the platform you are targeting.

`Workflows`:
* EF Core: There are no workflows (teyit etmeli)

* EF6:

![image](https://github.com/iBener/projets/assets/5037744/fd6dc730-219f-4500-807f-f1caea6d99e0)

## 2. Getting Started

### How do I use?
> Install-Package

### EF Core NuGet Packages
> Package

## 3. EF Core: DbContext
### Initialization
#### Entity Class
"Entity" typically means a table in the database. Sometimes it is used to refer to a row in a table.

#### DbSet<>
"DbSet" property represents the collection of entities (records) in a database, it's used to query the database and performs CRUD operations.

> Tip: A `DbSet` property represents a Repository pattern.


### Configuration
#### What is DbContext for?

> Tip: A `DbContext` instance represents a Unit Of Work and Repository patterns.


### Snapshot file
A model snapshot is a representation of the current state of the model that is used to detect changes made to the model during development and update the database schema accordingly.

> Tip: Never delete migration file manually. If you do `Add-Migration` will not add new migration file.

### How to configure?

`OnConfigure`: This method can be used to specify which provider will be used for the context, and what’s the connection string for the context. However, specify the provider and connection string for the context in Program.cs during dependency injection is a more popular option.

`OnModelCreating`: this method is used to configure the model that will be used by the context to create the database schema. In this method, entity types and their relationships are configured and mapped to database tables and columns. In the 

`FluentAPI`: It is used to specify entity types, their properties, relationships, and other mapping options in `OnModelCreating` method.

`Annotations`: Data annotations

`Relationships & Navigational Properties`:

`Separate Configuration Classes`:  Proper way of configuring entites (best practice) is using dedicated configuration class that implements `IEntityTypeConfiguration<Entity>` interface.

```c#
public class BlogEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder
            .Property(b => b.Url)
            .IsRequired();
    }
}
```

```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.ApplyConfiguration(new BlogEntityTypeConfiguration());
    base.OnModelCreating(modelBuilder);
}
```

> Tip: Aşağıdaki yöntemle assembly'de bulunan tüm konfigurasyonları tek seferde uygulayabilirsin.

```c#
modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogEntityTypeConfiguration).Assembly);
```

`Seeding Data`: Data seeding is done in `OnModelCreating` by using FluentAPI's `HasData` method.

```c#
modelBuilder.Entity<Student>().HasData(new Student 
{
    Name = "John Doe"
});
```

### Entity Relationship

`One to one`
```c#
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Student>()
        .HasOne<StudentAddress>(s => s.Address)
        .WithOne(ad => ad.Student)
        .HasForeignKey<StudentAddress>(ad => ad.AddressOfStudentId);
}
```

`One to many`: 
```c#
// Principal (parent)
public class Blog
{
    public int Id { get; set; }
    public ICollection<Post> Posts { get; } = new List<Post>(); // Collection navigation containing dependents
}

// Dependent (child)
public class Post
{
    public int Id { get; set; }
    public int BlogId { get; set; } // Required foreign key property
    public Blog Blog { get; set; } = null!; // Required reference navigation to principal
}

// OnModelCreating:
modelBuilder.Entity<Blog>()
    .HasMany(e => e.Posts)
    .WithOne(e => e.Blog);
```

`Many to many`: 
```c#
public class Post
{
    public int Id { get; set; }
    public List<PostTag> PostTags { get; } = new();
}

public class Tag
{
    public int Id { get; set; }
    public List<PostTag> PostTags { get; } = new();
}

public class PostTag
{
    public int PostsId { get; set; }
    public int TagsId { get; set; }
    public Post Post { get; set; } = null!;
    public Tag Tag { get; set; } = null!;
}

// Notice that in this mapping there is no many-to-many relationship, but rather two one-to-many relationships

// OnModelCreating:
modelBuilder.Entity<Post>()
    .HasMany(e => e.Tags)
    .WithMany(e => e.Posts);


// Second way: Explicit use of the join type (new with EF Core 7.0)
public class Post
{
    public int Id { get; set; }
    public List<Tag> Tags { get; } = new();
}

public class Tag
{
    public int Id { get; set; }
    public List<Post> Posts { get; } = new();
}
```

> In EF6 there is no many-to-many relationship, but rather two one-to-many relationships. But in EF Core you can.

## Saving & Querying Data
### Basic Queriyng
```c#
using var context = new BloggingContext();
var blogs = context.Blogs
    .Where(b => b.Url.Contains("dotnet"))
    .ToList();
```

### Tracking vs. No-Tracking Queries
`Tracking queries`: By default, queries that return entity types are tracking. A tracking query means any changes to entity instances are persisted by SaveChanges. 

```c#
var blog = context.Blogs.SingleOrDefault(b => b.BlogId == 1);
blog.Rating = 5;
context.SaveChanges();
```

`No-tracking queries`: No-tracking queries are useful when the results are used in a read-only scenario. They're generally quicker to execute because there's no need to set up the change tracking information.

```c#
var blogs = context.Blogs
    .AsNoTracking()
    .ToList();
```

### Loading Related Data
`Eager loading`: Means that the related data is loaded from the database as part of the initial query.
```c#
var blogs = context.Blogs
    .Include(blog => blog.Posts)
    .ThenInclude(post => post.Author)
    .ToList();
```

`Explicit loading`: Means that the related data is explicitly loaded from the database at a later time.
```c#
var blog = context.Blogs
    .Single(b => b.BlogId == 1);

context.Entry(blog)
    .Collection(b => b.Posts)
    .Load();

context.Entry(blog)
    .Reference(b => b.Owner)
    .Load();
```
`Lazy loading`: Means that the related data is transparently loaded from the database when the navigation property is accessed.
The simplest way to use lazy-loading is by installing the Microsoft.EntityFrameworkCore.Proxies package and enabling it with a call to `UseLazyLoadingProxies`
```c#
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
        .UseLazyLoadingProxies()
        .UseSqlServer(myConnectionString);
```
Or when using AddDbContext:
```c#
services.AddDbContext<BloggingContext>(
    b => b.UseLazyLoadingProxies()
          .UseSqlServer(myConnectionString));
```

### Basic SQL queries
You can use `FromSql` to begin a LINQ query based on a SQL query:
```c#
var blogs = context.Blogs
    .FromSql($"SELECT * FROM dbo.Blogs")
    .ToList();
```

### Composing with LINQ
```c#
var blogs = context.Blogs
    .FromSql($"SELECT * FROM dbo.Blogs")
    .Where(b => b.Rating > 3)
    .OrderByDescending(b => b.Rating)
    .ToList();
```

### Saving Data
#### Approach 1: change tracking and SaveChanges
```c#

using var context = new BloggingContext();
var blog = context.Blogs.Single(b => b.Url == "http://example.com");
blog.Url = "http://example.com/blog";
context.SaveChanges();

```

#### Approach 2: ExecuteUpdate and ExecuteDelete ("bulk update")
> This feature was introduced in EF Core 7.0.

```c#
context.Blogs.Where(b => b.Rating < 3).ExecuteDelete();
```

```c#
context.Blogs
    .Where(b => b.Rating < 3)
    .ExecuteUpdate(setters => setters
        .SetProperty(b => b.IsVisible, false)
        .SetProperty(b => b.Rating, 0));
```

### Change Tracking

## EF Core Workflows

### Scaffolding (Reverse Engineering)
```
dotnet ef dbcontext scaffold "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook" Microsoft.EntityFrameworkCore.SqlServer
```

```
Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Chinook' Microsoft.EntityFrameworkCore.SqlServer
```

### Code First


## Migrations
### What is “migration”
### How sql store migrations
### Why use migrations
### Managing migrations

```c#
var host = CreateHostBuilder(args).Build();
using (var scope = host.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}
host.Run();
```

