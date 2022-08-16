using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
    }
    
}
