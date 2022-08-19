﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using music_manage.Model;
using music_manage.windowform;

namespace music_manage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MediaPlayer player;//trinh phat nhac
        bool isplayed = false;
        List<music>? listmusic;
        
        
        music currentplay;
        public MainWindow()
        {
            player = new MediaPlayer();

            InitializeComponent();

            loadmusic();
        }

        #region eventagrs
        void Addmusicbt_Click(object sender, RoutedEventArgs e)
        {
            findfolderpath findwindow = new findfolderpath();

            findwindow.eventhandle += AddmusicEvent;
            findwindow.ShowDialog();
            
        }
        private void continueplay(object sender, RoutedEventArgs e)
        {
            if (!isplayed)
            {
                player.Clock.Controller.Resume();
                
            }
            else
            {
                player.Clock.Controller.Pause();
                player.Pause();
            }

        }
        private void nextmusic(object sender, RoutedEventArgs e)
        {
            if (listmusic != null)
            {
                currentplay = listmusic[listmusic.IndexOf(currentplay) + 1];

            }
        }
        public void changetab(object sender, RoutedEventArgs e) // xong
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



        void updateUIlistmusics() // on
        {
            if (listmusic != null)
            {
                for (int i = 0, n = listmusic.Count; i < n; i++)
                {
                    ListViewItem musicUI = new ListViewItem();
                    musicUI.Tag = i;
                    musicUI.Content = listmusic[i].Title;
                    musicUI.Style = this.FindResource("lvmusicitems") as Style;
                    lvmusic.Items.Add(musicUI);
                }
            }
            
        }
        public void loadmusic()
        {
            listmusic = savesystem.LoadPathMusic();
            //updateUIlistmusics();
        }

    }
}
