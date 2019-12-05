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
using System.Windows.Media.Animation;
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

        public String userGradePath;
        public String userHoursPath;
        public String userAwardsPath;
        public String userHourUpdatePath;
        public String userAwardsUpdatePath;

        DatabaseUpdater helper = new DatabaseUpdater();

        //Populates all lists with respective data
        public Window1()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extension = ".txt";
            String nameUserFile = filePath + @"\sTracker\Directories\name_user" + extension;
            userGradePath = filePath + @"\sTracker\Directories\user_grade" + extension;
            userHoursPath = filePath + @"\sTracker\Directories\user_hours" + extension;
            userAwardsPath = filePath + @"\sTracker\Directories\user_award1_award2_award3" + extension;
            userHourUpdatePath = filePath + @"\sTracker\Directories\user_hour_lastupdate" + extension; 
            userAwardsUpdatePath = filePath + @"\sTracker\Directories\user_award_lastupdate" + extension;

            //import which names equal which usernames
            System.IO.StreamReader nameText = new System.IO.StreamReader(nameUserFile);
            while ((nameUserRead = nameText.ReadLine()) != null)
            {
                nameUser.Add(nameUserRead);
            }

            //import user and grade
            System.IO.StreamReader userGradeText = new System.IO.StreamReader(userGradePath);
            while ((userGradeRead = userGradeText.ReadLine()) != null)
            {
                userGrade.Add(userGradeRead);
            }

            //import user and hours
            System.IO.StreamReader userHoursText = new System.IO.StreamReader(userHoursPath);
            while ((userHoursRead = userHoursText.ReadLine()) != null)
            {
                userHours.Add(userHoursRead);
            }

            //import user and awards
            System.IO.StreamReader userAwardsText = new System.IO.StreamReader(userAwardsPath);
            while ((userAwardsRead = userAwardsText.ReadLine()) != null)
            {
                userAwards.Add(userAwardsRead);
            }

            //import user and last time the awards were updated
            System.IO.StreamReader hourUpdateText = new System.IO.StreamReader(userHourUpdatePath);
            while ((hourUpdatesRead = hourUpdateText.ReadLine()) != null)
            {
                hourUpdates.Add(hourUpdatesRead);
            }

            //import user and last time the hours were updated
            System.IO.StreamReader awardUpdateText = new System.IO.StreamReader(userAwardsUpdatePath);
            while ((awardUpdatesRead = awardUpdateText.ReadLine()) != null)
            {
                awardUpdates.Add(awardUpdatesRead);
            }
        }

        /*
         * Console.WriteLine(DateTime.Now.ToString("M/d/yyyy"));
         * Console.WriteLine(datePicked.SelectedDate.Value.Date.ToShortDateString());
        */

        /* 
         * Searches For the user
         * If given a name, converts to user numeral id
         */

        //Ask Daub if I should just remove options all together
         
        private void HourSearch_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("We Hit Here 1");
            if (hourSearchReq.Text.Equals("Full Name") || hourSearchReq.Text.Equals("Student ID"))
            {
                foreach (String x in nameUser)
                {
                    Console.WriteLine("We Hit Here 2");
                    if (x.Contains(hourSeachStudent.Text))
                    {
                        Console.WriteLine("We Hit Here 3");
                        currentStudentUser = x.Substring(x.IndexOf(",") + 1);
                        Console.WriteLine(currentStudentUser);
                        DisplayStudentData();

                        ((Storyboard)FindResource("animate")).Begin(userFound);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Select Search Type (Student ID or Full Name)", "User Entry Error");
            }
            
        }

        private void AddHoursButton_Click(object sender, RoutedEventArgs e)
        {
            if (hoursToAdd.Text.Length > 0 && hoursToAdd.Text.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) == -1)
            {
                int numAdd = Int32.Parse(hoursToAdd.Text);
                int added = 0;
                Console.WriteLine(numAdd);
                Console.WriteLine("before loop");
                for (int i = 0; i < userHours.Count; i++)
                {
                    Console.WriteLine("loop started");
                    if (currentStudentUser != null)
                    {
                        if (userHours[i].Contains(currentStudentUser))
                        {
                            Console.WriteLine("if hit");
                            String curHours = userHours[i].Substring(userHours[i].IndexOf(",") + 1);
                            int curHrs = Int32.Parse(curHours);
                            added = numAdd + curHrs;
                            userHours[i] = currentStudentUser + "," + added;
                            Console.WriteLine(userHours[i]);
                            helper.userDataUpdater(userHours, userHoursPath);
                            ((Storyboard)FindResource("animate")).Begin(hoursAdded);
                        }
                    }
                    else
                    {
                        MessageBox.Show("You Must First Search For A Student Which You'd Like To Add Hours To", "User Error Entry");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please Enter A Numeric Quntity", "User Error Entry");
            }
        }

        private void DisplayStudentData()
        {
            helper.hasCommunityAward(userAwards, currentStudentUser);
            helper.hasServiceAward(userAwards,currentStudentUser);
            helper.hasAchievementAward(userAwards,currentStudentUser);
            
            studentFullNameDisplay.Text = "Student's Full Name: " + helper.userToName(nameUser, currentStudentUser);
            studentUserIDDisplay.Text = "Student's User ID: " + currentStudentUser;
            studentHoursDisplay.Text = "Student's Current Hours: ";
            studentGradeDisplay.Text = "Student's Current Grade: " + helper.getUserGrade(userGrade, currentStudentUser);
            studentAward1Display.Text = "Student's CSA Community Status: " + helper.hasCommunityAward(userAwards, currentStudentUser);
            studentAward2Display.Text = "Student's CSA Service Status: " + helper.hasServiceAward(userAwards, currentStudentUser);
            studentAward3Display.Text = "Student's CSA Achievement Status: " + helper.hasAchievementAward(userAwards, currentStudentUser);
        }
    }
}
