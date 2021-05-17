using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TornamentManager.Participants
{
    class ParticipantsBox : Grid
    {
        private const int countOfColumn = 2;
        public ParticipantsBox(string text)
        {
            Thickness marginThickness = new Thickness(2);
            Margin = marginThickness;

            for (int i = 0; i < countOfColumn; i++)
            {
                ColumnDefinitions.Add(new ColumnDefinition());
            }

            Border border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            TextBlock textBlock = new TextBlock();
            textBlock.Name = "Participants";
            textBlock.Text = text; //fix
            border.Child = textBlock;
            Grid.SetColumn(border, 0);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            Button button = new Button();
            button.Content = "Remove";
            button.Margin = new Thickness(2);
            World world = (World)World.WorldInstance;
            button.Click += Button_Remove_Click;

            border.Child = button;
            Grid.SetColumn(border, 1);
            Children.Add(border);
        }

        public void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                //World.WorldInstance.TournamentsList.RemoveTournamentByID(((TournamentBox)(((Border)(button.Parent)).Parent)).ID);
            }
        }
    }
}
