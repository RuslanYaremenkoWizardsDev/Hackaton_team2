using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace TornamentManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateTournamentForm : Window
    {
        private bool _skipEvent = false;
        public CreateTournamentForm()
        {
            InitializeComponent();

            ObservableCollection<ETournamentModes> _modes = new ObservableCollection<ETournamentModes>(
                (IEnumerable<ETournamentModes>)Enum.GetValues(typeof(ETournamentModes)));
            TornamentModesComboBox.ItemsSource = _modes;
            TornamentModesComboBox.SelectedItem = _modes[0];

            ObservableCollection<ETournamentLevel> _levels = new ObservableCollection<ETournamentLevel>(
                (IEnumerable<ETournamentLevel>)Enum.GetValues(typeof(ETournamentLevel)));
            TournamentLevelsComboBox.ItemsSource = _levels;
            TournamentLevelsComboBox.SelectedItem = _levels[1];
            StartDatePicker.Minimum = DateTime.Now;

            PrepareNumberOfParticipantsComboBox();
            PrepareTournamentScenariosComboBoxItems();
        }
        private void TornamentModesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrepareNumberOfParticipantsComboBox();
            PrepareTournamentScenariosComboBoxItems();
        }

        private void StartDatePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LastRegistrationDatePicker.Maximum = ((DateTime)StartDatePicker.Value).AddSeconds(2);
            LastRegistrationDatePicker.Minimum = DateTime.Now;
            LastRegistrationDatePicker.DefaultValue = ((DateTime)StartDatePicker.Value).AddSeconds(1);

            if (!_skipEvent)
            {
                _skipEvent = true;
                StartDatePicker.Value = ((DateTime)StartDatePicker.Value).AddSeconds(2);
                _skipEvent = false;
            }
            if (StartDatePicker.Value != null && !LastRegistrationDatePicker.IsEnabled)
            {
                LastRegistrationDatePicker.IsEnabled = true;
            }
        }

        private void PrepareTournamentScenariosComboBoxItems()
        {
            ObservableCollection<ETournamentScenarios> scenarios = new ObservableCollection<ETournamentScenarios>(
                (IEnumerable<ETournamentScenarios>)Enum.GetValues(typeof(ETournamentScenarios)));

            if (TornamentModesComboBox.SelectedIndex == 0)
            {
                scenarios = new ObservableCollection<ETournamentScenarios>((IEnumerable<ETournamentScenarios>)Enum.GetValues(typeof(ETournamentScenarios)));
            }
            else
            {
                scenarios = new ObservableCollection<ETournamentScenarios>();
                scenarios.Add(ETournamentScenarios.OneMatchConfrontation);
            }

            TournamentScenariosComboBox.ItemsSource = scenarios;
            TournamentScenariosComboBox.SelectedItem = scenarios[0];
        }

        private void PrepareNumberOfParticipantsComboBox()
        {
            ObservableCollection<int> numberOfParticipants = new ObservableCollection<int>();
            switch (TornamentModesComboBox.SelectedIndex)
            {
                case 0:
                    int numb = 4;

                    for (int i = 0; i < 6; ++i)
                    {
                        numberOfParticipants.Add(numb);
                        numb = numb * 2;
                    }

                    NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;
                    NumberOfParticipantsComboBox.SelectedItem = numberOfParticipants[3];

                    break;

                case 1:

                    for (int i = 1; i <= 10; ++i)
                    {
                        numberOfParticipants.Add(i);
                    }

                    NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;
                    NumberOfParticipantsComboBox.SelectedItem = numberOfParticipants[numberOfParticipants.Count - 1];

                    break;
            }
        }

        private void BtnCreateTournament_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfRequiredFieldsAreNotEmpty())
            {
                ITournament tournament;

                switch ((ETournamentModes)TornamentModesComboBox.SelectedItem)
                {
                    case ETournamentModes.Cup:
                        tournament = new TournamentCup(TournamentName.Text, ETournamentModes.Cup, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                        break;

                    case ETournamentModes.Championship:
                        tournament = new TournamentChampionship(TournamentName.Text, ETournamentModes.Championship, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                        break;

                    default:
                        tournament = new TournamentCup(TournamentName.Text, ETournamentModes.Cup, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                        break;
                }

                tournament.Description = TournamentDescription.Text;
                tournament.Place = TournamentPlace.Text;
                tournament.StartDateTime = (DateTime)StartDatePicker.Value;
                tournament.LastRegistrationDateTime = (DateTime)LastRegistrationDatePicker.Value;

                tournament.TournamentLevel = (ETournamentLevel)TournamentLevelsComboBox.SelectedItem;
                tournament.Scenario = (ETournamentScenarios)TournamentScenariosComboBox.SelectedItem;

                World world = (World)World.WorldInstance;

                world.TournamentsList.AddTournament(tournament);

                this.Close();
            }
        }
        private bool CheckIfRequiredFieldsAreNotEmpty()
        {
            bool check = false;

            if (TournamentName.Text.Length != 0
               && StartDatePicker.Value != null
               && LastRegistrationDatePicker.Value != null)
            {
                check = true;
            }

            return check;
        }
    }
}
