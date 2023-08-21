using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Board
{
    public const char wallSym = '#';

    private static Board _currentBoard;
    public static Board CurrentBoard
    {
        get { return _currentBoard; }
        set { _currentBoard = value; }
    }

    private int _maxX;
    public int MaxX { get { return _maxX; } private set { _maxX = value; } }
    private int _maxY;
    public int MaxY { get { return _maxY; } private set { _maxY = value; } }

    public Dictionary<int, Point> BoardPoints = new Dictionary<int, Point>();

    public Board(int x, int y)
    {
        MaxX = x;
        MaxY = y;
        InitializeBoard();
        Board.CurrentBoard = this;
    }

    public void InitializeBoard()
    {
        for (int i = 0; i < MaxX; i++)
            for (int j = 0; j < MaxY; j++)
                BoardPoints[i * MaxY + j] = new Point(i, j, ' ');
    }
    
    public Point GetPoint(int x, int y)
    {
        return BoardPoints[x * MaxY + y];
    }

    public void SetPointSym(int x, int y, char sym)
    {
        BoardPoints[x * MaxY + y].sym = sym;
        GetPoint(x, y).Draw();
    }

    public void SetPointSym(Point p, char sym)
    {
        SetPointSym(p.x, p.y, sym);
    }

    public void SetWall()
    {
        for (int i = 0; i < MaxX; i++)
        {
            SetPointSym(i, 0, wallSym);
            SetPointSym(i, MaxY - 1, wallSym);
        }

        for (int i = 1; i < MaxY - 1; i++)
        {
            SetPointSym(0, i, wallSym);
            SetPointSym(MaxX - 1, i, wallSym);
        }
    }

    public void StartBoard()
    {
        Console.Clear();
        SetWall();
    }

    public void PlaceSnake(in Snake snake)
    {
        Point[] points = snake.Body.ToArray();
        
        foreach (Point p in points)
        {
            SetPointSym(p, Snake.snakeSym);
        }
    }

    private void DrawAll()
    {
        for (int i = 0; i < MaxX; i++)
            for (int j = 0; j < MaxY; j++)
                GetPoint(i, j).Draw();
    }
}

public enum PointState
{
    NULL,
    SNAKE,
    WALL
}