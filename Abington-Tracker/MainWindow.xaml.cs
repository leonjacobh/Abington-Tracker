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
using System.Data.SqlClient;
using System.Data;

namespace Abington_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<String> userPass = new List<String>();
        public String userPassRead;

        public MainWindow()
        {
            InitializeComponent();
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extension = ".txt";
            String userPassFile = filePath + @"\sTracker\Directories\user_pass" + extension;
            System.IO.StreamReader file = new System.IO.StreamReader(userPassFile);
            while ((userPassRead = file.ReadLine()) != null)
            {
                userPass.Add(userPassRead);
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (userPass.Contains(username.Text + "," + password.Password.ToString()))
            {
                Window1 mainPage = new Window1();
                mainPage.Show();
                loginPage.Close();
            }

            else
            {
                MessageBox.Show("Incorrect Username and/or Password", "Login Error");
            }


        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (userPass.Contains(username.Text + "," + password.Password.ToString()))
                {
                    Window1 mainPage = new Window1();
                    mainPage.Show();
                    loginPage.Close();
                }

                else
                {
                    MessageBox.Show("Incorrect Username and/or Password", "Login Error");
                }
            }
        }

        

        
    }
}
