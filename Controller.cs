using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class Controller
{
    public static Snake? CurrentSnake;

    public static void GetInput()
    {
        if (CurrentSnake == null) return;
        if (Console.KeyAvailable == false) return;

        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        switch (keyInfo.Key)
        {
            case ConsoleKey.A:
                CurrentSnake.Dir = Direction.LEFT; break;
            case ConsoleKey.D:
                CurrentSnake.Dir = Direction.RIGHT; break;
            case ConsoleKey.W:
                CurrentSnake.Dir = Direction.UP; break;
            case ConsoleKey.S:
                CurrentSnake.Dir = Direction.DOWN; break;
            case ConsoleKey.LeftArrow:
                CurrentSnake.Dir = Direction.LEFT; break;
            case ConsoleKey.RightArrow:
                CurrentSnake.Dir = Direction.RIGHT; break;
            case ConsoleKey.UpArrow:
                CurrentSnake.Dir = Direction.UP; break;
            case ConsoleKey.DownArrow:
                CurrentSnake.Dir = Direction.DOWN; break;
        }
    }

}