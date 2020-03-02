using System;

public class GridPosition : EventArgs
{
    public int Column;
    public int Row;

    public GridPosition(int column, int row)
    {
        Column = column;
        Row = row;
    }
}