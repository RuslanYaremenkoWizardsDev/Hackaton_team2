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

            SetNumberOfParticipantsList();
            SetTournamentScenariosComboBoxItems();
        }
        private void TornamentModesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SetNumberOfParticipantsList();
            SetTournamentScenariosComboBoxItems();
        }

        private void StartDatePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LastRegistrationDate.Maximum = StartDatePicker.Value;
            if(StartDatePicker.Value != null && !LastRegistrationDate.IsEnabled)
            {
                LastRegistrationDate.IsEnabled = true;
            }
        }

        private void SetTournamentScenariosComboBoxItems()
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

        private void SetNumberOfParticipantsList()
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
    }
}
