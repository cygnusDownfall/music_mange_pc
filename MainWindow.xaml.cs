using music_manage.Model;
using music_manage.windowform;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace music_manage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player;//trinh phat nhac
        DispatcherTimer multitimer;

        bool isplayed = false;
        List<music>? listmusic;


        music currentplay;
        public MainWindow()
        {
            player = new MediaPlayer();
            //player.Clock = new MediaClock(new MediaTimeline());
            multitimer = new DispatcherTimer();
            multitimer.Interval = new TimeSpan(0, 0, 1);
            multitimer.Tick += Multitimer_Tick;

            InitializeComponent();

            loadmusic();
        }

        private void Multitimer_Tick(object? sender, EventArgs e)
        {
            mainboard.value = caculatevalue(player.Clock.CurrentTime);
            MessageBox.Show(mainboard.value.ToString());
        }

        #region eventagrs
        private void scrvw_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {

            scrvw.ScrollToVerticalOffset(scrvw.VerticalOffset - e.Delta);

        }
        private void Button_Click(object sender, RoutedEventArgs e) // Exit button
        {
            if (listmusic != null)
            {
                savesystem.SavePathMusic(listmusic);
            }

        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) // keo tha khung window
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }
        void Addmusicbt_Click(object sender, RoutedEventArgs e)
        {
            findfolderpath findwindow = new findfolderpath();

            findwindow.eventhandle += AddmusicEvent;
            findwindow.ShowDialog();

        }
        #region mediabt
        private void continueplay(object sender, RoutedEventArgs e)
        {
            if (!isplayed)
            {
                isplayed = true;
                play();
            }
            else
            {
                isplayed = false;
                multitimer.Stop();
                player.Pause();

            }

        }
        private void nextmusic(object sender, RoutedEventArgs e)
        {
            if (listmusic != null)
            {
                currentplay = listmusic[listmusic.IndexOf(currentplay) + 1];
                play();
            }
        }
        private void nextstation(object sender, RoutedEventArgs e)
        {

        }
        private void previousstation(object sender, RoutedEventArgs e)
        {

        }
        private void previousmusic(object sender, RoutedEventArgs e)
        {

            if (listmusic != null)
            {
                int id = listmusic.IndexOf(currentplay);
                if (id != 1)
                {
                    currentplay = listmusic[id - 1];
                    play();
                }


            }
        }
        #endregion
        void changetab(object sender, RoutedEventArgs e) // xong
        {
            Button? tab = sender as Button;
            if (tab != null)
                switch (tab.Tag)
                {
                    case "1":
                        {
                            listmusicgr.Visibility = Visibility.Visible;
                            playermedia.Visibility = Visibility.Collapsed;
                            Detailpanel.Visibility = Visibility.Collapsed;
                            Lyricpanel.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case "2":
                        {
                            listmusicgr.Visibility = Visibility.Collapsed;
                            playermedia.Visibility = Visibility.Visible;
                            Detailpanel.Visibility = Visibility.Collapsed;
                            Lyricpanel.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case "3":
                        {
                            listmusicgr.Visibility = Visibility.Collapsed;
                            playermedia.Visibility = Visibility.Collapsed;
                            Detailpanel.Visibility = Visibility.Visible;
                            Lyricpanel.Visibility = Visibility.Collapsed;
                            break;
                        }
                    case "4":
                        {
                            listmusicgr.Visibility = Visibility.Collapsed;
                            playermedia.Visibility = Visibility.Collapsed;
                            Detailpanel.Visibility = Visibility.Collapsed;
                            Lyricpanel.Visibility = Visibility.Visible;
                            break;
                        }
                }

        }
        private void MusicUI_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            ListViewItem? listViewItem = sender as ListViewItem;
            if (listmusic != null && listViewItem != null)
            {
                currentplay = listmusic[Convert.ToInt32(listViewItem.Tag)];
                play();
                isplayed = true;
            }
        }

        #endregion
        #region customevent
        public void AddmusicEvent(object? sender, eventsendpath e)
        {
            List<music> res = savesystem.LoadMusicfromFolder(e.Folderpath);
            foreach (var x in res)
            {
                // lieu no co nhan dien dc music?
                if (listmusic.Contains(x))
                {
                    continue;
                }
                else
                {
                    listmusic.Add(x);
                }

            }
            updateUIlistmusics();

        }
        #endregion
        #region My_method
        int caculatevalue(TimeSpan? clock)
        {
            return 0;
        }
        void updateUIlistmusics() // on
        {
            lvmusic.Items.Clear();
            if (listmusic != null)
            {
                for (int i = 0, n = listmusic.Count; i < n; i++)
                {
                    ListViewItem musicUI = new ListViewItem();
                    musicUI.Tag = i;
                    musicUI.Content = listmusic[i].Title;
                    musicUI.Style = this.FindResource("lvmusicitems") as Style;
                    musicUI.MouseDoubleClick += MusicUI_MouseDoubleClick;
                    lvmusic.Items.Add(musicUI);
                }
            }

        }

        void play()
        {
            if (multitimer.IsEnabled)
            {
                multitimer.Stop();
            }
            multitimer.Start();
            
            //play the currentplay music 
            player.Open(new Uri(currentplay.Path));
            player.Play();
            
        }

        void loadmusic()
        {
            if (listmusic != null)
            {
                listmusic.Clear();

            }
            listmusic = savesystem.LoadPathMusic();
            updateUIlistmusics();
        }






        #endregion


    }
}
