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
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * You're going to need this doofus
         * check out
         * materialDesign:TextFieldAssist.Hint="WORDS"
         * 
         * UPDATE: you did it like 5 mins later lol
         */

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leon\source\repos\AbingtonTrackv2\AbingtonTrackv2\DBs\loginData.mdf;Integrated Security=True;Connect Timeout=30");
            string query = "Select * from [Table] Where username= '" + username.Text + "' and password= '" + password.Password.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtb1 = new DataTable();
            sda.Fill(dtb1);
            String currentName = username.Text;

            if (dtb1.Rows.Count == 1)
            {
                //Form2 f2 = new Form2(username.Text);
                //this.Hide();
                //f2.Show();
                MessageBox.Show("Lmao you suck penis", "america");

            }

            else
            {
                MessageBox.Show("Incorrect Username and/or Password");
            }
            
        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Leon\source\repos\AbingtonTrackv2\AbingtonTrackv2\DBs\loginData.mdf;Integrated Security=True;Connect Timeout=30");
                string query = "Select * from [Table] Where username= '" + username.Text + "' and password= '" + password.Password.ToString() + "'";
                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtb1 = new DataTable();
                sda.Fill(dtb1);
                String currentName = username.Text;

                if (dtb1.Rows.Count == 1)
                {
                    //Form2 f2 = new Form2(username.Text);
                    //this.Hide();
                    //f2.Show();
                    Window1 mainPage = new Window1();
                    mainPage.Show();
                    this.Close();

                }

                else
                {
                    MessageBox.Show("Incorrect Username and/or Password", "Login Error");
                }
            }
        }

        
    }
}
