using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET;
using GMap.NET.MapProviders;
using System.IO;

namespace cSharp_offline_Gmap
{
    public partial class Form1 : Form
    {
        string cpath = Directory.GetCurrentDirectory();
        string cacheFolder = String.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cache dizini
            cacheFolder = Path.Combine(cpath, "Cache");

            // dizin yoksa oluştur
            if (!Directory.Exists(cacheFolder))
                Directory.CreateDirectory(cacheFolder);
            
            // cache ayarları
            GMaps.Instance.Mode = AccessMode.ServerAndCache;
            gMapControl1.CacheLocation = cacheFolder;

            // harita kontrolleri
            gMapControl1.DragButton = MouseButtons.Right;
            gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;

            // başlnagıç ve harita tipi
            gMapControl1.MapProvider = GMapProviders.GoogleSatelliteMap;
            gMapControl1.Position = new PointLatLng(41.0133045, 29.0630608);

            // yakınlaştırma ayarları
            gMapControl1.MaxZoom = 40;
            gMapControl1.MinZoom = 5;
            gMapControl1.Zoom = 10;
        }
    }
}
