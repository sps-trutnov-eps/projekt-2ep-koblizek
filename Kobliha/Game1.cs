using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Kobliha
{
    public class Game1 : Game
    {
        // atributy
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        private SpriteFont spriteFont;
        private int sirkaOkna = 1600;
        private int vyskaOkna = 900;
        private int cislo_obrazovky = 1;
        Koblizek kobliha;
        NPC dedek, babka, vlk, zajic, medved, liska, stop1, stop2, stop3, stop4;
       
        //konstruktor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = sirkaOkna;
            _graphics.PreferredBackBufferHeight = vyskaOkna;
            _graphics.ApplyChanges();


            base.Initialize();
        }


        
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            kobliha = new Koblizek(GraphicsDevice, 62, "Content/obrazky/koblizek.png",
            Keys.A, Keys.D, Keys.W, sirkaOkna, vyskaOkna);
            
            dedek = new NPC(GraphicsDevice, 100, "Content/obrazky/dedek.png",
                    125, vyskaOkna - 150);

            babka = new NPC(GraphicsDevice, 100, "Content/obrazky/babka.png",
                    50, vyskaOkna - 150);
            
            zajic = new NPC(GraphicsDevice, 100, "Content/obrazky/zajic.png",
                1200, vyskaOkna - 160);
            
            vlk = new NPC(GraphicsDevice, 100, "Content/obrazky/vlk.png",
                1200, vyskaOkna - 160);
            
            medved = new NPC(GraphicsDevice, 100, "Content/obrazky/meda.png",
                1200, vyskaOkna - 260);

            liska = new NPC(GraphicsDevice, 100, "Content/obrazky/liska.png",
                1200, vyskaOkna - 210);
            
            stop1 = new NPC(GraphicsDevice, 100, "Content/obrazky/stop.png",
                1200, vyskaOkna - 128);
            
            stop2 = new NPC(GraphicsDevice, 100, "Content/obrazky/stop!.png",
                1200, vyskaOkna - 128);

            stop3 = new NPC(GraphicsDevice, 100, "Content/obrazky/dost.png",
                1200, vyskaOkna - 128);

            stop4 = new NPC(GraphicsDevice, 100, "Content/obrazky/konec.png",
                500, vyskaOkna - 600);


            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();
            if (klavesnice.IsKeyDown(Keys.Escape))
                Exit();
            kobliha.PohniSe(klavesnice);
            base.Update(gameTime);

            kobliha.PohniSe(klavesnice);
            //InterakceSVlkem(); // Zde zavolej metodu pro interakci s vlkem
            base.Update(gameTime);
            dedek.PoziceX = 125;
            babka.PoziceX = 50;
            zajic.PoziceX = 1200;
            vlk.PoziceX = 1200;
            medved.PoziceX = 1200;
            liska.PoziceX = 1200;
            stop1.PoziceX = 1200;
            stop2.PoziceX = 1200;
            stop3.PoziceX = 1200;
            stop4.PoziceX = 400;
            Console.WriteLine(vlk.PoziceX);
            
            if (cislo_obrazovky > 1)
            {
                if (kobliha.PoziceX < -50)
                {
                    kobliha.PoziceX = sirkaOkna;
                    cislo_obrazovky -= 1;
                }
            }
            
            if (kobliha.PoziceX > sirkaOkna)
            {
                kobliha.PoziceX = -50;
                cislo_obrazovky += 1;
            }

            if (cislo_obrazovky == 1)
            {
                if (kobliha.PoziceX < 0)
                {
                    kobliha.PoziceX = 0;
                }
            }

            if (cislo_obrazovky == 1)
            {
                if (kobliha.PoziceX > dedek.PoziceX && kobliha.PoziceX < dedek.PoziceX + 10)
                {
                    kobliha.PoziceX = 300;
                }
            }

            if (cislo_obrazovky == 2)
            {

            }

            if (cislo_obrazovky == 3)
            {

            }

            if (cislo_obrazovky == 4)
            {

            }

            if (cislo_obrazovky == 5)
            {

            }

            if (cislo_obrazovky == 6)
            {

            }

            if (cislo_obrazovky == 7)
            {

            }

            if (cislo_obrazovky == 8)
            {

            }

            if (cislo_obrazovky == 9)
            {

            }

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            if (cislo_obrazovky == 1)
            {
                dedek.VykresliSe(_spriteBatch);
                babka.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 2)
            {
                zajic.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 3)
            {
                vlk.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 4)
            {
                medved.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 5)
            {
                liska.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 6)
            {
                stop1.VykresliSe(_spriteBatch);
            }
            
            if (cislo_obrazovky == 7)
            {
                stop2.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 8)
            {
                stop3.VykresliSe(_spriteBatch);
            }

            if (cislo_obrazovky == 9)
            {
                stop4.VykresliSe(_spriteBatch);
            }

            kobliha.VykresliSe(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
