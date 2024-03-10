using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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
        private int PoziceX { get; set; }
        private int PoziceY { get; set; }
        protected Texture2D Textura { get; set; }

        public NPC(GraphicsDevice grafickeZarizeni, int velikost, string nazevSouboru,
            int rozmerOknaX = 0, int rozmerOknaY = 0)
        {
            Velikost = velikost;

            PoziceX = rozmerOknaX / 2;
            PoziceY = rozmerOknaY - velikost;

            using (FileStream stream = new FileStream(nazevSouboru, FileMode.Open))
            {
                Textura = Texture2D.FromStream(grafickeZarizeni, stream);
            }
        }
        public void VykresliSe(SpriteBatch vykreslovaciDavka)
        {
            vykreslovaciDavka.Draw(Textura, new Vector2(PoziceX + Velikost / 2, PoziceY + Velikost / 2));
        }
    }
}
