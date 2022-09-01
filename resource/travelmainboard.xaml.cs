using System.Windows.Controls;
using System.Windows.Threading;

namespace music_manage.resource
{

    public partial class travelmainboard : UserControl
    {
        public double value = 0; //0-1000
        public double[] position = new double[2] {0,0};
        public int bar_w = 1, bar_h = 1; // w= width h= inner height 
        double oldvalue = 0;
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
            position= Position(value);
            truck.SetValue(Canvas.LeftProperty, position[0]);
            truck.SetValue(Canvas.TopProperty, position[1]);
        }
        double[] Position(double val) // tinh toan vi tri dua tren val
        {
            
            double[] res = new double[2] {0,0};
            double floor = val/bar_w;
            double delta = val % bar_w;
            
            if (delta - floor * bar_h < 0)
            {
                //tinh y
                res[1] = delta;
                //tinh x
                if (floor%2==0)
                {
                    res[0] = 0;
                }
                else
                {
                    res[0] = bar_w;
                }
            }else
            {
                //tinh y
                res[1] = floor * bar_h;
                //tinh x
                if (floor % 2 == 0)
                {
                    res[0] = delta - floor * bar_h;
                }
                else
                {
                    res[0] = bar_w-(delta - floor * bar_h);
                }
            }
            
            
            return res;
        }
        #region customevent

        #endregion
    }
}
