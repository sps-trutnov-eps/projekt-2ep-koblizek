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
    public class NPC
    {

        public int Velikost { get; set; }
        private Vector2 Pozice { get; set; }
        public float PoziceX => this.Pozice.X;
        public float PoziceY => this.Pozice.Y;
        protected Texture2D Textura { get; set; }

        public NPC(GraphicsDevice grafickeZarizeni, int velikost, string nazevSouboru,
            int PoziceX, int PoziceY)
        {
            Velikost = velikost;
            Pozice = new Vector2(PoziceX, PoziceY);

            using (FileStream stream = new FileStream(nazevSouboru, FileMode.Open))
            {
                Textura = Texture2D.FromStream(grafickeZarizeni, stream);
            }
        }

        public void PohniSe()
        {
            Pozice = new Vector2(Pozice.X + 6, Pozice.Y);
        }
        public void VykresliSe(SpriteBatch vykreslovaciDavka)
        {
            vykreslovaciDavka.Draw(Textura, Pozice, Color.White);
        }
    }
}
