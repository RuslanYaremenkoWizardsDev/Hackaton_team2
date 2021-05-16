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
        public TornamentBox(ITournament tournament)
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
            textBlock.Name = "Tournament Name";
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
            Grid.SetColumn(border, 1);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Last Registration Date";
            textBlock.Text = tournament.LastRegistrationDateTime.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 1);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "State";
            textBlock.Text = "Active";
            border.Child = textBlock;
            Grid.SetColumn(border, 1);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Level";
            textBlock.Text = tournament.TournamentLevel.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 1);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Participants";
            textBlock.Text = tournament.NumberOfParticipants.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 1);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Scenario";
            textBlock.Text = tournament.Scenario.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 1);
            Children.Add(border);
        }
    }
}
