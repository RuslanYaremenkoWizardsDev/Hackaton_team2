using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TornamentManager.Tornament;

namespace TornamentManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool _isAutorizationStarted = false;
        AuthorizationForm authorizationForm = new AuthorizationForm();
        

        public MainWindow()
        {
            InitializeComponent();
            World.WorldInstance.TournamentsList.TournamentListChanged += TournamentsList_TournamentListChanged;

            authorizationForm.MainWindow = this;
            if (!_isAutorizationStarted)
            {
                MainForm.Hide();
                authorizationForm.Show();
            }
            _isAutorizationStarted = true;
        }

        private void TournamentsList_TournamentListChanged()
        {
            TornamentsList.Children.Clear();
            foreach (var tourn in World.WorldInstance.TournamentsList)
            {
                TournamentBox tournamentBox = new TournamentBox(tourn);
                TornamentsList.Children.Add(tournamentBox);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CreateTournamentForm createTornamentForm = new CreateTournamentForm();
            createTornamentForm.Show();
        }
    }
}
