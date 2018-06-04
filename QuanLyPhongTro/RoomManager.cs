using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace QuanLyPhongTro
{
    class RoomManager
    {

        //public List<Room> arrRoom;
        public Dictionary<string, RoomDetail> arrRoom = new Dictionary<string, RoomDetail>();

        public void Load()
        {
            // lấy dữ liệu từ file txt
            FileStream fs = new FileStream("database.txt", FileMode.Open);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);

            string a = sr.ReadToEnd();
            string[] g = new string[2];
            g = a.Split('@');
            fs.Close();


            for (int i = 0; i < g.Length; i++)
            {
                try
                {
                    string _name = g[i].Split('~')[0];
                    int _dienCu = int.Parse(g[i].Split('~')[1]);
                    int _nuocCu = int.Parse(g[i].Split('~')[2]);
                    int _tienPhong = int.Parse(g[i].Split('~')[3]);
                    int _dien = int.Parse(g[i].Split('~')[4]);
                    int _nuoc = int.Parse(g[i].Split('~')[5]);

                    // add xử lý từ bị trùng
                    if (!arrRoom.ContainsKey(_name))
                        arrRoom.Add(_name, new RoomDetail(_dienCu,_nuocCu,_tienPhong,_dien,_nuoc)); // add new entry
                    else
                        arrRoom[_name] = new RoomDetail(_dienCu, _nuocCu, _tienPhong,_dien,_nuoc); // update entry value

                }
                catch { }
               
            }

        }

        public void save()
        {
            File.WriteAllText("database.txt", String.Empty);
            string[] keys = arrRoom.Keys.ToArray();
            foreach(string key in keys)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter("database.txt", true))
                {
                    file.Write(key + "~" + arrRoom[key].dienCu + "~" + arrRoom[key].
                        nuocCu + "~" + arrRoom[key].tienPhong + "~" + arrRoom[key].dien + "~" + arrRoom[key].nuoc + "~@");
                }
            }
        }
    }
}
