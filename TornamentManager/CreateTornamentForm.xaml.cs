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
            LastRegistrationDate.Maximum = StartDatePicker.Value;
        }
    }
}
