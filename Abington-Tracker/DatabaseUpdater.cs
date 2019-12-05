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
    }
}
