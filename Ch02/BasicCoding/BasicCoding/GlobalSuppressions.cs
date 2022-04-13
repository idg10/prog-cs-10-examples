// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage(
    "Style",
    "IDE0066:Convert switch statement to expression",
    Justification = "The purpose of the example is to show a switch statement that illustrates why the switch expression is a better alternative - the very next example then goes on to show the equivalent switch expression",
    Scope = "member",
    Target = "~M:BasicCoding.Patterns.NonExpressionPatterns(System.Object)~System.String")]

[assembly: SuppressMessage(
    "CodeQuality",
    "IDE0079:Remove unnecessary suppression",
    Justification = "The point of the example is to show the syntax of a suppression, so removing the suppression would defeat the point",
    Scope = "type",
    Target = "~T:BasicCoding.PreprocessingDirectives")]

[assembly: SuppressMessage(
    "Style",
    "IDE0090:Use 'new(...)'",
    Justification = "In this case, I think the use of an untyped new makes it harder to understand what's going on, because we're doing something fairly unusual here (executing a string constructor)",
    Scope = "member",
    Target = "~M:BasicCoding.StringsAndChars.CharactersVsChars")]
