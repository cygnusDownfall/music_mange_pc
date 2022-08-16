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
        MediaPlayer player;
        List<music> listmusic;
        public MainWindow()
        {
            player = new MediaPlayer();
            InitializeComponent();
            loadmusic();
        }
       
        
        void Addmusicbt_Click(object sender, RoutedEventArgs e)
        {
            findfolderpath findwindow = new findfolderpath();
            findwindow.ShowDialog();
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
        void updateUIlistmusics()
        {
            for(int i=0,n=listmusic.Count;i<n;i++)
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
        public void musiclvclick(object sender, RoutedEventArgs e)
        {
            //lay ra path tu listviewitems thong qua Tag 
            ListViewItem? musicUI=sender as ListViewItem;


            //dung path de phat nhac  
            string stringuri="";
            if (musicUI != null)
            {
                stringuri = listmusic[Convert.ToInt32(musicUI.Tag)].Path; //"F:\\MWSPr\\music_manage\\Nhac\\5774870.mp3";

                Uri source = new Uri(stringuri);
                player.Open(source);

                player.Play();
            }
            else
            {
                MessageBox.Show("Loi string Uri !!!");
            }

           
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
