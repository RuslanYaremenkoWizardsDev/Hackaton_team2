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
    public partial class CreateTournamentForm : Window
    {
        private ObservableCollection<ETournamentModes> _modes;
        private ObservableCollection<ETournamentLevel> _levels;

        public CreateTournamentForm()
        {
            _modes = new ObservableCollection<ETournamentModes>((IEnumerable<ETournamentModes>)Enum.GetValues(typeof(ETournamentModes)));
            _levels = new ObservableCollection<ETournamentLevel>((IEnumerable<ETournamentLevel>)Enum.GetValues(typeof(ETournamentLevel)));

            InitializeComponent();
            TornamentModesComboBox.ItemsSource = _modes;
            TornamentModesComboBox.SelectedItem = _modes[0];

            TournamentLevelsComboBox.ItemsSource = _levels;
            TournamentLevelsComboBox.SelectedItem = _levels[1];
            StartDatePicker.Minimum = DateTime.Now;

            ObservableCollection<int> numberOfParticipants;
            numberOfParticipants = Get_NumberOfParticipantsList();
            NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;
            NumberOfParticipantsComboBox.SelectedItem = numberOfParticipants[numberOfParticipants.Count - 1];

            ObservableCollection<ETournamentScenarios> scenarios = GetTournamentScenariosComboBoxItems();
            TournamentScenariosComboBox.ItemsSource = scenarios;
            TournamentScenariosComboBox.SelectedItem = scenarios[0];
        }
        private void TornamentModesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ObservableCollection<int> numberOfParticipants;
            numberOfParticipants = Get_NumberOfParticipantsList();
            NumberOfParticipantsComboBox.ItemsSource = numberOfParticipants;
            NumberOfParticipantsComboBox.SelectedItem = numberOfParticipants[numberOfParticipants.Count - 1];

            ObservableCollection<ETournamentScenarios> scenarios = GetTournamentScenariosComboBoxItems();

            TournamentScenariosComboBox.ItemsSource = scenarios;
            TournamentScenariosComboBox.SelectedItem = scenarios[0];
        }

        private void StartDatePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LastRegistrationDate.Maximum = StartDatePicker.Value;
        }

        private ObservableCollection<ETournamentScenarios> GetTournamentScenariosComboBoxItems()
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
            
            return scenarios;
        }

        private ObservableCollection<int> Get_NumberOfParticipantsList()
        {
            ObservableCollection<int> numberOfParticipants = new ObservableCollection<int>();
            switch (TornamentModesComboBox.SelectedIndex)
            {
                case 0:
                    numberOfParticipants.Add(4);
                    numberOfParticipants.Add(8);
                    numberOfParticipants.Add(16);
                    numberOfParticipants.Add(32);
                    numberOfParticipants.Add(64);
                    numberOfParticipants.Add(128);
                    break;
                case 1:

                    for (int i = 1; i <= 10; ++i)
                    {
                        numberOfParticipants.Add(i);
                    }

                    break;
            }

            return numberOfParticipants;
        }
    }
}
