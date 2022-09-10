using System;
using System.Collections.Generic;
using System.IO;

namespace music_manage.Model
{
    public static class savesystem
    {
        public static void SavePathMusic(List<music> listmusic)
        {
            //co chay
            string savefilepath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "data.txt";
            StreamWriter strwrt = new StreamWriter(savefilepath,false);
            foreach (var x in listmusic)
            {
                strwrt.Write(x.Title + "#" + x.Path + "\n");
                
            }

        }
        public static List<music> LoadPathMusic()
        {
            string savefilepath = AppDomain.CurrentDomain.BaseDirectory.ToString() + "data.txt";
            List<music> lm = new List<music>();
            if (File.Exists(savefilepath))
            {
                List<string> res = new List<string>();

                foreach (string x in File.ReadAllLines(savefilepath))
                {
                    res.Add(x);
                }
                foreach (var x in res)
                {
                    bool title = true;
                    string Title = "", path = "";
                    for (int i = 0, n = x.Length; i < n; i++)
                    {
                        if (x[i] == '#')
                        {
                            title = false;
                            continue;
                        }
                        if (title)
                        {
                            Title += x[i];
                        }
                        else
                        {
                            path += x[i];
                        }
                    }
                    music music = new music(Title, path);
                    lm.Add(music);
                }

            }

            return lm;
        }
        public static List<music> LoadMusicfromFolder(List<string> stringfolderpaths) //bug some music load error and I can't get title or album 
        {
            
            List<music> result = new List<music>();
            foreach (var x in stringfolderpaths)
            {
                if (x != "")
                {
                    DirectoryInfo directory = new DirectoryInfo(x);

                    FileInfo[] files = directory.GetFiles("*.mp3");
                    foreach (var y in files)
                    {
                        
                        music music = new music(y.Name, y.FullName);
                        result.Add(music);
                    }
                }

            }
            return result;
        }
    }

}
