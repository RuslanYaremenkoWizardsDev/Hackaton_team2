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
using System.Windows.Shapes;
using TornamentManager.AutorizationLogic;
using TornamentManager.Tornament;


namespace TornamentManager 
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationForm.xaml
    /// </summary>

    public partial class AuthorizationForm : Window
    {
        Autorization autorization = new Autorization();
        bool _isBtnSignUpPressed = false;
        public MainWindow MainWindow;
        public IActiveUser ActiveUser { get; private set; }

        public AuthorizationForm()
        {
            InitializeComponent();
            Confirm_lable.Opacity = 0;
            Confirm_passwordBox.Opacity = 0;
            Cancel_btn.Opacity = 0;
            OldPass_label.Opacity = 0;
            OldPass_passwordBox.Opacity = 0;
            Change_btn.Opacity = 0;
        }

        private void SignUp_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!_isBtnSignUpPressed)
            {
                Confirm_lable.Opacity = 100;
                Confirm_passwordBox.Opacity = 100;
                Password_lable.Content = "Password";
                SignIn_btn.Opacity = 0;
                Cancel_btn.Opacity = 100;
                Name_label.Content = "Singing Up";
                Login_textBox.Background = Brushes.White;
                Password_passwordBox.Background = Brushes.White;
                Confirm_passwordBox.Background = Brushes.White;
            }
            else
            {
                if (!autorization.validateLogin(Login_textBox.Text))
                {
                    Login_textBox.Background = Brushes.Red;
                }
                else if (autorization.validateLogin(Login_textBox.Text))
                {
                    Login_textBox.Background = Brushes.White;
                }
                if(!autorization.validatePassword(Password_passwordBox.Password))
                {
                    Password_passwordBox.Background = Brushes.Red;
                }
                else if (autorization.validatePassword(Password_passwordBox.Password))
                {
                    Password_passwordBox.Background = Brushes.White;
                }
                if (Password_passwordBox.Password != Confirm_passwordBox.Password)
                {
                    Confirm_passwordBox.Background = Brushes.Red;
                }
                else if (Password_passwordBox.Password == Confirm_passwordBox.Password)
                {
                    Confirm_passwordBox.Background = Brushes.White;
                }
                if(autorization.validateLogin(Login_textBox.Text) && autorization.validatePassword(Password_passwordBox.Password) && Password_passwordBox.Password == Confirm_passwordBox.Password)
                {
                    autorization.CreateUser(Login_textBox.Text, Password_passwordBox.Password, EUserPrivileges.Admin);
                    Login_textBox.Text = null;
                    Password_passwordBox.Password = null;
                    Confirm_passwordBox.Password = null;
                    Password_passwordBox.Background = Brushes.White;
                    Confirm_passwordBox.Background = Brushes.White;
                    OldPass_passwordBox.Background = Brushes.White;
                    Cancel_btn_Click(sender, e);
                }   
            }
            _isBtnSignUpPressed = true;
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            _isBtnSignUpPressed = false;
            Confirm_lable.Opacity = 0;
            Confirm_passwordBox.Opacity = 0;
            Cancel_btn.Opacity = 0;
            SignIn_btn.Opacity = 100;
            Password_lable.Content = "Password";
            Name_label.Content = "Authorization";
            Login_textBox.Text = null;
            Password_passwordBox.Password = null;
            Confirm_passwordBox.Password = null;
            OldPass_passwordBox.Password = null;
            Login_textBox.Background = Brushes.White;
            Password_passwordBox.Background = Brushes.White;
            Confirm_passwordBox.Background = Brushes.White;
            OldPass_passwordBox.Background = Brushes.White;
        }

        private void Change_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SignIn_btn_Click(object sender, RoutedEventArgs e)
        {
            if (!autorization.validateLogin(Login_textBox.Text))
            {
                Login_textBox.Background = Brushes.Red;
            }
            else if (autorization.validateLogin(Login_textBox.Text))
            {
                Login_textBox.Background = Brushes.White;
            }
            if (!autorization.validatePassword(Password_passwordBox.Password))
            {
                Password_passwordBox.Background = Brushes.Red;
            }
            else if (autorization.validatePassword(Password_passwordBox.Password))
            {
                Password_passwordBox.Background = Brushes.White;
            }
            if (autorization.validateLogin(Login_textBox.Text) && autorization.validatePassword(Password_passwordBox.Password) )
            {
                ActiveUser =  autorization.AutorizeUser(Login_textBox.Text, Password_passwordBox.Password);
                if (ActiveUser==null)
                {
                    Password_passwordBox.Background = Brushes.Red;
                    Login_textBox.Background = Brushes.Red;
                }
                else
                {
                    Login_textBox.Text = null;
                    Password_passwordBox.Password = null;
                    Password_passwordBox.Background = Brushes.White;
                    Confirm_passwordBox.Background = Brushes.White;
                    this.Hide();
                    MainWindow.Show();
                }

                
                
                
            }
        }
    }
}
