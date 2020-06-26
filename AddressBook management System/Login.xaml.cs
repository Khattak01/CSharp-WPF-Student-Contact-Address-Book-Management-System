using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            if (auth(this.txtBox_name.Text, this.txtBox_password.Text))
            {
                MessageBox.Show("Successfully LOGIN", "LOGIN");
                var window = (MainWindow)Application.Current.MainWindow;
                window.Height = 800;
                window.Width = 900;
                window.mainFrame.Height = 709;
                window.mainFrame.Width = 900;
                window.mainFrame.Content = new AddressBook();
                return;
            }
            MessageBox.Show("Unauthenticated USER", "!LOGIN");
        }
        private bool auth(string name, string pass)
        {
            bool res = false;
            for (int i = 0; i < MainWindow.users.Count; i++)
            {
                //MessageBox.Show(item.Address);
                res = (MainWindow.users[i].UserName.Equals(this.txtBox_name.Text) && MainWindow.users[i].Password.Equals(this.txtBox_password.Text)) ? true : false;
                if (res)
                {
                    //MessageBox.Show(MainWindow.users[i].dataList[0].FirstName);
                    AddressBook.list = MainWindow.users[i].dataList;
                    break;
                }
            }
            /*foreach (var item in MainWindow.users) 
                return item.UserName.Equals(this.txtBox_name.Text) && item.Password.Equals(this.txtBox_password.Text) ? true : false ;*/
            return res;
        }
    }
}
