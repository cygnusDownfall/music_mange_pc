
using System;
using System.Windows;
using System.Windows.Controls;

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
       
    }
}
