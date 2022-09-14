using music_manage.Model;
using music_manage.windowform;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace music_manage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    enum replaymode { noReplay, ReplayOnly, ReplayAll }
    public partial class MainWindow : Window
    {
        #region properties
        MediaPlayer player;//trinh phat nhac
        replaymode replay;// co phat lai hay khong? 
        DispatcherTimer multitimer;//timer de chay 

        bool isplayed = false, israndom = false;
        List<music>? listmusic;
        TimeSpan time = new TimeSpan(0, 0, 0); // ???

        music currentplay;

        #endregion
        public MainWindow()
        {
            player = new MediaPlayer();
            player.MediaEnded += Player_MediaEnded;
            //player.Clock = new MediaClock(new MediaTimeline());
            multitimer = new DispatcherTimer();
            multitimer.Interval = new TimeSpan(0, 0, 1);
            multitimer.Tick += Multitimer_Tick;

            InitializeComponent();

            loadmusic();
        }


        
        private void Multitimer_Tick(object? sender, EventArgs e)//timer chay khi nhac dc phat
        {
            setValueforUC(time);
            time.Add(new TimeSpan(0, 0, 1));
        }

        #region eventagrs
        private void Maxsize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
        }
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
            Application.Current.Shutdown();
        }
        void minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) // keo tha khung window
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void Addmusicbt_Click(object sender, RoutedEventArgs e)
        {
            openfindpathwidow();
        }
        #region mediabt
        private void continueplay(object sender, RoutedEventArgs e)
        {
            if (!isplayed)
            {
                play();


                //star timmer

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

            if (listmusic == null)
            {
                return;
            }
            if (listmusic.Count == 0)
            {
                return;
            }
            chagnemusicnextandplay();
        }
        private void nextstation(object sender, RoutedEventArgs e)
        {
            if (currentplay != null)
            {
                currentplay.currentmusic_manager.next();
                player.Position = currentplay.currentmusic_manager.currentts();
            }

        }
        private void previousstation(object sender, RoutedEventArgs e)
        {
            if (currentplay != null)
            {
                currentplay.currentmusic_manager.previous();
                player.Position = currentplay.currentmusic_manager.currentts();
            }
        }
        private void previousmusic(object sender, RoutedEventArgs e)
        {
            if (listmusic == null)
            {
                return;
            }
            if (listmusic.Count == 0)
            {
                return;
            }
            int id = listmusic.IndexOf(currentplay);
            if (id > 0)
            {
                currentplay = listmusic[id - 1];
                play();
            }
        }
        private void replaymusic(object sender, RoutedEventArgs e)
        {
            Button? bt = sender as Button;
            if (bt != null)
            {
                Image? icontent = bt.Content as Image;
                if (icontent != null)
                {
                    if (replay == replaymode.noReplay)
                    {
                        replay = replaymode.ReplayOnly;

                        icontent.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/replay2.png"));

                    }
                    else if (replay == replaymode.ReplayOnly)
                    {
                        replay = replaymode.ReplayAll;

                        icontent.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/replay3.png"));
                    }
                    else
                    {
                        replay = replaymode.noReplay;

                        icontent.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/replay.png"));

                    }
                }

            }
        }
        private void Randommusics(object sender, RoutedEventArgs e)
        {
            israndom = !israndom;

        }
        void quickaddstation(object sender, RoutedEventArgs e)
        {
            currentplay.currentmusic_manager.Addstation(player.Position);
        }
        void deletedata(object sender, RoutedEventArgs e)
        {
            if (listmusic != null)
            {
                listmusic.Clear();
                savesystem.SavePathMusic(listmusic);
                updateUIlistmusics();
            }

        }
        #endregion
        private void Player_MediaEnded(object? sender, EventArgs e)
        {
            time.Multiply(0);//reset timespan 
            //thu tu uu tien replayonly>random>replayall

            //replayonly 
            if (replay == replaymode.ReplayOnly)
            {
                play();
            }
            else
            //random
            if (israndom)
            {
                Random random = new Random();
                Random rd = new Random(random.Next(1, 6));
                currentplay = listmusic[rd.Next(0, listmusic.Count)];
                play();
            }
            else
            //replayAll
            if (replay == replaymode.ReplayAll)
            {
                chagnemusicnextandplay();
            }



        }

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

            }
        }
        private void showliststations(object sender, RoutedEventArgs e)
        {
            showliststations showliststation = new showliststations(currentplay.currentmusic_manager);
            showliststation.ShowDialog();
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

        void openfindpathwidow()
        {
            findfolderpath findwindow = new findfolderpath();

            findwindow.eventhandle += AddmusicEvent;
            findwindow.ShowDialog();

        }
        void PlayAt(int seccond)
        {
            player.Position = new TimeSpan(0, 0, seccond);
        }
        void setValueforUC(TimeSpan ts)
        {
            mainboard.value = ts.TotalSeconds;
        }

        void updateUIlistmusics() // on
        {
            if (listmusic != null && listmusic.Count != 0)
            {
                lvmusic.Items.Clear();

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
            if (currentplay != null)
            {
                if (multitimer.IsEnabled)
                {
                    multitimer.Stop();
                }
                multitimer.Start();

                //play the currentplay music 
                player.Open(new Uri(currentplay.Path));
                player.Play();
                isplayed = true;
                namemusic.Text = currentplay.Title;
            }


        }
        void chagnemusicnextandplay()
        {
            if (listmusic == null)
            {
                return;
            }
            if (listmusic.Count == 0)
            {
                return;
            }
            if (listmusic.IndexOf(currentplay) - listmusic.Count >= -1)
            {
                return;
            }
            currentplay = listmusic[listmusic.IndexOf(currentplay) + 1];
            play();
        }
        void loadmusic() //dc goij khi mo app
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
