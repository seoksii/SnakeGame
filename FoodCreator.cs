using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class FoodCreator
{
    public const char foodSym = '$';
    
    
    private static Point? _food;

    public static void UpdateFood()
    {
        if (_food != null) return;
        GenerateFood();
    }
    
    public static void GenerateFood()
    {
        if (Board.CurrentBoard == null) return;

        Random seed = new Random();
        
        bool isSuccess = false;

        while (isSuccess == false)
        {
            int randX = seed.Next(1, Board.CurrentBoard.MaxX - 1);
            int randY = seed.Next(1, Board.CurrentBoard.MaxY - 1);

            if (Board.CurrentBoard.GetPoint(randX, randY).sym == ' ')
            {
                isSuccess = true;
                Board.CurrentBoard.SetPointSym(randX, randY, foodSym);
                _food = Board.CurrentBoard.GetPoint(randX, randY);
            }
        }
    }

    public static void RemoveFood()
    {
        _food = null;
    }
}