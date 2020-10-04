using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using Conspiratio.Allgemein;
using Conspiratio.Lib.Gameplay.Spielwelt;

namespace Conspiratio
{
    public static class Grafik
    {
        private static List<Bitmap> _rohstoffIcons46px = null;
        private static List<Bitmap> _rohstoffIcons80px = null;
        private static List<Bitmap> _rohstoffIcons100px = null;

        private static int _schriftgKlein = 16;
        private static int _schriftgMittel = 20;
        private static int _schriftgGross = 24;
        private static int _schriftgRiesig = 28;

        private static string _standardCursorName = "CurSword.ani";

        private static PrivateFontCollection _pfc = new PrivateFontCollection();
        private static Font[] _tempFont;
        private static string _verwSchriftart = "CloisterBlack.TTF";
        private static int _normBildschirmBreite = 1366; // Diese Angaben müssen nicht geändert werden, denn es wird alles immer basierend auf meinen damaligen Seitenverhältnissen gescaled...
        private static int _normBildschirmHoehe = 768;
        private static Color _standardSchriftFarbeGold;

        public static List<Bitmap> GetRohstoffIcons46px() { return _rohstoffIcons46px; }
        public static List<Bitmap> GetRohstoffIcons80px() { return _rohstoffIcons80px; }
        public static List<Bitmap> GetRohstoffIcons100px() { return _rohstoffIcons100px; }
        public static int GetSchriftgKlein() { return _schriftgKlein; }
        public static int GetSchriftgMittel() { return _schriftgMittel; }
        public static int GetSchriftgGross() { return _schriftgGross; }
        public static int GetSchriftgRiesig() { return _schriftgRiesig; }
        public static string GetStandardCursorName() { return _standardCursorName; }
        public static Color GetStandardSchriftFarbeGold() { return _standardSchriftFarbeGold; }
        public static string GetVerwSchriftart() { return _verwSchriftart; }
        public static int GetNormBildschirmBreite() { return _normBildschirmBreite; }
        public static int GetNormBildschirmHoehe() { return _normBildschirmHoehe; }

        public static Font GetStandardFont(int Schriftg)
        {
            if (Schriftg <= 0)
                Schriftg = 1;

            if (Schriftg > 0 && Schriftg < _tempFont.Length)
                return _tempFont[Schriftg];
            else
                return new Font("Arial", Schriftg);   // Standardfont nehmen, wenn die Schriftgröße größer ist, als im TempFont Array vorhanden
        }

        public static void Initialisieren()
        {
            RohstoffIconsAufbereiten();

            _standardSchriftFarbeGold = Color.FromArgb(255, 203, 0);
        }

        public static void InitialisiereSchriftarten()
        {
            _pfc.AddFontFile(Path.Combine(System.Windows.Forms.Application.StartupPath, GetVerwSchriftart()));  // Kritisch für den der es programmiert... er muss immer im Installationspfad Conspiratios die Schriftart gespeichert haben.
            int maxSchriftgroesse = 40;
            _tempFont = new Font[maxSchriftgroesse + 1];
            for (int i = 1; i <= maxSchriftgroesse; i++)
            {
                _tempFont[i] = new Font(_pfc.Families[0], i, FontStyle.Italic | FontStyle.Bold);
            }
        }

        /// <summary>
        /// Resize the image to the specified width and height.
        /// </summary>
        /// <param name="image">The image to resize.</param>
        /// <param name="width">The width to resize to.</param>
        /// <param name="height">The height to resize to.</param>
        /// <returns>The resized image.</returns>
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            // Quelle: http://stackoverflow.com/a/24199315
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }

        /// <summary>
        /// Dient zur Erstellung der Listen mit verkleinerten Rohstoff-Bitmaps, welche in den Forms angezeigt werden können 
        /// (bessere Performance, weniger Speicherverbrauch).
        /// </summary>
        private static void RohstoffIconsAufbereiten()
        {
            if (_rohstoffIcons46px == null)
                _rohstoffIcons46px = new List<Bitmap>();

            if (_rohstoffIcons80px == null)
                _rohstoffIcons80px = new List<Bitmap>();

            if (_rohstoffIcons100px == null)
                _rohstoffIcons100px = new List<Bitmap>();

            if (_rohstoffIcons46px.Count == 0 || _rohstoffIcons80px.Count == 0 || _rohstoffIcons100px.Count == 0)
            {
                // Dummy an Index 0 hinzufügen, damit der Zugriff intuitiver wird (mit der RohstoffID, z.B. lstRohstoffIcons80px[rohID])
                if (_rohstoffIcons46px.Count == 0)
                    _rohstoffIcons46px.Add(null);

                if (_rohstoffIcons80px.Count == 0)
                    _rohstoffIcons80px.Add(null);

                if (_rohstoffIcons100px.Count == 0)
                    _rohstoffIcons100px.Add(null);

                string sPathImageCache = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Conspiratio", "imgcache");

                if (!Directory.Exists(sPathImageCache))
                    Directory.CreateDirectory(sPathImageCache);

                for (int i = 1; i < SW.Statisch.GetMaxRohID(); i++)
                {
                    bool bIconFileExists46 = false;
                    bool bIconFileExists80 = false;
                    bool bIconFileExists100 = false;
                    string sFilenameIcon46 = Path.Combine(sPathImageCache, "Roh" + i.ToString() + "_46.png");
                    string sFilenameIcon80 = Path.Combine(sPathImageCache, "Roh" + i.ToString() + "_80.png");
                    string sFilenameIcon100 = Path.Combine(sPathImageCache, "Roh" + i.ToString() + "_100.png");

                    if (File.Exists(sFilenameIcon46))
                    {
                        _rohstoffIcons46px.Add((Bitmap)Image.FromFile(sFilenameIcon46));
                        bIconFileExists46 = true;
                    }

                    if (File.Exists(sFilenameIcon80))
                    {
                        _rohstoffIcons80px.Add((Bitmap)Image.FromFile(sFilenameIcon80));
                        bIconFileExists80 = true;
                    }

                    if (File.Exists(sFilenameIcon100))
                    {
                        _rohstoffIcons100px.Add((Bitmap)Image.FromFile(sFilenameIcon100));
                        bIconFileExists100 = true;
                    }

                    if (!bIconFileExists46 || !bIconFileExists80 || !bIconFileExists100)
                    {
                        object oRohstoffImage = Properties.Resources.ResourceManager.GetObject("Roh" + i.ToString());
                        if (oRohstoffImage != null && oRohstoffImage is Bitmap)   // Sicherheitsabfrage: ist ein gültiges Bitmap zurückgekommen?
                        {
                            if (!bIconFileExists46)
                            {
                                _rohstoffIcons46px.Add(Grafik.ResizeImage((Bitmap)oRohstoffImage, 46, 46));
                                _rohstoffIcons46px[i].Save(sFilenameIcon46, ImageFormat.Png);
                            }

                            if (!bIconFileExists80)
                            {
                                _rohstoffIcons80px.Add(Grafik.ResizeImage((Bitmap)oRohstoffImage, 80, 80));
                                _rohstoffIcons80px[i].Save(sFilenameIcon80, ImageFormat.Png);
                            }

                            if (!bIconFileExists100)
                            {
                                _rohstoffIcons100px.Add(Grafik.ResizeImage((Bitmap)oRohstoffImage, 100, 100));
                                _rohstoffIcons100px[i].Save(sFilenameIcon100, ImageFormat.Png);
                            }
                        }
                    }
                }
            }
        }

        public static void SwitchBanner(string btn_name, int value, frmBasis Form)
        {
            // TODO: Alle Stellen in Main Form, und formstatistik mit dieser Funktion ersetzen
            switch (value)
            {
                case 1:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban1);
                    break;
                case 2:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban2);
                    break;
                case 3:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban3);
                    break;
                case 4:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban4);
                    break;
                case 5:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban5);
                    break;
                case 6:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban6);
                    break;
                case 7:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban7);
                    break;
                case 8:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban8);
                    break;
                case 9:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban9);
                    break;
                case 10:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban10);
                    break;
                case 11:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban11);
                    break;
                case 12:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban12);
                    break;
                case 13:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban13);
                    break;
                case 14:
                    Form.Controls[btn_name].BackgroundImage = new Bitmap(Properties.Resources.ban14);
                    break;
            }
        }
    }
}
