using music_manage.Model;
using System.Windows;
using System.Windows.Controls;

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
            if (timestations == null)
            {
                return;
            }

            for(int i = 0, n = timestations.count; i < n; i++)
            {
                ListViewItem listViewItem = new ListViewItem();
                Button delete = new Button()
                {
                    Content="-",
                    Background=null
                };
                listViewItem.Content = ""+delete;
                liststationsUI.Items.Add(listViewItem);
            }
        }
    }
}
