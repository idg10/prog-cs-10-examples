using System.Runtime.CompilerServices;

[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage(
    "Style",
    "IDE0060:Remove unused parameter",
    Justification = "This is just some example code from a book",
    Scope = "member",
    Target = "~M:Idg.Examples.SomeMethod")]

[assembly: InternalsVisibleTo("ImageManagement.Tests")]
[assembly: InternalsVisibleTo("ImageServices.Tests")]