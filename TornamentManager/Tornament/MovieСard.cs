using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TornamentManager.Tornament
{
    public class MovieСard : WrapPanel
    {
        public TextBlock movieTime;
        public MovieСard()
        {
            Width = 906;
            Height = 192;
            HorizontalAlignment = System.Windows.HorizontalAlignment.Stretch;
            VerticalAlignment = System.Windows.VerticalAlignment.Stretch;
            Thickness marginThickness = new Thickness(2);
            Margin = marginThickness;

            Grid movieCardGrid = new Grid();

            movieCardGrid.Height = 191;
            movieCardGrid.Width = 905;

            RowDefinition rowDefinition = new RowDefinition();

            rowDefinition.Height = new GridLength(45, GridUnitType.Star);
            movieCardGrid.RowDefinitions.Add(rowDefinition);

            rowDefinition = new RowDefinition();
            rowDefinition.Height = new GridLength(145, GridUnitType.Star);
            movieCardGrid.RowDefinitions.Add(rowDefinition);

            ColumnDefinition columnDefinition = new ColumnDefinition();

            columnDefinition.Width = new GridLength(300, GridUnitType.Star);
            movieCardGrid.ColumnDefinitions.Add(columnDefinition);

            columnDefinition = new ColumnDefinition();
            columnDefinition.Width = new GridLength(600, GridUnitType.Star);
            movieCardGrid.ColumnDefinitions.Add(columnDefinition);



            TextBlock movieName = new TextBlock();
            movieName.Foreground = Brushes.Black;
            movieName.FontSize = 25;
            movieName.FontWeight = FontWeights.Bold;
            movieName.Text = "aaaaa";
            Grid.SetRow(movieName, 0);
            Grid.SetColumn(movieName, 0);
            movieCardGrid.Children.Add(movieName);

            movieTime = new TextBlock();
            movieTime.Foreground = Brushes.Black;
            movieTime.FontSize = 25;
            movieTime.FontWeight = FontWeights.Bold;
            movieTime.Text = "2020";
            Grid.SetRow(movieTime, 0);
            Grid.SetColumn(movieTime, 1);
            movieCardGrid.Children.Add(movieTime);

            TextBlock movieDescription = new TextBlock();
            movieDescription.Foreground = Brushes.Black;
            movieDescription.FontSize = 25;
            movieDescription.FontWeight = FontWeights.Bold;
            movieDescription.Text ="bbbb";
            Grid.SetRow(movieDescription, 1);
            Grid.SetColumn(movieDescription, 1);
            movieCardGrid.Children.Add(movieDescription);

            Image movieImage = new Image();
            Grid.SetRow(movieImage, 0);
            Grid.SetColumn(movieImage, 0);

            Border border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(3);
            border.Child = movieCardGrid;
            this.Children.Add(border);
        }
    }
}
