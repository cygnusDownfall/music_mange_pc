using music_manage.Model;
using System;
using System.Windows;
using System.Collections.Generic;

namespace music_manage.windowform
{
    /// <summary>
    /// Interaction logic for findfolderpath.xaml
    /// </summary>
    public partial class findfolderpath : Window
    {
        List<string> folderpath = new List<string>();
        public event EventHandler<eventsendpath> eventhandle;
        public findfolderpath()=> InitializeComponent();

        protected virtual void sendlistfolderpath(eventsendpath e)
        {
            EventHandler<eventsendpath> sendpath = eventhandle;// null?
            sendpath.Invoke(this, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            sendlistfolderpath(new eventsendpath(folderpath));
        }
        void addfolderpathtextbox(object sender, RoutedEventArgs e)
        {
            //close this tab
            Application.Current.Shutdown();
        }
        
    }
}
