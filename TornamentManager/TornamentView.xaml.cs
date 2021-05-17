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
        public ITournament Tournament;
        private bool _skipEvent = false;
        public TornamentView(ITournament tournament)
        {
            InitializeComponent();
            Tournament = tournament;

            TournamentNameTextBox.Text = tournament.Name;
            TournamentStatusComboBox.SelectedItem = "Status";
            PlaceTextBox.Text = tournament.Place;
            DescriptionTextBox.Text = tournament.Description;

            ObservableCollection<ETournamentModes> _modes = new ObservableCollection<ETournamentModes>(
                (IEnumerable<ETournamentModes>)Enum.GetValues(typeof(ETournamentModes)));
            TournamentModesComboBox.ItemsSource = _modes;
            TournamentModesComboBox.SelectedItem = tournament.TournamentMode;
            PrepareTournamentScenariosComboBoxItems();

            if (tournament.StartDateTime < DateTime.Now)
            {
                StartDatePicker.Minimum = tournament.StartDateTime;
            }
            else
            {
                StartDatePicker.Minimum = DateTime.Now.AddSeconds(-1);
                StartDatePicker.Value = tournament.StartDateTime;
            }

            LastRegistrationDatePicker.Value = tournament.LastRegistrationDateTime;

            ObservableCollection<ETournamentLevel> levels = new ObservableCollection<ETournamentLevel>(
                (IEnumerable<ETournamentLevel>)Enum.GetValues(typeof(ETournamentLevel)));
            TournamentLevelsComboBox.ItemsSource = levels;
            TournamentLevelsComboBox.SelectedItem = tournament.TournamentLevel;

            AllParticipantsNamesDGrid.ItemsSource = World.WorldInstance.TeamDictionary;

            PrepareNumberOfParticipantsComboBox();
        }
        private void StartDatePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LastRegistrationDatePicker.Maximum = StartDatePicker.Value;
        }
        private void PrepareTournamentScenariosComboBoxItems()
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
            TournamentScenariosComboBox.SelectedItem = Tournament.Scenario;
        }

        private void PrepareNumberOfParticipantsComboBox()
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
                    if (NumberOfParticipantsComboBox.SelectedItem == null)
                    {
                        NumberOfParticipantsComboBox.SelectedItem = numberOfParticipants[3];
                    }
                    else
                    {
                        NumberOfParticipantsComboBox.SelectedItem = Tournament.NumberOfParticipants;
                    }

                    break;

                case 1:

                    for (int i = 1; i <= 10; ++i)
                    {
                        numberOfParticipants.Add(i);
                    }

                    NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;

                    if (NumberOfParticipantsComboBox.SelectedItem == null)
                    {
                        NumberOfParticipantsComboBox.SelectedItem = numberOfParticipants[numberOfParticipants.Count - 1];
                    }
                    else
                    {
                        NumberOfParticipantsComboBox.SelectedItem = Tournament.NumberOfParticipants;
                    }

                    break;
            }
        }

        private void TornamentModesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PrepareNumberOfParticipantsComboBox();
            PrepareTournamentScenariosComboBoxItems();
        }

        private void SaveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (CheckIfRequiredFieldsAreNotEmpty())
            {
                World world = (World)World.WorldInstance;

                if (Tournament.TournamentMode != (ETournamentModes)TournamentModesComboBox.SelectedItem)
                {
                    world.TournamentsList.RemoveTournamentByID(Tournament.ID);

                    switch ((ETournamentModes)TournamentModesComboBox.SelectedItem)
                    {
                        case ETournamentModes.Cup:
                            Tournament = new TournamentCup(TournamentNameTextBox.Text, ETournamentModes.Cup, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                            break;

                        case ETournamentModes.Championship:
                            Tournament = new TournamentChampionship(TournamentNameTextBox.Text, ETournamentModes.Championship, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                            break;

                        default:
                            Tournament = new TournamentCup(TournamentNameTextBox.Text, ETournamentModes.Cup, Convert.ToInt32(NumberOfParticipantsComboBox.Text));
                            break;
                    }

                    world.TournamentsList.AddTournament(Tournament);
                }

                Tournament.Name = TournamentNameTextBox.Text;
                Tournament.Description = DescriptionTextBox.Text;
                Tournament.Place = PlaceTextBox.Text;
                Tournament.StartDateTime = (DateTime)StartDatePicker.Value;
                Tournament.LastRegistrationDateTime = (DateTime)LastRegistrationDatePicker.Value;
                Tournament.NumberOfParticipants = (int)NumberOfParticipantsComboBox.SelectedItem;
                Tournament.TournamentLevel = (ETournamentLevel)TournamentLevelsComboBox.SelectedItem;
                Tournament.Scenario = (ETournamentScenarios)TournamentScenariosComboBox.SelectedItem;

                world.TournamentsList.TriggerListChangedEvent();
            }
        }

        private bool CheckIfRequiredFieldsAreNotEmpty()
        {
            return TournamentNameTextBox.Text.Length != 0
               && StartDatePicker.Value != null
               && LastRegistrationDatePicker.Value != null;
        }
    }
}
