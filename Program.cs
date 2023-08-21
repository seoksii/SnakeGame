using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        Board board = new Board(80, 30);
        board.StartBoard();
        Snake snake = new Snake(4, 5, 4, Direction.RIGHT);
        ScoreManager.InitializeScoreBoard();
        

        // 게임 루프: 이 루프는 게임이 끝날 때까지 계속 실행됩니다.
        while (true)
        {
            // 키 입력이 있는 경우에만 방향을 변경합니다.
            Controller.GetInput();

            // 뱀이 이동하고, 음식을 먹었는지, 벽이나 자신의 몸에 부딪혔는지 등을 확인하고 처리하는 로직을 작성하세요.
            // 이동, 음식 먹기, 충돌 처리 등의 로직을 완성하세요.
            if (snake.checkNextMove() == false) break;

            // 음식의 위치를 무작위로 생성하고, 그립니다.
            FoodCreator.UpdateFood();

            Thread.Sleep(100); // 게임 속도 조절 (이 값을 변경하면 게임의 속도가 바뀝니다)

        }
    }
}

