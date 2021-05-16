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

namespace TornamentManager
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationForm.xaml
    /// </summary>
    public partial class AuthorizationForm : Window
    {
        public AuthorizationForm()
        {
            InitializeComponent();
            Confirm_lable.Opacity = 0;
            Confirm_passwordBox.Opacity = 0;
            Cancel_btn.Opacity = 0;
        }

        private void SignUp_btn_Click(object sender, RoutedEventArgs e)
        {
            Confirm_lable.Opacity = 100;
            Confirm_passwordBox.Opacity = 100;
            Password_lable.Content = "New password";
            SignIn_btn.Opacity = 0;
            Cancel_btn.Opacity = 100;
        }

        private void Cancel_btn_Click(object sender, RoutedEventArgs e)
        {
            Confirm_lable.Opacity = 0;
            Confirm_passwordBox.Opacity = 0;
            Cancel_btn.Opacity = 0;
            SignIn_btn.Opacity = 100;
        }
    }
}
