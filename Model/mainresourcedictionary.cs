using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using music_manage.windowform;

namespace music_manage.Model
{
    public partial class mainresourcedictionary : ResourceDictionary
    {
        bool isplaybtisplay = true;
        public mainresourcedictionary()
        {
            InitializeComponent();
        }
        void randomclicked(object sender, RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button == null)
            {
                return;
            }
            Image? contented = button.Content as Image;
            if (contented == null)
            {
                return;
            }
            if (button.Tag.ToString() is null or not "israndom")
            {
                contented.Source = new BitmapImage(new Uri("pack://application:,,,/picture/random.png"));
                button.Tag = "israndom";
            }
            else
            {
                contented.Source = new BitmapImage(new Uri("pack://application:,,,/picture/random2.png"));
                button.Tag = "norandom";
                
            }

        }
        void playclick(object sender,RoutedEventArgs e)
        {
            Button? button = sender as Button;
            if (button == null)
            {
                return;
            }
            Image? contented = button.Content as Image;
            if (contented == null)
            {
                return;
            }
            if (!isplaybtisplay)
            {
                contented.Source = new BitmapImage(new Uri("pack://application:,,,/picture/PlayUI.png"));
            }
            else
            {
               contented.Source = new BitmapImage(new Uri("pack://application:,,,/picture/pause.png"));
            }
            isplaybtisplay = !isplaybtisplay;

        }
        #region hover  
        public void hoverplaybt(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;
            if (button == null)
            {
                return;
            }
            if (isplaybtisplay)
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
        #region leaveevent
        public void lplaybt(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Button? button = sender as Button;
            if (button == null)
            {
                return;
            }
            if (isplaybtisplay)
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
        #endregion
    }
}
