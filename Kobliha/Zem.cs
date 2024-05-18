using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using SharpDX.XAudio2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Kobliha
{
    internal class Zem
    {

        
        private Vector2 Pozice { get; set; }
        public Rectangle Velikost { get; set; }
        public float PoziceX => this.Pozice.X;
        public float PoziceY => this.Pozice.Y;
        protected Texture2D Textura { get; set; }
        public int Sirka { get; set; }
        public int Vyska { get; set; }
        public Zem(GraphicsDevice grafickeZarizeni, int PoziceX, int PoziceY, int sirka, int vyska)
        {   
            Pozice = new Vector2(PoziceX, PoziceY);
            Velikost = new Rectangle(PoziceX, PoziceY, sirka, vyska);
            
            Textura = new Texture2D(grafickeZarizeni, 1, 1);
            Textura.SetData(new[] { Color.Green });
            Sirka = sirka;
            Vyska = vyska;
        }
        public void VykresliSe(SpriteBatch vykreslovaciDavka)
        {

            vykreslovaciDavka.Draw(Textura, Pozice, Velikost, Color.White);

        }
    }
}
