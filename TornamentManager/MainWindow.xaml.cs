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
        public bool isPassChange = false;

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

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            MainForm.Hide();
            authorizationForm.Show();
        }

        private void ChangePassButton_Click(object sender, RoutedEventArgs e)
        {
            isPassChange = true;
            MainForm.Visibility=Visibility.Hidden;
            authorizationForm = new AuthorizationForm();
            authorizationForm.MainWindow = this;
            authorizationForm.Show();
            authorizationForm.Name_label.Content = "Changing Password";
            authorizationForm.Confirm_lable.Opacity = 100;
            authorizationForm.Confirm_passwordBox.Opacity = 100;
            authorizationForm.OldPass_label.Opacity = 100;
            authorizationForm.OldPass_passwordBox.Opacity = 100;
            authorizationForm.SignIn_btn.Opacity = 0;
            authorizationForm.SignUp_btn.Opacity = 0;
            authorizationForm.Change_btn.Opacity = 100;
            authorizationForm.Cancel_btn.Opacity = 100;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ITeamClass participant = new TeamClass(ParticipantNameTextBox.Text);
            ITeamDictionary teamDictionary = new TeamDictionary();
            //teamDictionary.TeamList.Add(participant);
        }
    }
}
