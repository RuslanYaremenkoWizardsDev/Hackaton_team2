using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TornamentManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class TornamentView : Window
    {
        public TornamentView(ITournament tournament)
        {
            InitializeComponent();
            TournamentNameTextBox.Text = tournament.Name;
            TournamentStatusComboBox.SelectedItem = "Status";
            PlaceTextBox.Text = tournament.Place;
            DescriptionTextBox.Text = tournament.Description;
            
            ObservableCollection<ETournamentModes> _modes = new ObservableCollection<ETournamentModes>(
                (IEnumerable<ETournamentModes>)Enum.GetValues(typeof(ETournamentModes)));
            TournamentModesComboBox.ItemsSource = _modes;
            TournamentModesComboBox.SelectedItem = tournament.TournamentMode;
            PrepareTournamentScenariosComboBoxItems(tournament);

            StartDatePicker.Value = tournament.StartDateTime;
            LastRegistrationDatePicker.Value = tournament.LastRegistrationDateTime;

            ObservableCollection<ETournamentLevel> levels = new ObservableCollection<ETournamentLevel>(
                (IEnumerable<ETournamentLevel>)Enum.GetValues(typeof(ETournamentLevel)));
            TournamentLevelsComboBox.ItemsSource = levels;
            TournamentLevelsComboBox.SelectedItem = tournament.TournamentLevel;

            PrepareNumberOfParticipantsComboBox(tournament);
        }
        private void PrepareTournamentScenariosComboBoxItems(ITournament tournament)
        {
            ObservableCollection<ETournamentScenarios> scenarios = new ObservableCollection<ETournamentScenarios>(
                (IEnumerable<ETournamentScenarios>)Enum.GetValues(typeof(ETournamentScenarios)));

            if (TournamentModesComboBox.SelectedIndex == 0)
            {
                scenarios = new ObservableCollection<ETournamentScenarios>(
                    (IEnumerable<ETournamentScenarios>)Enum.GetValues(typeof(ETournamentScenarios)));
            }
            else
            {
                scenarios = new ObservableCollection<ETournamentScenarios>();
                scenarios.Add(ETournamentScenarios.OneMatchConfrontation);
            }

            TournamentScenariosComboBox.ItemsSource = scenarios;
            TournamentScenariosComboBox.SelectedItem = tournament.Scenario;
        }

        private void PrepareNumberOfParticipantsComboBox(ITournament tournament)
        {
            ObservableCollection<int> numberOfParticipants = new ObservableCollection<int>();
            switch (TournamentModesComboBox.SelectedIndex)
            {
                case 0:
                    int numb = 4;

                    for (int i = 0; i < 6; ++i)
                    {
                        numberOfParticipants.Add(numb);
                        numb = numb * 2;
                    }

                    NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;
                    NumberOfParticipantsComboBox.SelectedItem = tournament.NumberOfParticipants;

                    break;

                case 1:

                    for (int i = 1; i <= 10; ++i)
                    {
                        numberOfParticipants.Add(i);
                    }

                    NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;
                    NumberOfParticipantsComboBox.SelectedItem = tournament.NumberOfParticipants;

                    break;
            }
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                ITournament tournament;

                switch ((ETournamentModes)TournamentModesComboBox.SelectedItem)
                {
                    case ETournamentModes.Cup:
                        tournament = new TournamentCup(TournamentNameTextBox.Text, ETournamentModes.Cup, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                        break;

                    case ETournamentModes.Championship:
                        tournament = new TournamentChampionship(TournamentNameTextBox.Text, ETournamentModes.Championship, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                        break;

                    default:
                        tournament = new TournamentCup(TournamentNameTextBox.Text, ETournamentModes.Cup, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                        break;
                }

                tournament.Description = DescriptionTextBox.Text;
                tournament.Place = PlaceTextBox.Text;
                tournament.StartDateTime = (DateTime)StartDatePicker.Value;
                tournament.LastRegistrationDateTime = (DateTime)LastRegistrationDatePicker.Value;

                tournament.TournamentLevel = (ETournamentLevel)TournamentLevelsComboBox.SelectedItem;
                tournament.Scenario = (ETournamentScenarios)TournamentScenariosComboBox.SelectedItem;

                World world = (World)World.WorldInstance;

                ITournament editTournament = world.TournamentsList.GetTournamentByID(tournament.ID);
                editTournament = tournament;
            }
        }
    }
}
