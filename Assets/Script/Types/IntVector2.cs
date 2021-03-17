public struct IntVector2
{
    public int x;
    public int y;
    public IntVector2(int x, int y)
    {
        this.x = x;
        this.y = y;
    }
    public static IntVector2 operator +(IntVector2 v1, IntVector2 v2)
    {
        return new IntVector2(v1.x + v2.x, v1.y + v2.y);
    }
    public static IntVector2 operator -(IntVector2 v1, IntVector2 v2)
    {
        return new IntVector2(v1.x - v2.x, v1.y - v2.y);
    }

    public static bool operator ==(IntVector2 v1, IntVector2 v2)
    {
        return (v1.x == v2.x && v1.y == v2.y);
    }

    public static bool operator !=(IntVector2 v1, IntVector2 v2)
    {
        return (v1.x != v2.x || v1.y != v2.y);
    }

    public static IntVector2 operator -(IntVector2 v1)
    {
        return new IntVector2(-v1.x, -v1.y);
    }
}
