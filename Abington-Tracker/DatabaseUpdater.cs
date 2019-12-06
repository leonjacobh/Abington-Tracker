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

namespace Abington_Tracker
{
    class DatabaseUpdater
    {
        public void userDataUpdater(List<String> toAdd, String filePath)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            foreach (String str in toAdd)
            {
                sw.WriteLine(str);
            }
            sw.Close();
        }

        public String hasCommunityAward(List<String> awardDBS, String userID) 
        {
            foreach (String x in awardDBS)
            {
                if (x.Contains(userID) && x.Contains("csacommunity"))
                {
                    return "CSA Community Has Been Acquired!";
                }
            }
            return "Not Quite - Student Needs More Hours.";
        }

        public String hasServiceAward(List<String> awardDBS, String userID)
        {
            foreach (String x in awardDBS)
            {
                if (x.Contains(userID) && x.Contains("csaservice"))
                {
                    return "CSA Service Has Been Acquired!";
                }
            }
            return "Not Quite - Student Needs More Hours.";
        }

        public String hasAchievementAward(List<String> awardDBS, String userID)
        {
            foreach (String x in awardDBS)
            {
                if (x.Contains(userID) && x.Contains("csaachievement"))
                {
                    return "CSA Achievement Has Been Acquired!";
                }
            }
            return "Not Quite - Student Needs More Hours.";
        }

        public String getUserGrade(List<String> userGrades, String userID)
        {
            //String grabbedGrade = "";
            foreach (String x in userGrades)
            {
                if (x.Contains(userID))
                {
                    return x.Substring(x.IndexOf(",") + 1);
                }
            }
            return "Error Grabbing User Grade - Doesn't Exist";
        }

        public String getUserHours(List<String> userHours, String userID)
        {
            foreach (String x in userHours)
            {
                if (x.Contains(userID))
                {
                    return x.Substring(x.IndexOf(",") + 1);
                }
            }
            return "Error Grabbing User Hours - Doesn't Exist";
        }

        public String userToName(List<String> nameUsers, String userID)
        {
            foreach (String x in nameUsers)
            {
                if (x.Contains(userID))
                {
                    return x.Substring(0,x.IndexOf(","));
                }
            }
            return "Error Grabbing Last Name - Doesnt Exist";
        }

        public void createNameUser(List<String> nameAndUser, String newNameUser, String filePath)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            foreach (String str in nameAndUser)
            {
                sw.WriteLine(str);
            }
            sw.Close();
        }

        public void createUserHours(List<String> userAndHours, String newUserHours, String filePath)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            foreach (String str in userAndHours)
            {
                sw.WriteLine(str);
            }
            sw.Close();
        }

        public void createUserGrade(List<String> userAndGrade, String newUserGrade, String filePath)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            foreach (String str in userAndGrade)
            {
                sw.WriteLine(str);
            }
            sw.Close();
        }

        public void createUserAwards(List<String> userAndAwards, String newUserAwards, String filePath)
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(filePath);
            foreach (String str in userAndAwards)
            {
                sw.WriteLine(str);
            }
            sw.Close();
        }

        

        public bool originalUserID(List<String> nameUsers, String newUserID)
        {
            foreach (String x in nameUsers)
            {
                if (x.Contains(newUserID))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
