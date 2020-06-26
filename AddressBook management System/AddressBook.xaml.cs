using Microsoft.Win32;
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
    /// Interaction logic for AddressBook.xaml
    /// </summary>
    public partial class AddressBook : Page
    {
        public static int photoUriIndex = 0;
        public static List<StudentAddressBook> list = new List<StudentAddressBook>();
        public AddressBook()
        {
            InitializeComponent();
            setListBox(list);
        }
        public void setListBox(List<StudentAddressBook> li)
        {
            this.listBox.ItemsSource = null;
            foreach (var itm in li)
                this.listBox.Items.Add(itm);
            //this.listBox.ItemsSource = li;
            this.listBox.Items.Refresh();
        }

        private void btn_return_Click(object sender, RoutedEventArgs e)
        {
            var window = (MainWindow)Application.Current.MainWindow;
            window.Height = 500;
            window.Width = 800;
            window.mainFrame.Height = 409;
            window.mainFrame.Content = new Login();
        }

        private void btn_clear_Click(object sender, RoutedEventArgs e)
        {
            if (!this.checkFields())
                return;
            this.txtBox_lastName.Clear();
            this.txtBox_firstName.Clear();
            this.txtBox_company.Clear();
            this.txtBox_address.Clear();
            this.txtBox_jobTitle.Clear();
            this.txtBox_email.Clear();
            this.txtBox_ph.Clear();
            this.txtBox_phCountryCode.Clear();
            this.img_user.Source = null;
            //this.listBox_data.SelectedIndex = -1;
            this.listBox.UnselectAll();
        }
        private bool checkFields()
        {
            bool rtn = true;
            if (this.txtBox_firstName.Text == "")
                rtn = false;
            else if (this.txtBox_lastName.Text == "")
                rtn = false;
            else if (this.txtBox_company.Text == "")
                rtn = false;
            else if (this.txtBox_address.Text == "")
                rtn = false;
            else if (this.txtBox_jobTitle.Text == "")
                rtn = false;
            else if (this.txtBox_email.Text == "")
                rtn = false;
            else if (this.txtBox_phCountryCode.Text == "")
                rtn = false;
            else if (this.txtBox_ph.Text == "")
                rtn = false;
            return rtn;
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (!this.checkFields())
                return;
            //this.listBox.ItemsSource = null;
            StudentAddressBook obj = new StudentAddressBook(this.txtBox_firstName.Text, this.txtBox_lastName.Text, this.txtBox_company.Text,
                this.txtBox_jobTitle.Text, this.txtBox_email.Text, this.txtBox_address.Text,this.txtBox_phCountryCode.Text,this.txtBox_ph.Text,this.txtBox_photoAddress.Text); 
            this.listBox.Items.Add(obj);
            //this.listBox.Items.Remove();
            AddressBook.list.Add(obj);
            this.listBox.Items.Refresh();
            MessageBox.Show("Successfully ADDED");
        }

        private void btn_search_Click(object sender, RoutedEventArgs e)//search on btn_search click
        {
            search();
        }
        private void search()//search methode for contactList
        {
            this.listBox.UnselectAll();
            //MessageBox.Show(listBox.Items.Count+"");
            for (int i = 0; i < listBox.Items.Count; i++)
            {
                if (separatorStudentBook(listBox.Items[i]).FirstName.ToLower().Contains(this.txtBox_search.Text.ToLower()) || 
                    separatorStudentBook(listBox.Items[i]).LastName.ToLower().Contains(this.txtBox_search.Text.ToLower()))
                {
                    listBox.SelectedItem = listBox.Items.GetItemAt(i);// get the index of the search item and set as selected in listBox
                    photoUriIndex = i;
                    this.lbl_sts.Content = this.txtBox_search.Text + " found at index " + i;
                    if (this.txtBox_search.Text == "")
                    {
                        this.lbl_sts.Content = "-";
                        this.listBox.UnselectAll();
                    }
                    return;
                }
                else
                {
                    this.lbl_sts.Content = this.txtBox_search.Text + " Not found";
                    this.listBox.UnselectAll();
                }
            }
        }
        private StudentAddressBook separatorStudentBook(object col)
        {
            string[] temp = col.ToString().Split(" ");
            //MessageBox.Show(temp.Length+"");
            return new StudentAddressBook(temp[0],temp[1],temp[2],temp[3],temp[4],temp[5], temp[6], temp[7],temp[8]);
        }

        private void txtBox_search_TextChanged(object sender, TextChangedEventArgs e)//search on change in txt_search textBox
        {
            search();
        }

        private void btn_update_Click(object sender, RoutedEventArgs e)
        {
            if (!this.checkFields())
                return;
            StudentAddressBook obj = (StudentAddressBook)this.listBox.SelectedItem;
            obj.FirstName = this.txtBox_firstName.Text;
            obj.LastName = this.txtBox_lastName.Text;
            obj.CompanyName = this.txtBox_company.Text;
            obj.JobTitle = this.txtBox_jobTitle.Text;
            obj.Email = this.txtBox_email.Text;
            obj.Address = this.txtBox_address.Text;
            obj.CountryCode = this.txtBox_phCountryCode.Text;
            obj.PhNumber = this.txtBox_ph.Text;
            obj.Photo = this.txtBox_photoAddress.Text;
            this.img_user.Source = null;
            this.listBox.Items.Refresh();
            MessageBox.Show("Successfully UPDATED");
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show(list.Count + "");
            if (this.listBox.SelectedItem == null)
                return;
            list.Remove((StudentAddressBook)this.listBox.SelectedItem);
            //Console.WriteLine(list.Count+"");
            this.listBox.Items.Remove(this.listBox.SelectedItem);
            this.img_user.Source = null;
            this.listBox.Items.Refresh();
            MessageBox.Show("Successfully DELETED");
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.listBox.SelectedItem == null)
                return;
            //MessageBox.Show((@"" + separatorStudentBook(this.listBox.SelectedItem).Photo));
            this.img_user.Source = new BitmapImage(new Uri((@""+ separatorStudentBook(this.listBox.SelectedItem).Photo), UriKind.Relative));
        }
    }
}
