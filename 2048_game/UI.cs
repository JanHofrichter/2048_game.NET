using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048_game;

public class Ui
{
    public static Border CreateCell(int row, int col, int[,] grid, SolidColorBrush borderColor,
        SolidColorBrush fontColorSmall, SolidColorBrush fontColorBig, SolidColorBrush cellColor)
    {
        string text = "";
        Border border = new Border
        {
            BorderBrush = borderColor,
            BorderThickness = new Thickness(6),
        };

        Grid cellgrid = new Grid
        {
            Background = cellColor // Use color from dictionary
        };
        if (grid[row, col] != 0)
        {
            text = grid[row, col].ToString();
        }

        TextBlock tile = new TextBlock
        {
            Text = text,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 35,
            FontWeight = FontWeights.Bold
        };

        if (grid[row, col] <= 4)
        {
            tile.Foreground = fontColorSmall; 
        }
        else
        {
            tile.Foreground = fontColorBig; 
        }

        cellgrid.Children.Add(tile); // Add TextBlock to the cell Grid

        border.Child = cellgrid;

        Grid.SetRow(border, row); // place in row and col
        Grid.SetColumn(border, col);

        return border;
    }
}