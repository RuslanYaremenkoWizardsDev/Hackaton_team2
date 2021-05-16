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
        public MainWindow()
        {
            InitializeComponent();
            World.WorldInstance.TournamentsList.TournamentListChanged += TournamentsList_TournamentListChanged;
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ITeamClass participant = new TeamClass(ParticipantNameTextBox.Text);
            ITeamDictionary teamDictionary = new TeamDictionary();
            teamDictionary.TeamList.Add(participant);
            

        }
    }
}
