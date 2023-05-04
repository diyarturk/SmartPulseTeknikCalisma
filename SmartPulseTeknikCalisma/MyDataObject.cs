using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPulseTeknikCalisma
{
    public class MyDataObject
    {
        public int id { get; set; }
        public DateTime date { get; set; }
        public string conract { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
       
            public double ToplamIslemTutari { get; set; }
            public int ToplamIslemMiktari { get; set; }
        
        public double ToplamİslemMiktari
        {
            get
            {
                return (quantity / 10);
            }
            
        }
        public double ToplamİslemTutari
        {
            get
            {
                return (price * quantity) / 10;
            }

        }
        public double AgirlikliOrtalamaFiyat
        {
            get
            {
                return ((price * quantity) / 10) / (quantity / 10);
            }
        }
    }
}
