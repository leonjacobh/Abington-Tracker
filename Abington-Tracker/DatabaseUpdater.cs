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
            return "Not Quite - Student Needs More Hours";
        }

        public String hasServiceAward(List<String> awardDBS, String userID)
        {
            foreach (String x in awardDBS)
            {
                if (x.Contains(userID) && x.Contains("csacommunity"))
                {
                    return "CSA Service Has Been Acquired!";
                }
            }
            return "Not Quite - Student Needs More Hours";
        }

        public String hasAchievementAward(List<String> awardDBS, String userID)
        {
            foreach (String x in awardDBS)
            {
                if (x.Contains(userID) && x.Contains("csacommunity"))
                {
                    return "CSA Achievement Has Been Acquired!";
                }
            }
            return "Not Quite - Student Needs More Hours";
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

    }
}
