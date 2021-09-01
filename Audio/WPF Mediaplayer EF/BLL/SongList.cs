using System.Collections.Generic;

namespace EF_Testcase.BLL
{
    public class SongList : List<Song>
    {
        public int ID { get; set; }
        public string Genre { get; set; }
        public string Catalog { get; set; }
        public string Album { get; set; }
        public string Artist { get; set; }
        public string Title { get; set; }
        public string Pfad { get; set; }
        public string FileName { get; set; }
    }
}
