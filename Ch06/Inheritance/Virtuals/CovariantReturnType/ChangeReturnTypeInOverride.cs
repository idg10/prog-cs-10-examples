namespace Virtuals.CovariantReturnType;

public class Product { }
public class Book : Product { }

public class ProductSourceBase
{
    public virtual Product Get() { return new Product(); }
}

public class BookSource : ProductSourceBase
{
    public override Book Get() { return new Book(); }
}