namespace Records;

public record PointRecord(int X, int Y);
public record struct PointStructRecord(int X, int Y);
public readonly record struct PointReadonlyStructRecord(int X, int Y);