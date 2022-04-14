// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Performance",
    "CA1822:Mark members as static",
    Justification = "This needs to be callable as a non-static member so that the C# query syntax can find it",
    Scope = "member",
    Target = "~M:QueryExpressions.SillyLinqProvider.Select``1(System.Func{System.DateTime,``0})~System.String")]
