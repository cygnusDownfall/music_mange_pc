﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        string Path { get; set; }
        string Title { get; set; }
        music(string title,string path)
        {
            Path = path;
            Title = title;
        }

    }
}