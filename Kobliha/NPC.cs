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

namespace Kobliha
{
    public class NPC
    {
        protected int Velikost { get; set; }
        private Vector2 Pozice { get; set; }
        protected Texture2D Textura { get; set; }

        public NPC(GraphicsDevice grafickeZarizeni, int velikost, string nazevSouboru,
            int rozmerOknaX = 0, int rozmerOknaY = 0)
        {
            Velikost = velikost;
            Pozice = new Vector2(rozmerOknaX / 3, rozmerOknaY -150);


            using (FileStream stream = new FileStream(nazevSouboru, FileMode.Open))
            {
                Textura = Texture2D.FromStream(grafickeZarizeni, stream);
            }
        }
        public void VykresliSe(SpriteBatch vykreslovaciDavka)
        {
            vykreslovaciDavka.Draw(Textura, Pozice, Color.White);
        }
    }
}
