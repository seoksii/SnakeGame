using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Text;
using System.Threading.Tasks;

public class Snake
{
    public const char snakeSym = '*';

    private Point _head;
    public Point Head
    {
        get { return _head; }
        private set { _head = value; }
    }

    private Queue<Point> _body = new Queue<Point>();
    public Queue<Point> Body
    {
        get { return _body; }
        private set { _body = value; }
    }

    private Direction _dir;
    public Direction Dir
    {
        get { return _dir; }
        set { if (value != GetOppositeDir(_dir)) _dir = value; }
    }

    public Snake(int x, int y, int length, Direction direction)
    {
        Dir = direction;
        Direction drawDir = GetOppositeDir(direction);
        Point currentPoint = new Point(x, y, snakeSym);
        Head = currentPoint;

        Stack<Point> stack = new Stack<Point>();
        for (int i = 0; i < length; i++)
        {
            stack.Push(currentPoint);
            currentPoint = GetNextPoint(currentPoint, drawDir);
        }
        while (stack.Count > 0)
            Body.Enqueue(stack.Pop());

        Board.CurrentBoard.PlaceSnake(this);

        Controller.CurrentSnake = this;
    }

    public bool checkNextMove()
    {
        Point nextPoint = GetNextPoint(Head, Dir);

        switch (Board.CurrentBoard.GetPoint(nextPoint.x, nextPoint.y).sym)
        {
            case snakeSym: return false;
            case Board.wallSym: return false;
            case FoodCreator.foodSym:
                Grow(nextPoint);
                FoodCreator.RemoveFood();
                return true;
        }

        MoveTo(nextPoint);

        return true;
    }

    private void MoveTo(Point nextPoint)
    {
        RemoveTail();
        AddHead(nextPoint);
    }

    private void Grow(Point nextPoint)
    {
        AddHead(nextPoint);
        ScoreManager.AddScore();
    }

    private void AddHead(Point point)
    {
        Board.CurrentBoard.SetPointSym(point, snakeSym);
        Body.Enqueue(point);
        Head = point;
    }

    private void RemoveTail()
    {
        Point tail = Body.Dequeue();
        Board.CurrentBoard.SetPointSym(tail, ' ');
    }

    private Direction GetOppositeDir(in Direction direction)
    {
        switch (direction)
        {
            case Direction.RIGHT:  return Direction.LEFT;
            case Direction.UP:  return Direction.DOWN;
            case Direction.DOWN:  return Direction.UP;
            default:return Direction.LEFT;
        }
    }

    private Point GetNextPoint(in Point currentPoint, Direction direction)
    {
        return new Point(currentPoint.x, currentPoint.y) + DirToDelta(direction);
    }

    private Tuple<int,int> DirToDelta(Direction direction)
    {
        switch (direction)
        {
            case Direction.RIGHT: return new Tuple<int, int>(1, 0);
            case Direction.UP: return new Tuple<int, int>(0, -1);
            case Direction.DOWN: return new Tuple<int, int>(0, 1);
            default: return new Tuple<int, int>(-1, 0);
        }
    }
}

// 방향을 표현하는 열거형입니다.
public enum Direction
{
    LEFT,
    RIGHT,
    UP,
    DOWN
}