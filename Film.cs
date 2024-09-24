using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmKutuphanesi
{
    public class Film
    {
        //property tanimlama
        public string Ad { get; set; }
        public string Yonetmen { get; set; }
        public List<string> Oyuncular { get; set; }
        public string Tur { get; set; }
        public string YayinYili { get; set; }
        public double DegerlendirmePuani { get; set; }

        //yapici methot oluşturma
        public Film(string ad, string yonetmen, List<string> oyuncular, string tur, string yayinYili, double degerlendirmePuani)
        {
            Ad = ad;
            Yonetmen = yonetmen;
            Oyuncular = oyuncular;
            Tur = tur;
            YayinYili = yayinYili;
            DegerlendirmePuani = degerlendirmePuani;
        }
    }
}
