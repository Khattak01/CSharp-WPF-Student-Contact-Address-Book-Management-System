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

namespace Assignment_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Student> users = new List<Student>()
        {
            new Student("Khattak","01",//userName,password
                new List<StudentAddressBook>()//Contact of the user Khattak
                {
                    new StudentAddressBook("Khattak1","011","CIIT","CEO","khattak@gmail.com","pindi","+84","542781","assignment_2_imgs/img_2.jpg"),
                    new StudentAddressBook("Bilal1","Abbasi11","CIIT","CEO","khattak@gmail.com","Peshawar","+82","542781","assignment_2_imgs/img_3.jpg"),
                    new StudentAddressBook("Rida1","Rehan1","CIIT","CEO","khattak@gmail.com","Nowshera","+92","542781","assignment_2_imgs/img_1.jpg") 
                }),
            new Student("Bilal","Abbasi",
                new List<StudentAddressBook>()
                {
                    new StudentAddressBook("Bilal2","Abbasi2","CIIT","CEO","khattak@gmail.com","pindi","+92","542781","assignment_2_imgs/img_2.jpg"),
                    new StudentAddressBook("Rida12","Rehan2","CIIT","CEO","khattak@gmail.com","Peshawar","+82","542781","assignment_2_imgs/img_3.jpg"),
                    new StudentAddressBook("Khattak2","012","CIIT","CEO","khattak@gmail.com","Nowshera","+42","542781","assignment_2_imgs/img_1.jpg")
                }),
            new Student("Rida","Rehan",
                new List<StudentAddressBook>()
                {
                    new StudentAddressBook("Rida3","Rehan3","CIIT","CEO","khattak@gmail.com","pindi","+92","542781","assignment_2_imgs/img_2.jpg"),
                    new StudentAddressBook("Bila13","Abbasi3","CIIT","CEO","khattak@gmail.com","Peshawar","+72","542781","assignment_2_imgs/img_3.jpg"),
                    new StudentAddressBook("Khattak3","013","CIIT","CEO","khattak@gmail.com","Nowshera","+92","542781","assignment_2_imgs/img_1.jpg")
                })
        };
        public MainWindow()
        {
            InitializeComponent();
            this.mainFrame.Content = new Login();
            /*foreach (var item in users)
                Console.WriteLine(item.UserName);*/
        }
    }
}
