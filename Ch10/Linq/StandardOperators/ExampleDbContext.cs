using Microsoft.EntityFrameworkCore;

namespace StandardOperators;

public class ExampleDbContext : DbContext
{
    public DbSet<Product> Product => Set<Product>();

}

public class Product
{
    // We define a constructor that requires values for all properties to
    // be supplied. This clarifies the intent that all of these properties
    // are non-optional. (We would expect the corresponding database
    // columns to be non-nullable.) This also avoids the compiler warnings
    // that would occur if we had only the default no-args constructor:
    // because Name is non-nullable, the presence of a constructor (either
    // explicit, or implicitly generated) that does not initialize Name
    // causes a CS8618 warning if nullable reference types are enabled.
    // Note that the use of this constructor is not a workaround for that
    // warning. On the contrary, it is an explicit expression of our
    // required initialization semantics, and by expressing that
    // explicitly, we enable the compiler to determine that Name will
    // always be correctly initialized, so there's no problem here. We
    // are able to do this because Entity Framework Core supports
    // constructor binding. (Some deserialization systems, such as
    // Microsoft.Extension.Configuration, do not support constructor
    // binding, making it hard to use nullable reference types correctly.)
    public Product(
        string name,
        decimal listPrice,
        double size)
    {
        Name = name;
        ListPrice = listPrice;
        Size = size;
    }

    public string Name { get; set; }

    public decimal ListPrice { get; set; }

    public double Size { get; set; }
}