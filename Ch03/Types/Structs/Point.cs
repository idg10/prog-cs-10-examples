namespace Structs
{
    public struct Point : IEquatable<Point>
    {
        private double _x;
        private double _y;
        public Point(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public double X => _x;
        public double Y => _y;

        public bool Equals(Point o) => this.X == o.X && this.Y == o.Y;
        public override bool Equals(object? o) => o is Point p && this.Equals(p);
        public override int GetHashCode() => HashCode.Combine(X, Y);

        public static bool operator ==(Point a, Point b) => a.Equals(b);
        public static bool operator !=(Point a, Point b) => !(a == b);
    }
}
