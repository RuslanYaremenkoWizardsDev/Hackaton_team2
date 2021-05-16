﻿using System;
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
using TornamentManager.Tornament;

namespace TornamentManager
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class CreateTournamentForm : Window
    {
        private ObservableCollection<ETournamentModes> _modes;
        private ITournament _tournament;
        public CreateTournamentForm()
        {
            _modes = new ObservableCollection<ETournamentModes>((IEnumerable<ETournamentModes>)Enum.GetValues(typeof(ETournamentModes)));
            InitializeComponent();
            TornamentModesComboBox.ItemsSource = _modes;
            TornamentModesComboBox.SelectedItem = _modes[0];
            StartDatePicker.Minimum = DateTime.Now;
        }

        private void StartDatePicker_ValueChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            LastRegistrationDatePicker.Maximum = StartDatePicker.Value;
        }

        private void BtnCreateTournament_Click(object sender, RoutedEventArgs e)
        {
            if (TornamentModesComboBox.Text == "Cup")
            {
                _tournament = new TournamentCup(TournamentName.Text, ETournamentModes.Cup, 32);
            }
            else if (TornamentModesComboBox.Text == "Championship")
            {
                _tournament = new TournamentChampionship(TournamentName.Text, ETournamentModes.Championship, 10);
            }

            _tournament.Description = TournamentDescription.Text;
            _tournament.Place = TournamentPlace.Text;
            _tournament.StartDateTime = (DateTime)StartDatePicker.Value;
            _tournament.LastRegistrationDateTime = (DateTime)LastRegistrationDatePicker.Value;
        }
    }
}
