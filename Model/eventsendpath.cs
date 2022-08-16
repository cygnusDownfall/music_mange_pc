using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace music_manage.Model
{
    public class eventsendpath: EventArgs
    {
        public List<string> Folderpath;
        public eventsendpath(List<string> folderpath)
        {
            Folderpath = folderpath;
        }
    }
}
