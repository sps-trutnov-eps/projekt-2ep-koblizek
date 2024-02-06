using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace Kobliha
{
	public class Koblizek
	{
        private int PoziceX { get; set; }
        private int PoziceY { get; set; }
        private Keys OvladaniDoleva { get; set; }
        private Keys OvladaniDoprava { get; set; }



        public Koblizek(Keys smerDoleva, Keys smerDoprava, int X = 1000, int Y = 500)
		{
			PoziceX = X;
			PoziceY = Y;

            OvladaniDoleva = smerDoleva;
            OvladaniDoprava = smerDoprava;


        }

	}
}