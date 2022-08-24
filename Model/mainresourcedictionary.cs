﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
        #region hover  
        public void hoverplaybt(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/PlayUI2.png"));

                }
            }
        }
        public void hovernextm(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/next2.png"));

                }
            }
        }
        public void hovernextst(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/previousmove2.png"));

                }
            }
        }
        public void hoverprem(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/next2.png"));

                }
            }
        }
        public void hoverprest(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/previousmove2.png"));

                }
            }
        }
        #endregion 

        public void lplaybt(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/PlayUI.png"));

                }
            }
        }
        public void lnextm(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/next.png"));

                }
            }
        }
        public void lnextst(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/previousmove.png"));

                }
            }
        }
        public void lprem(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/next.png"));

                }
            }
        }
        public void lprest(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;


            if (button != null)
            {
                Image? contented = button.Content as Image;

                if (contented != null)
                {
                    contented.Source = new BitmapImage(new System.Uri("pack://application:,,,/picture/previousmove.png"));

                }
            }
        }

    }
}
