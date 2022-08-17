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
        public findfolderpath() => InitializeComponent();

        protected virtual void sendlistfolderpath(eventsendpath e)
        {
            EventHandler<eventsendpath> sendpath = eventhandle;// null?
            sendpath.Invoke(this, e);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var x in musicsfolderlocations.Children)
            {
                try
                {
                    System.Windows.Controls.TextBox? textBox=x as System.Windows.Controls.TextBox;
                    if (textBox != null)
                    {
                        folderpath.Add(textBox.Text);
                    }
                    
                }
                catch
                {

                }

            }
            //MessageBox.Show(folderpath.ToString()); da xong
            sendlistfolderpath(new eventsendpath(folderpath));
            Application.Current.Shutdown();
        }
        void addfolderpathtextbox(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.TextBox textBox = new System.Windows.Controls.TextBox();
            textBox.Tag = "path";

            musicsfolderlocations.Children.Add(textBox);

        }

    }
}
