using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class ScoreManager
{
    private static int _score = 0;
    public static int Score
    { 
        get { return _score; }
        set { _score = value; }
    }

    private static int _startX = 0;
    private static int _startY = 0;

    private static int _sizeX = 12;
    private static int _sizeY = 6;

    public static void InitializeScoreBoard()
    {
        _startX = Board.CurrentBoard.MaxX + 3;

        for (int i = 0; i < _sizeX; i++)
        {
            Console.SetCursorPosition(_startX + i, _startY);
            Console.Write("#");
            Console.SetCursorPosition(_startX + i, _startY + _sizeY);
            Console.Write("#");
        }
        for (int i = 0; i < _sizeY; i++)
        {
            Console.SetCursorPosition(_startX, _startY + i);
            Console.Write("#");
            Console.SetCursorPosition(_startX + _sizeX, _startY + i);
            Console.Write("#");
        }

        Console.SetCursorPosition(_startX + 3, _startY + 2);
        Console.Write("현재점수");

        UpdateScore();
    }

    public static void UpdateScore()
    {
        Console.SetCursorPosition(_startX + 4, _startY + 4);
        Console.Write($"{_score.ToString("000000")}");
    }

    public static void AddScore()
    {
        ++_score;
        UpdateScore();
    }
}
