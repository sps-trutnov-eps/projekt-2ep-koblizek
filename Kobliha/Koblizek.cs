using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
namespace Kobliha
{
	public class Koblizek
	{
        public int Velikost { get; set; }
        public int PoziceX { get; set; }
        public int PoziceY { get; set; }
        public Vector2 Pozice { get; set; }
        private int Rychlost { get; set; } = 6;
        private int RychlostSkoku { get; set; } = 5;
        private int SkokSilou { get; set; } = 15;
        private bool Skace { get; set; } = false;
        private Keys OvladaniDoleva { get; set; }
        private Keys OvladaniDoprava { get; set; }
        private Keys OvladaniSkok { get; set; }
        protected Texture2D Textura { get; set; }
        private bool jeOtocenyDoprava = false;
        private float UhelRotace { get; set; } = 0f;
        private float RychlostKutaleni { get; set; } = 0.2f;
        private float RychlostRotace { get; set; } = 7f;

        private bool naZemi = true;

        private int vychoziPoziceY;

        private int casLetu = 0;

        private int maxCasLetu = 20; // Čas letu v počtu snímků, můžete přizpůsobit podle potřeby

        //konstruktor
        
        public Rectangle GetRectangle()
        {
            // Vrátí obdélník reprezentující pozici a velikost hráče (kobližku)
            return new Rectangle((int)PoziceX, (int)PoziceY, Velikost, Velikost);
        }
        public Koblizek(GraphicsDevice grafickeZarizeni, int velikost, string nazevSouboru,
             Keys smerDoleva, Keys smerDoprava, Keys skok,
             int rozmerOknaX = 0, int rozmerOknaY = 0)
        {
            Velikost = velikost;

            PoziceX = rozmerOknaX / 2;
            PoziceY = 700;

            OvladaniDoleva = smerDoleva;
            OvladaniDoprava = smerDoprava;
            OvladaniSkok = skok;

            

            using (FileStream stream = new FileStream(nazevSouboru, FileMode.Open))
            {
                Textura = Texture2D.FromStream(grafickeZarizeni, stream);
            }
        }

        // metody
        public void PohniSe(KeyboardState stavKlavesnice)
        {
                if (stavKlavesnice.IsKeyDown(OvladaniDoprava))
            {
                PoziceX += Rychlost;
                UhelRotace += RychlostRotace; // Otáčení doleva
                jeOtocenyDoprava = true;
            }
            else if (stavKlavesnice.IsKeyDown(OvladaniDoleva))
            {
                PoziceX -= Rychlost;
                UhelRotace -= RychlostRotace; // Otáčení doprava
                jeOtocenyDoprava = false;
            }

            if (stavKlavesnice.IsKeyDown(OvladaniSkok) && naZemi)
            {

            }
            
            if (!naZemi)
            {
                if (casLetu < maxCasLetu)
                {
                    // Fáze skoku - postava letí nahoru
                    PoziceY -= RychlostSkoku;
                }
                else
                {
                    // Fáze klesání - postava se vrací na zem
                    PoziceY += RychlostSkoku;

                    // Simulace gravitace - pokud dosáhne nebo překročí původní výšku, znamená to, že dopadla zpět na zem
                    if (PoziceY >= vychoziPoziceY)
                    {
                        PoziceY = vychoziPoziceY;
                        naZemi = true;
                    }
                }
                casLetu++;
            }
        }

        public void OmezSvujPohybNa(int levyOkraj, int pravyOkraj)
        {
            if (PoziceX < levyOkraj)
                PoziceX = levyOkraj;
            if (PoziceX > pravyOkraj - Velikost)
                PoziceX = pravyOkraj - Velikost;

        }

        public void VykresliSe(SpriteBatch vykreslovaciDavka)
        {
            SpriteEffects efekt = jeOtocenyDoprava ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            vykreslovaciDavka.Draw(
                Textura,
                new Vector2(PoziceX + Velikost / 2, PoziceY + Velikost / 2),
                null,
                Color.White,
                MathHelper.ToRadians(UhelRotace),
                new Vector2(Textura.Width / 2, Textura.Height / 2),
                0.8f,
                efekt,
                0f
               );
        }
    }
}