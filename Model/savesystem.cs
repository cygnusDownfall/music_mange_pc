using System;
using System.Collections.Generic;
using System.IO;

namespace music_manage.Model
{
    public static class savesystem
    {
        const string savefilepath = "";
        public static void SavePathMusic(List<string> listpath)
        {
            
            if (File.Exists(savefilepath))
            {
                FileStream fileStream = new FileStream(savefilepath, FileMode.Create);
            }
            
            StreamWriter strwrt = new StreamWriter(savefilepath);
            foreach(string x in listpath)
            {
                strwrt.WriteLine(x);
            }
            
        }
        public static List<music> LoadPathMusic()
        {
            List<music> lm = new List<music>();
            if (File.Exists(savefilepath))
            {
                List<string> res = new List<string>();
                StreamReader strrdr = new StreamReader(savefilepath);
                while (true)
                {
                    res.Add(strrdr.ReadLine());
                    
                }
                foreach(var x in res)
                {
                    bool title = true;
                    string Title="", path="";
                    for(int i = 0, n = x.Length; i < n; i++)
                    {
                        if (x[i]==' ')
                        {
                            title = false;
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
        public static List<music> LoadMusicfromFolder(List<string> stringfolderpaths)
        {
            //input list<pathfolder>->output list<music>
            List<music> result = new List<music>();
            foreach(var x in stringfolderpaths)
            {
                DirectoryInfo directory = new DirectoryInfo(x);
                FileInfo[] files = directory.GetFiles("*.mp3");
                foreach(var y in files)
                {
                    music music = new music(y.Name, y.FullName);
                    result.Add(music);
                }
            }


            System.Windows.MessageBox.Show(result[0].ToString());
            return result;
        }
    }
    
}
