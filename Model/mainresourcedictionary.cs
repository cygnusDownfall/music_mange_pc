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
