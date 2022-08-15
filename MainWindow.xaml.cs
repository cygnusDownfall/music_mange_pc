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
        MediaPlayer player;
        public MainWindow()
        {
            player = new MediaPlayer();
            InitializeComponent();
            loadmusic();
        }
       
        List<music> listmusic = new List<music>();
        void Addmusicbt_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("where are your music ?", "find music");
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
        public void loadmusic()
        {
            List<music> musics = savesystem.LoadPathMusic();
            
        }
        public void musiclvclick(object sender, RoutedEventArgs e)
        {
            //lay ra path tu listviewitems



            //dung path de phat nhac 
            string stringuri = "F:\\MWSPr\\music_manage\\Nhac\\5774870.mp3";

            Uri source = new Uri(stringuri);
            player.Open(source);
            
            player.Play();
            //goi UIupdate cua tab Playing

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
