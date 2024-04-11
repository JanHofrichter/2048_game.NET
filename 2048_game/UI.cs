using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _2048_game;

public class UI
{
    public Border CreateCell(int row, int col, int[,] _grid, SolidColorBrush bordercolor,
        SolidColorBrush fontcolorsmall, SolidColorBrush fontcolorbig, SolidColorBrush cellcolor)
    {
        string text = "";
        Border border = new Border
        {
            BorderBrush = bordercolor,
            BorderThickness = new Thickness(15)
        };

        Grid cellgrid = new Grid
        {
            Background = cellcolor // Use color from dictionary
        };
        if (_grid[row, col] != 0)
        {
            text = _grid[row, col].ToString();
        }

        TextBlock tile = new TextBlock
        {
            Text = text,
            HorizontalAlignment = HorizontalAlignment.Center,
            VerticalAlignment = VerticalAlignment.Center,
            FontSize = 45,
            FontWeight = FontWeights.Bold
        };

        if (_grid[row, col] <= 4)
        {
            tile.Foreground = fontcolorsmall; // Ensure text is visible
        }
        else
        {
            tile.Foreground = fontcolorbig; // Ensure text is visible
        }

        cellgrid.Children.Add(tile); // Add TextBlock to the cell Grid

        border.Child = cellgrid;

        Grid.SetRow(border, row);
        Grid.SetColumn(border, col);

        return border;
    }
}