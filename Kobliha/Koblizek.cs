using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;
namespace Kobliha
{
	public class Koblizek
	{
        protected int Velikost { get; set; }
        private int PoziceX { get; set; }
        private int PoziceY { get; set; }
        private int Rychlost { get; set; } = 5;
        private int SkokSilou { get; set; } = 15;
        private bool Skace { get; set; } = false;
        private Keys OvladaniDoleva { get; set; }
        private Keys OvladaniDoprava { get; set; }
        private Keys OvladaniSkok { get; set; }
        protected Texture2D Textura { get; set; }
        
        private bool naZemi = true;
        
        private int vychoziPoziceY;

        private int casLetu = 0;

        private int maxCasLetu = 15; // Čas letu v počtu snímků, můžete přizpůsobit podle potřeby
        
        private bool jeOtocenyDoprava = false;

        private float RychlostKutaleni { get; set; } = 1.0f;
        //konstruktor
        public Koblizek(GraphicsDevice grafickeZarizeni, int velikost, string nazevSouboru,
             Keys smerDoleva, Keys smerDoprava, Keys skok,
             int rozmerOknaX = 0, int rozmerOknaY = 0)
        {
            Velikost = velikost;

            PoziceX = rozmerOknaX / 2;
            PoziceY = rozmerOknaY - velikost;

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
                RychlostKutaleni = 1.0f; // Kutálení doprava
                jeOtocenyDoprava = true;
            }
            else if (stavKlavesnice.IsKeyDown(OvladaniDoleva))
            {
                PoziceX -= Rychlost;
                RychlostKutaleni = -1.0f; // Kutálení doleva
                jeOtocenyDoprava = false;
            }







            if (stavKlavesnice.IsKeyDown(OvladaniSkok) && naZemi)
            {
                vychoziPoziceY = PoziceY;
                naZemi = false;
                casLetu = 0;
            }

            if (!naZemi)
            {
                if (casLetu < maxCasLetu)
                {
                    // Fáze skoku - postava letí nahoru
                    PoziceY -= Rychlost;
                }
                else
                {
                    // Fáze klesání - postava se vrací na zem
                    PoziceY += Rychlost;

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

        public void OmezSvujPohybNa(int levyOkraj, int horniOkraj, int pravyOkraj, int spodniOkraj)
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
                new Rectangle(PoziceX, PoziceY, Velikost, Velikost),
                null,
                Color.White,
                0f,
                Vector2.Zero,
                efekt,
                0f
            );
        }

    }
}