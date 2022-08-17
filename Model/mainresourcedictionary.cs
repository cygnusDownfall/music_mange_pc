
using System.Windows;
using System.Windows.Controls;

namespace music_manage.Model
{
    public partial class mainresourcedictionary : ResourceDictionary
    {
        public mainresourcedictionary()
        {
            InitializeComponent();
        }

        public void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void changetab(object sender, RoutedEventArgs e)
        {
            Button? tabbt = sender as Button;
            //ten cua cac button  dc dat lan luot theo cac tab Playing,MyMusic,Detail,Lyric
            if (tabbt != null)
            {
                switch (tabbt.Name)
                {
                    case "Playing":
                        {

                            break;
                        }
                    case "MyMusic":
                        {

                            break;
                        }
                    case "Detail":
                        {
                            break;
                        }
                    case "Lyric":
                        {
                            break;
                        }
                }
            }


        }
    }
}
