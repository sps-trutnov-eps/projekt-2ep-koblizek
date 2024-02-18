using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Kobliha
{
	public class Koblizek
	{
        protected int Velikost { get; set; }
        private int PoziceX { get; set; }
        private int PoziceY { get; set; }
        private int Rychlost { get; set; } = 5;
        private Keys OvladaniDoleva { get; set; }
        private Keys OvladaniDoprava { get; set; }

        protected Texture2D Textura { get; set; }

        //konstruktor
        public Koblizek(GraphicsDevice grafickeZarizeni, int velikost, Color barva,
             Keys smerDoleva, Keys smerDoprava,
             int rozmerOknaX = 0, int rozmerOknaY = 0)
        {
            Velikost = velikost;

            PoziceX = rozmerOknaX / 2;
            PoziceY = rozmerOknaY - velikost;

            OvladaniDoleva = smerDoleva;
            OvladaniDoprava = smerDoprava;

            Textura = new Texture2D(grafickeZarizeni, Velikost, Velikost);

            Color[] pixely = new Color[Velikost * Velikost];

            for (int i = 0; i < pixely.Length; i++)
                pixely[i] = barva;

            Textura.SetData(pixely);
        }

        // metody
        public void PohniSe(KeyboardState stavKlavesnice)
        {
            if (stavKlavesnice.IsKeyDown(OvladaniDoprava))
                PoziceX += Rychlost;
            if (stavKlavesnice.IsKeyDown(OvladaniDoleva))
                PoziceX -= Rychlost;

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
            vykreslovaciDavka.Draw(Textura, new Rectangle(PoziceX, PoziceY, Velikost, Velikost), Color.White);
        }

    }
}