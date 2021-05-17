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
    public class TournamentParticipantBox : Grid, IParticipantBox
    {
        private const int countOfColumn = 2;
        public int ID { get; private set; }

        public TournamentParticipantBox(ITeamClass participant)
        {
            ID = participant.ID;
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
            textBlock.Text = participant.Name;
            border.Child = textBlock;
            Grid.SetColumn(border, 0);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            Button button = new Button();
            button.Content = "Move";
            button.Margin = new Thickness(2);
            World world = (World)World.WorldInstance;
            button.Click += Button_Move_Click;

            border.Child = button;
            Grid.SetColumn(border, 1);
            Children.Add(border);
        }

        public void Button_Move_Click(object sender, RoutedEventArgs e)
        {
            StackPanel stackPanel = (StackPanel)(((TournamentParticipantBox)(((Border)(((Button)sender).Parent)).Parent)).Parent);
            ScrollViewer scrollViewer = (ScrollViewer)stackPanel.Parent;
            Grid grid = (Grid)scrollViewer.Parent;

            foreach (var c in grid.Children)
            {
                if (c is ScrollViewer)
                {
                    ScrollViewer sv = (ScrollViewer)c;
                    StackPanel sc = (StackPanel)sv.Content;
                    if (sc.Name == "TournamentParticipantsList")
                    {
                        stackPanel.Children.Remove(this);
                        sc.Children.Add(this);
                    }
                }
            }
        }
    }
}