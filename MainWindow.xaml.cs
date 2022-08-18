using System;
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
        MediaPlayer player;
        List<music>? listmusic;
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
            findwindow.ShowDialog();
            findwindow.eventhandle += AddmusicEvent;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

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



        void updateUIlistmusics()
        {
            for (int i = 0, n = listmusic.Count; i < n; i++)
            {
                ListViewItem musicUI = new ListViewItem();
                musicUI.Tag = i;
                musicUI.Content = listmusic[i].Title;
            }
        }
        public void loadmusic()
        {
            listmusic = savesystem.LoadPathMusic();
            updateUIlistmusics();
        }

    }
}
