using Records;

var unlabelled = new OptionallyLabelledItem();
var labelled = new OptionallyLabelledItem
{
    Label = "New, improved!"
};

var unlabelledProduct = new Product("Book");
var labelledProduct = new Product("Shirt")
{
    Label = "Half price"
};

Console.WriteLine(unlabelled);
Console.WriteLine(labelled);
Console.WriteLine(unlabelledProduct);
Console.WriteLine(labelledProduct);

var commonModelT = new FordModelT();
var lateModelT = new FordModelT { Color = "Green" };

Console.WriteLine(commonModelT);
Console.WriteLine(lateModelT);

OptionallyLabelled Discount(OptionallyLabelled item)
{
    return item with
    {
        Label = "60% off!"
    };
}

Console.WriteLine(Discount(new OptionallyLabelledItem()));
Console.WriteLine(Discount(new Product("Sweater")));

Console.WriteLine(new LabelledDemographic("Noisy"));