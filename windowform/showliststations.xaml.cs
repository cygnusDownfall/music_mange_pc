using music_manage.Model;
using System.Windows;


namespace music_manage.windowform
{

    public partial class showliststations : Window
    {
        public timestation_manager timestations;
        public showliststations()
        {
            InitializeComponent();
            loadstation();
        }
        void loadstation()
        {
            for(int i = 0, n = timestations.count; i < n; i++)
            {

            }
        }
    }
}
