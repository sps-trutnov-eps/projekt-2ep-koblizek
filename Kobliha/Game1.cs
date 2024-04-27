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
        NPC dedek, babka, vlk;
       
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
            spriteFont = Content.Load<SpriteFont>("Arial");
            kobliha = new Koblizek(GraphicsDevice, 62, "koblizek.png",
            
            Keys.A, Keys.D, Keys.W, sirkaOkna, vyskaOkna);
            if (cislo_obrazovky == 1)  
            //{
                dedek = new NPC(GraphicsDevice, 100, "dedek.png",
                    125, vyskaOkna - 150);

                babka = new NPC(GraphicsDevice, 100, "babka.png",
                    50, vyskaOkna - 150);
            //}

            //if (cislo_obrazovky == 2) 
            //{
                vlk = new NPC(GraphicsDevice, 100, "vlk.png",
                1200, vyskaOkna - 160);
            //}

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

            if (cislo_obrazovky > 1)
            {
                if (kobliha.PoziceX < -50)
                {
                    kobliha.PoziceX = sirkaOkna;
                    cislo_obrazovky -= 1;
                }
            }
            Console.WriteLine(cislo_obrazovky);
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
        
        //private void InterakceSVlkem()
        //{
            Rectangle hrac = kobliha.GetRectangle(); // Získá obdélník hráče
            Rectangle vlkObdelnik = vlk.GetRectangle(); // Získá obdélník vlka

            // Pokud se obdélníky hráče a vlka překrývají (kolize)
            if (hrac.Intersects(vlkObdelnik))
            {
                // Zde nastavíme, že se nad vlkem objeví text "baf"
                vlk.Nadpis = "baf";
            }
            else
            {
                // Pokud hráč není v kolizi s vlkem, skryj text
                vlk.Nadpis = "";
            }
        //}
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();

            dedek.VykresliSe(_spriteBatch);
            babka.VykresliSe(_spriteBatch);
            vlk.VykresliSe(_spriteBatch);
            // Vykresli text nad vlkem, pokud má nastavený nadpis
            if (!string.IsNullOrEmpty(vlk.Nadpis))
            {
                Vector2 poziceNadpisu = new Vector2(vlk.PoziceX, vlk.PoziceY - 20); // Nastav vhodnou pozici nadpisu
                _spriteBatch.DrawString(spriteFont, vlk.Nadpis, poziceNadpisu, Color.White);
            }

            kobliha.VykresliSe(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
