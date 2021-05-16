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
    public class TournamentBox : Grid
    {
        private const int countOfColumn = 8;
        public TournamentBox(ITournament tournament)
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
            textBlock.Name = "TournamentName";
            textBlock.Text = tournament.Name;
            border.Child = textBlock;
            Grid.SetColumn(border, 0);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Mode";
            textBlock.Text = tournament.TournamentMode.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 1);
            Children.Add(border);
            
            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Place";
            textBlock.Text = tournament.Place;
            border.Child = textBlock;
            Grid.SetColumn(border, 2);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "LastRegistrationDate";
            textBlock.Text = tournament.LastRegistrationDateTime.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 3);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "State";
            textBlock.Text = "Active";
            border.Child = textBlock;
            Grid.SetColumn(border, 4);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Level";
            textBlock.Text = tournament.TournamentLevel.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 5);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Participants";
            textBlock.Text = tournament.NumberOfParticipants.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 6);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Scenario";
            textBlock.Text = tournament.Scenario.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 7);
            Children.Add(border);
        }
    }
}
