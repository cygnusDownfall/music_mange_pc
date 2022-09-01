using music_manage.Model;
using System;
using System.Windows;
using System.Windows.Controls;


namespace music_manage.resource
{
    /// <summary>
    /// Interaction logic for Floatbutton.xaml
    /// </summary>
    public partial class Floatbutton : UserControl
    {
        public event EventHandler<RoutedEventArgs> eventhandle;
        public Floatbutton()
        {
            InitializeComponent();
        }

        private void Button_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                
            }
        }

        private void bt_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            eventhandle.Invoke(this, e);
        }
    }
}
