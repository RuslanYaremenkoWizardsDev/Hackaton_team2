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
        public int ID { get; private set; }
        private const int countOfColumn = 10;
        public TournamentBox(ITournament tournament)
        {
            ID = tournament.ID;
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
            textBlock.Name = "StartDate";
            textBlock.Text = tournament.StartDateTime.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 3);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "LastRegistrationDate";
            textBlock.Text = tournament.LastRegistrationDateTime.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 4);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "State";
            textBlock.Text = "Active";
            border.Child = textBlock;
            Grid.SetColumn(border, 5);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Level";
            textBlock.Text = tournament.TournamentLevel.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 6);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Participants";
            textBlock.Text = $"{tournament.Players.Count}/{tournament.NumberOfParticipants}";
            border.Child = textBlock;
            Grid.SetColumn(border, 7);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);
            textBlock = new TextBlock();
            textBlock.Name = "Scenario";
            textBlock.Text = tournament.Scenario.ToString();
            border.Child = textBlock;
            Grid.SetColumn(border, 8);
            Children.Add(border);

            border = new Border();
            border.BorderBrush = Brushes.Black;
            border.BorderThickness = new Thickness(1);

            DockPanel dockPanel = new DockPanel();

            Button removeButton = new Button();
            removeButton.Content = "Remove";
            removeButton.Margin = new Thickness(2);
            removeButton.Click += Button_Remove_Click;
            DockPanel.SetDock(removeButton, Dock.Bottom);
            dockPanel.Children.Add(removeButton);

            Button tornamentViewButton = new Button();
            tornamentViewButton.Content = "View";
            tornamentViewButton.Margin = new Thickness(2);
            DockPanel.SetDock(tornamentViewButton, Dock.Top);
            dockPanel.Children.Add(tornamentViewButton);

            border.Child = dockPanel;

            Grid.SetColumn(border, 9);
            Children.Add(border);
        }

        public void Button_Remove_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                int id = ((TournamentBox)(((Border)(((DockPanel)(button.Parent)).Parent)).Parent)).ID;
                World.WorldInstance.TournamentsList.RemoveTournamentByID(id);
            }
        }
    }
}
