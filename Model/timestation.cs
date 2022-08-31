using System;
using System.Collections.Generic;

namespace music_manage.Model
{
    public class timestation
    {
        int? secconds { get; set; }
        public TimeSpan timeSpan;
        string? Mota { get; set; }
        timestation(int seccond)
        {
            secconds = seccond;
            timeSpan = new TimeSpan(0, 0, seccond);
        }
        timestation(int seccond,string mota)
        {
            secconds = seccond;
            Mota = mota;
            timeSpan = new TimeSpan(0, 0, seccond);
        }
        timestation(TimeSpan ts)
        {
            timeSpan = ts;
        }
        timestation(TimeSpan ts, string mota)
        {
            timeSpan = ts;
            Mota = mota;
        }
    }
    public class timestation_manager
    {
        List<timestation> timestations;
        int idcurrentts;
        public TimeSpan currentts()
        {
            return timestations[idcurrentts].timeSpan;
        }
        public timestation_manager(List<timestation> Timestations)
        {
            timestations = Timestations;
        }
        public void movetoId(int ID)
        {
            idcurrentts = ID;
        }
        public void next()
        {
            movetoId(idcurrentts + 1);
        }
        public void previous()
        {
            movetoId(idcurrentts - 1);
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
   
}
