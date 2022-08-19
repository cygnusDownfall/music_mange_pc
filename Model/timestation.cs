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
        public timestation_manager(List<timestation> Timestations)
        {
            timestations = Timestations;
        }
    }
    public class music
    {
        public string Path;
        public string Title;
        public timestation_manager? currentmusic_manager;
        public music(string title, string path)
        {
            Path = path;
            Title = title;
        }
        public music(string title, string path,List<timestation> timestations)
        {
            Path = path;
            Title = title;
            currentmusic_manager = new timestation_manager(timestations);
        }
    }
    public class music_manager //model quan trong nhat
    {

    }
}
