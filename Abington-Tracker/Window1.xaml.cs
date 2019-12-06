﻿using System;
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

        public String nameUserPath;
        public String userGradePath;
        public String userHoursPath;
        public String userAwardsPath;
        public String userHourUpdatePath;
        public String userAwardsUpdatePath;

        public String hasCommunity = "nnnnnnnnnn";
        public String hasService = "nnnnnnnnnn";
        public String hasAchievement = "nnnnnnnnnnnnnn";

        public String previousUser;

        DatabaseUpdater helper = new DatabaseUpdater();

        //Populates all lists with respective data
        public Window1()
        {
            DataContext = new MainWindowViewModel();
            InitializeComponent();

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string extension = ".txt";
            nameUserPath = filePath + @"\sTracker\Directories\name_user" + extension;
            userGradePath = filePath + @"\sTracker\Directories\user_grade" + extension;
            userHoursPath = filePath + @"\sTracker\Directories\user_hours" + extension;
            userAwardsPath = filePath + @"\sTracker\Directories\user_award1_award2_award3" + extension;
            userHourUpdatePath = filePath + @"\sTracker\Directories\user_hour_lastupdate" + extension; 
            userAwardsUpdatePath = filePath + @"\sTracker\Directories\user_award_lastupdate" + extension;

            //import which names equal which usernames
            System.IO.StreamReader nameText = new System.IO.StreamReader(nameUserPath);
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
                    String xLower = x.ToLower();
                    String grabLower = hourSeachStudent.Text.ToLower();
                    if (x.Contains(hourSeachStudent.Text) || xLower.Contains(grabLower))
                    {
                        Console.WriteLine("We Hit Here 3");
                        currentStudentUser = x.Substring(x.IndexOf(",") + 1);
                        Console.WriteLine(currentStudentUser);
                        DisplayStudentData();

                        ((Storyboard)FindResource("animate")).Begin(userFound);
                    }
                }
                hourSeachStudent.Clear();
                hourSearchReq.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select search type (Student ID or Full Name)", "User Entry Error");
            }
            
        }

        public void loadCurrentData(String userID)
        {
            updateStudentsUser.Text = userID;
            foreach (String x in userHours)
            {
                if (x.Contains(userID))
                {
                    updateStudentsHours.Text = x.Substring(x.IndexOf(",") + 1);
                    
                }
            }

            foreach (String x in nameUser)
            {
                if (x.Contains(userID))
                {
                    updateStudentsFirstName.Text = x.Substring(0, x.IndexOf(" "));
                    updateStudentsLastName.Text = x.Substring(x.IndexOf(" ")+1, x.IndexOf(",") - currentStudentUser.Length);
                    if (updateStudentsLastName.Text.Contains(","))
                    {
                        String p = updateStudentsLastName.Text;
                        p = p.Substring(0, p.IndexOf(","));
                        updateStudentsLastName.Text = p;
                    }
                }
            }

            foreach (String x in userGrade)
            {
                if (x.Contains(userID))
                {
                    if (x.Substring(x.IndexOf(",") + 1).Equals("9t"))
                    {
                        updateStudentGrade.SelectedIndex = 0;
                    }
                    else if (x.Substring(x.IndexOf(",") + 1).Equals("10"))
                    {
                        updateStudentGrade.SelectedIndex = 1;
                    }
                    else if (x.Substring(x.IndexOf(",") + 1).Equals("11"))
                    {
                        updateStudentGrade.SelectedIndex = 2;
                    }
                    else if (x.Substring(x.IndexOf(",") + 1).Equals("12"))
                    {
                        updateStudentGrade.SelectedIndex = 3;
                    }
                }
            }

            foreach (String x in userAwards)
            {
                if (x.Contains(userID))
                {
                    if (x.IndexOf("csacommunity") > 0)
                    {
                        updateCommunityAward.IsChecked = true;
                    }
                    if (x.IndexOf("csaservice") > 0)
                    {
                        updateServiceAward.IsChecked = true;
                    }
                    if (x.IndexOf("csaachievement") > 0)
                    {
                        updateAchievementAward.IsChecked = true;
                    }
                }
            }
        }

        private void UpdateSearch_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("We Hit Here 1");
            if (updateSearchReq.Text.Equals("Full Name") || updateSearchReq.Text.Equals("Student ID"))
            {
                foreach (String x in nameUser)
                {
                    Console.WriteLine("We Hit Here 2");
                    String xLower = x.ToLower();
                    String grabLower = updateSeachStudent.Text.ToLower();
                    if (x.Contains(updateSeachStudent.Text) || xLower.Contains(grabLower))
                    {
                        Console.WriteLine("We Hit Here 3");
                        currentStudentUser = x.Substring(x.IndexOf(",") + 1);
                        Console.WriteLine(currentStudentUser);
                        loadCurrentData(currentStudentUser);
                        previousUser = currentStudentUser;
                        ((Storyboard)FindResource("animate")).Begin(updateUserFound);
                    }
                }
                hourSeachStudent.Clear();
                hourSearchReq.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Please select search type (Student ID or Full Name)", "User Entry Error");
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
                            DisplayStudentData();
                            ((Storyboard)FindResource("animate")).Begin(hoursAdded);
                            hoursToAdd.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("You must first search for a student which you'd like to add hours to.", "User Error Entry");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter a numeric quantity.", "User Error Entry");
            }
        }

        private void DisplayStudentData()
        {
            helper.hasCommunityAward(userAwards, currentStudentUser);
            helper.hasServiceAward(userAwards,currentStudentUser);
            helper.hasAchievementAward(userAwards,currentStudentUser);

            String gradeStr = helper.getUserGrade(userGrade, currentStudentUser);
            if (gradeStr.Contains("t")) { gradeStr = gradeStr.Substring(0, 1); }

            studentFullNameDisplay.Text = "Student's Full Name: " + helper.userToName(nameUser, currentStudentUser);
            studentUserIDDisplay.Text = "Student's User ID: " + currentStudentUser;
            studentHoursDisplay.Text = "Student's Current Hours: " + helper.getUserHours(userHours, currentStudentUser);
            studentGradeDisplay.Text = "Student's Current Grade: " + gradeStr;
            studentAward1Display.Text = "CSA Community Status: " + helper.hasCommunityAward(userAwards, currentStudentUser);
            studentAward2Display.Text = "CSA Service Status: " + helper.hasServiceAward(userAwards, currentStudentUser);
            studentAward3Display.Text = "CSA Achievement Status: " + helper.hasAchievementAward(userAwards, currentStudentUser);
        }

        private void resetAwardStrings()
        {
            hasCommunity = "nnnnnnnnnn";
            hasService = "nnnnnnnnnn";
            hasAchievement = "nnnnnnnnnnnnnn";
        }

        private void setStringsn()
        {
            hasCommunity = "nnnnnnnnnn";
            hasService = "nnnnnnnnnn";
            hasAchievement = "nnnnnnnnnnnnnn";
        }

        private void CreateStudentButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (createFirstName.Text.Length > 0 && createLastName.Text.Length > 0 && createUserID.Text.Length > 0 && createStudentGrade.SelectedIndex != -1) 
            {
                if (helper.originalUserID(nameUser, createUserID.Text))
                {
                    if (createHours.Text.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) == -1)
                    {
                        String fixedGrade = (String)createStudentGrade.SelectedValue.ToString();
                        fixedGrade = fixedGrade.Substring(fixedGrade.IndexOf(":") + 2, fixedGrade.IndexOf("t") - 1);
                        String namePlusUser = createFirstName.Text.Trim() + " " + createLastName.Text.Trim() + "," + createUserID.Text;
                        String userPlusHours = createUserID.Text + "," + createHours.Text;
                        String userPlusGrade = createUserID.Text + "," + fixedGrade;


                        if (true)
                        {
                            hasCommunity = "nnnnnnnnnn";
                            hasService = "nnnnnnnnnn";
                            hasAchievement = "nnnnnnnnnnnnnn";
                            if (createCommunityAward.IsChecked ?? false)
                            {
                                hasCommunity = "csacommunity";
                            }
                            if (createServiceAward.IsChecked ?? false)
                            {
                                hasService = "csaservice";
                            }
                            if (createAchievementAward.IsChecked ?? false)
                            {
                                hasAchievement = "csaachievement";
                            }
                        }

                        String userPlusAwards = createUserID + "," + hasCommunity + "," + hasService + "," + hasAchievement;
                        userPlusAwards = userPlusAwards.Substring(userPlusAwards.IndexOf(": ")+2);

                        

                        nameUser.Add(namePlusUser);
                        helper.createNameUser(nameUser, namePlusUser, nameUserPath);
                        userHours.Add(userPlusHours);
                        helper.createUserHours(userHours, userPlusHours, userHoursPath);
                        userGrade.Add(userPlusGrade);
                        helper.createUserGrade(userGrade, userPlusGrade, userGradePath);
                        userAwards.Add(userPlusAwards);
                        helper.createUserAwards(userAwards, userPlusAwards, userAwardsPath);
                        ((Storyboard)FindResource("animate")).Begin(createSuccessful);

                        createAchievementAward.IsChecked = false;
                        createServiceAward.IsChecked = false;
                        createCommunityAward.IsChecked = false;


                        createFirstName.Clear();
                        createLastName.Clear();
                        createUserID.Clear();
                        createHours.Clear();
                        createStudentGrade.SelectedIndex = -1;
                        

                    }
                    else
                    {
                        MessageBox.Show("Error: Hours must be entered as a numeric quantity, not characters", "User Entry Error");
                    }
                }
                else
                {
                    MessageBox.Show("Error: Unique student user ID already exists. If this is a different person use a different ID. If this is the same person, try updating the student profile", "User Entry Error");
                }
                
            }
            else
            {
                MessageBox.Show("Error: Some field was left empty.", "User Entry Error");
            }
        }

        private void UpdateStudentButton_Click(object sender, RoutedEventArgs e)
        {
            if (updateStudentsFirstName.Text.Length > 0 && updateStudentsLastName.Text.Length > 0 && updateStudentsUser.Text.Length > 0 && updateStudentGrade.SelectedIndex != -1)
            {
                    if (updateStudentsHours.Text.IndexOfAny("abcdefghijklmnopqrstuvwxyz".ToCharArray()) == -1)
                    {
                        if (true)
                        {
                            hasCommunity = "nnnnnnnnnn";
                            hasService = "nnnnnnnnnn";
                            hasAchievement = "nnnnnnnnnnnnnn";
                            if (updateCommunityAward.IsChecked ?? false)
                            {
                                hasCommunity = "csacommunity";
                            }
                            if (updateServiceAward.IsChecked ?? false)
                            {
                                hasService = "csaservice";
                            }
                            if (updateAchievementAward.IsChecked ?? false)
                            {
                                hasAchievement = "csaachievement";
                            }
                        }

                        String userPlusAwards = createUserID + "," + hasCommunity + "," + hasService + "," + hasAchievement;
                        userPlusAwards = userPlusAwards.Substring(userPlusAwards.IndexOf(": ") + 2);

                    for (int i = 0; i < nameUser.Count; i++)
                    {
                        if (nameUser[i].Contains(currentStudentUser))
                        {
                            nameUser[i] = updateStudentsFirstName.Text + " " + updateStudentsLastName.Text + "," + updateStudentsUser.Text;
                        }
                    }

                    for (int i = 0; i < userGrade.Count; i++)
                    {
                        if (userGrade[i].Contains(currentStudentUser))
                        {
                            String fixedGrade = (String)updateStudentGrade.SelectedValue.ToString();
                            fixedGrade = fixedGrade.Substring(fixedGrade.IndexOf(":") + 2, fixedGrade.IndexOf("t") - 1);
                            userGrade[i] = updateStudentsUser.Text + "," + fixedGrade;
                        }
                    }

                    for (int i = 0; i < userHours.Count; i++)
                    {
                        if (userHours[i].Contains(currentStudentUser))
                        {
                            userHours[i] = updateStudentsUser.Text + "," + updateStudentsHours.Text;
                        }
                    }

                    for (int i = 0; i < userAwards.Count; i++)
                    {
                        if (userAwards[i].Contains(currentStudentUser))
                        {
                            userAwards[i] = updateStudentsUser.Text + "," + hasCommunity + "," + hasService + "," + hasAchievement;
                        }
                    }

                    helper.userDataUpdater(nameUser, nameUserPath);
                    helper.userDataUpdater(userGrade, userGradePath);
                    helper.userDataUpdater(userHours, userHoursPath);
                    helper.userDataUpdater(userAwards, userAwardsPath);

                    updateAchievementAward.IsChecked = false;
                    updateServiceAward.IsChecked = false;
                    updateCommunityAward.IsChecked = false;


                    updateStudentsFirstName.Clear();
                    updateStudentsLastName.Clear();
                    updateStudentsUser.Clear();
                    updateStudentsHours.Clear();
                    updateStudentGrade.SelectedIndex = -1;

                    ((Storyboard)FindResource("animate")).Begin(updateSuccessful);


                }
                    else
                    {
                        MessageBox.Show("Error: Hours must be entered as a numeric quantity, not characters", "User Entry Error");
                    }
                
            }
            else
            {
                MessageBox.Show("Error: No user was searched, or a field was left empty.", "User Entry Error");
            }
            
        }
    }
}
