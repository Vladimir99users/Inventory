using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int Width;
    private int Height;


    private GridCell[,] gridArray;

    public GridCell[,] GridArray { get => gridArray;  }


    public Grid(int h, int w)
    {
        Width = w;
        Height = h;

        gridArray = new GridCell[Width, Height];

        for(int x = 0; x < gridArray.GetLength(0);x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                gridArray[x, y] = new GridCell { X = x, Y = y };
            }
        }
    }

}

public class GridCell
{
    public int X;
    public int Y;
}

