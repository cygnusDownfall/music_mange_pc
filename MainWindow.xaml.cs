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
using music_manage.Model;

namespace music_manage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            player = new MediaPlayer();
            InitializeComponent();
            if (lvmusic.Items.Count == 0)
            {
                lvmusicstart();
            }
        }
        void lvmusicstart()
        {
            Button addmusicbt = new Button();
            addmusicbt.Content = "+";
            addmusicbt.FontSize = 50;
            addmusicbt.Click += Addmusicbt_Click;
            lvmusic.Items.Add(addmusicbt);
        }
        List<music> listmusic = new List<music>();
        void Addmusicbt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bạn muốn tìm nhạc ở đâu ?", "file location");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        public void changetotablistmusic(object sender, RoutedEventArgs e)
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
        MediaPlayer player;
        public void musiclvclick(object sender, RoutedEventArgs e)
        {
            string stringuri = "F:\\MWSPr\\music_manage\\Nhac\\5774870.mp3";

            //khoi chay media thanh cong 

            Uri source = new Uri(stringuri);
            player.Open(source);
            //MessageBox.Show("khoi tao thanh cong");//da thanh cong 

            //bug:::play khong thanh cong
            player.Play();
        }
        public void exit(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        public void playmedia(object sender, RoutedEventArgs e)
        {

        }
    }
}
