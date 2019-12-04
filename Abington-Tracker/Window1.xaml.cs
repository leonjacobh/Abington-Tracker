using System;
using System.Collections.Generic;
//Github working
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


namespace Abington_Tracker
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        //name to user list
        List<String> nameUser = new List<String>();
        public String nameUserRead;

        //user and grade
        List<String> userGrade = new List<String>();
        public String userGradeRead;

        //user and hours
        List<String> userHours = new List<String>();
        public String userHoursRead;

        //users and awards
        List<String> userAwards = new List<String>();
        public String userAwardsRead;
        
        //last user hour updates list
        List<String> hourUpdates = new List<String>();
        public String hourUpdatesRead;

        //last user award updates list
        List<String> awardUpdates = new List<String>();
        public String awardUpdatesRead;

        public String currentStudentName;
        public String currentStudentUser;


        public Window1()
        {
            InitializeComponent();

            //import which names equal which usernames
            System.IO.StreamReader nameText = new System.IO.StreamReader(@"C:\Users\Leon\Desktop\sTracker\Directories\name_user.txt");
            while ((nameUserRead = nameText.ReadLine()) != null)
            {
                nameUser.Add(nameUserRead);
            }

            //import user and grade
            System.IO.StreamReader userGradeText = new System.IO.StreamReader(@"C:\Users\Leon\Desktop\sTracker\Directories\user_grade.txt");
            while ((userGradeRead = userGradeText.ReadLine()) != null)
            {
                userGrade.Add(userGradeRead);
            }

            //import user and hours
            System.IO.StreamReader userHoursText = new System.IO.StreamReader(@"C:\Users\Leon\Desktop\sTracker\Directories\user_hours.txt");
            while ((userHoursRead = userHoursText.ReadLine()) != null)
            {
                userHours.Add(userHoursRead);
            }

            //import user and awards
            System.IO.StreamReader userAwardsText = new System.IO.StreamReader(@"C:\Users\Leon\Desktop\sTracker\Directories\user_award1_award2_award3.txt");
            while ((userAwardsRead = userAwardsText.ReadLine()) != null)
            {
                userAwards.Add(userAwardsRead);
            }

            //import user and last time the awards were updated
            System.IO.StreamReader hourUpdateText = new System.IO.StreamReader(@"C:\Users\Leon\Desktop\sTracker\Directories\user_hour_lastupdate.txt");
            while ((hourUpdatesRead = hourUpdateText.ReadLine()) != null)
            {
                hourUpdates.Add(hourUpdatesRead);
            }

            //import user and last time the hours were updated
            System.IO.StreamReader awardUpdateText = new System.IO.StreamReader(@"C:\Users\Leon\Desktop\sTracker\Directories\user_award_lastupdate.txt");
            while ((awardUpdatesRead = awardUpdateText.ReadLine()) != null)
            {
                awardUpdates.Add(awardUpdatesRead);
            }
        }

        /*
         * Console.WriteLine(DateTime.Now.ToString("M/d/yyyy"));
         * Console.WriteLine(datePicked.SelectedDate.Value.Date.ToShortDateString());
        */

        private void UpdateObjs_Click(object sender, RoutedEventArgs e)
        {
            createObjs.Visibility = Visibility.Collapsed;
            //random.Visibility = Visibility.Visible;
        }

        //DatePicker.SelectedDate.Value.Date.ToShortDateString()
        private void CreateObjs_Click(object sender, RoutedEventArgs e)
        {
            updateObjs.Visibility = Visibility.Collapsed;
        }

        private void ResetObjs_Click(object sender, RoutedEventArgs e)
        {
            createObjs.Visibility = Visibility.Visible;
            updateObjs.Visibility = Visibility.Visible;
        }

        private void Grid_GotMouseCapture(object sender, MouseEventArgs e)
        {
            // I know this works now random.Visibility = Visibility.Collapsed;
        }

        
        private void HourSearch_Click(object sender, RoutedEventArgs e)
        {
            currentStudentName = hourSeachStudent.Text;
            Console.WriteLine("We Hit Here 1");
            if (hourSearchReq.Text.Equals("Full Name"))
            {
                foreach (String x in nameUser)
                {
                    Console.WriteLine("We Hit Here 2");
                    if (x.Contains(currentStudentName))
                    {
                        Console.WriteLine("We Hit Here 3");
                        currentStudentUser = x.Substring(x.IndexOf(",") + 1);
                        Console.WriteLine(currentStudentUser);
                    }
                }
            }
            else
            {
                currentStudentUser = hourSeachStudent.Text;
            }
        }

        private void AddHoursButton_Click(object sender, RoutedEventArgs e)
        {
            int numAdd = Int32.Parse(hoursToAdd.Text);
            Console.WriteLine(numAdd);
        }
    }
}
