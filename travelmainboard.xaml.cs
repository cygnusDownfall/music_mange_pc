using System.Windows.Controls;
using System.Windows.Threading;

namespace music_manage
{

    public partial class travelmainboard : UserControl
    {
        public int value = 0; //0-1000
        public int[] position = new int[2] {0,0};
        public int bar_w = 1, bar_h = 1; // w= width h= inner height 
        int oldvalue = 0;
        DispatcherTimer timer;
        public travelmainboard()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new System.TimeSpan(0,0,1);
            timer.Start();
            
        }

        private void Timer_Tick(object? sender, System.EventArgs e)
        {
            checkchange();
        }

        private void checkchange()
        {
            if (value != oldvalue)
            {
                OnValueChange();
                oldvalue = value;
            }
        }


        public void OnValueChange()
        {
            position= RePosition(value);
            truck.SetValue(Canvas.LeftProperty, position[0]);
            truck.SetValue(Canvas.TopProperty, position[1]);
        }
        int[] RePosition(int val) // tinh toan vi tri dua tren val
        {
            
            int[] res = new int[2];
            
            return res;
        }
        #region customevent

        #endregion
    }
}
