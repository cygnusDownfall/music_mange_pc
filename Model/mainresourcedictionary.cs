using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
