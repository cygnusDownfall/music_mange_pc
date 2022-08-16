using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace music_manage.Model
{
    public class timestation
    {

        DateTime time;
        string Mota { get; set; }
        timestation()
        {

        }
    }
    public class timestationcontroller { 
        public void Travel(timestation timestation)
        {

        }
    }
    public class music
    {
        public string Path;
        public string Title;
        public music(string title,string path)
        {
            Path = path;
            Title = title;
        }

    }
}
