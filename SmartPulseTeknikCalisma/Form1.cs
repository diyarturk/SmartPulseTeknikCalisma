using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.IO;
namespace SmartPulseTeknikCalisma
{
    public partial class SmartPulseTeknikCalisma : Form
    {
        public SmartPulseTeknikCalisma()
        {
            InitializeComponent();



        } 
        string filePath = @"c:\users\demba\desktop\smartpulseteknikcalisma\SmartPulseTeknikCalisma\bin\Debug\intra-day-trade-history.json";
        List<MyDataObject> data = new List<MyDataObject>();
        private void Form1_Load(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string json = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<MyDataObject>>(json);
            }
            //dataGridView1.Columns.Add("date", "Tarih");
            //dataGridView1.Columns.Add("ToplamİslemMiktari", "Toplam İslem Miktarı(MWh)");
            //dataGridView1.Columns.Add("ToplamİslemTutari", "Toplam İşlem Tutarı(TL)");
            //dataGridView1.Columns.Add("AgirlikliOrtalamaFiyat", "Ağırlıklı Ortalama Fiyat(TL/MWh)");
            //var groupedData = new Dictionary<string, decimal>();
            //foreach (var myDataObject in data)
            //{
            //    var contract = (string)myDataObject.conract;
            //    var hour = contract.Substring(8, 2);
            //    var date = DateTime.Parse((string)myDataObject.date.ToString());
            //    var key = date.ToString("yyyy.MM.dd") + " " + hour + ":00";
            //}

            var result = data.GroupBy(x => x.conract)
                 .Select(x => new
                 {  
                     ToplamIslemTutari = x.Sum(y => (y.price * y.quantity) / 10)
                 }).ToList();

            var result2 = data.GroupBy(x => x.conract)
                 .Select(x => new
                 {
                     ToplamIslemMiktari = x.Sum(y => (y.quantity / 10))
                 }).ToList();

            var result3 = data.GroupBy(x => x.conract)
                .Select(x => new
                {
                    AgirlikOrtalamaFiyat = x.Sum(y => ((y.price * y.quantity) / 10) / (y.quantity / 10))
                }).ToList();
            var result4 = data.GroupBy(x => x.date)
                               .Select(x => new
                               {
                                   Tarih = x.Key,
                               }).ToList();

            //var result5 = data.Where(d => d.conract.StartsWith("PH"))
                                   // .OrderBy(d => d.conract.Substring(d.conract.Length - 2)).ToList();
            
            dataGridView1.DataSource = result;
            dataGridView2.DataSource = result2;
            dataGridView3.DataSource = result3;
            dataGridView4.DataSource = result4;

        }

       
        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
