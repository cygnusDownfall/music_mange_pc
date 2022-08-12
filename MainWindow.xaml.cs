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

namespace music_manage
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
        public void changetotablistmusic(object sender,RoutedEventArgs e)
        {
            listmusic.Visibility =Visibility.Visible;
        }
        MediaPlayer player;
        public void musiclvclick(object sender, RoutedEventArgs e)
        {
            string stringuri = "https://zingmp3.vn/embed/playlist/6BUOOID6";

            //khoi chay media thanh cong 
            player = new MediaPlayer();
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
    }
}
