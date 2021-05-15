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
    public class TornamentBox : Grid
    {
        private const int countOfColumn = 8;
        public TornamentBox()
        {
            string defaultText = "SomeText";
            Thickness marginThickness = new Thickness(2);
            Margin = marginThickness;

            for (int i = 0; i < countOfColumn; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
                Border border = new Border();
                border.BorderBrush = Brushes.Black;
                border.BorderThickness = new Thickness(1);
                TextBlock textBlock = new TextBlock();
                textBlock.Text = defaultText;
                border.Child = textBlock;
                Grid.SetColumn(border, i);
                this.Children.Add(border);
            }
        }
    }
}
