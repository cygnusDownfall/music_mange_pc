using System;
using System.Collections.Generic;

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
    public class timestation_manager
    {
        List<timestation>? timestations;
        public void Travel(timestation timestation)
        {

        }
    }
    public class music
    {
        public string Path;
        public string Title;
        public music(string title, string path)
        {
            Path = path;
            Title = title;
        }
    }
    public class music_manager //model quan trong nhat
    {

    }
}
