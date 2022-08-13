using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace music_manage.Model
{
    public  class savesystem
    {
        string savefilepath = "";
        public void SavePathMusic(List<string> listpath)
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
        public List<string> LoadPathMusic()
        {
            List<string> res = new List<string>();
            if (File.Exists(savefilepath))
            {
                StreamReader strrdr = new StreamReader(savefilepath);
                while (true)
                {
                    res.Add(strrdr.ReadLine());
                    
                }
                return res;
            }
            return null;
        }
    }
    
}
