using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Point
{
    public int x { get; set; }
    public int y { get; set; }
    public char sym { get; set; }

    // Point 클래스 생성자
    public Point(int _x, int _y)
    {
        x = _x;
        y = _y;
        sym = ' ';
    }

    public Point(int _x, int _y, char _sym)
    {
        x = _x;
        y = _y;
        sym = _sym;
    }

    // 점을 그리는 메서드
    public void Draw()
    {
        Console.SetCursorPosition(x, y);
        Console.Write(sym);
    }

    // 점을 지우는 메서드
    public void Clear()
    {
        sym = ' ';
        Draw();
    }

    // 두 점이 같은지 비교하는 메서드
    public bool IsHit(Point p)
    {
        return p.x == x && p.y == y;
    }

    public static Point operator +(in Point p,  Tuple<int, int> delta)
    {
        return new Point(p.x + delta.Item1, p.y + delta.Item2, p.sym);
    }

    public static Point operator +(in Point p1, in Point p2)
    {
        return new Point(p1.x + p2.x, p1.y + p2.y, p1.sym);
    }
}