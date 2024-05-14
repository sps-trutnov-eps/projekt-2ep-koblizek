using Microsoft.Xna.Framework; 
using Microsoft.Xna.Framework.Graphics; 
using Microsoft.Xna.Framework.Input; 
using System; 
using System.Diagnostics; 
using System.Security.Cryptography.X509Certificates; 




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
        public bool konec = false;
        Koblizek kobliha;
        NPC dedek, babka, vlk, zajic, medved, liska, stop1, stop2, stop3, stop4;
        Endingy ending1;
        
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

            ending1 = new Endingy(GraphicsDevice, "Content/obrazky/ending1.png", 0, 0);


        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();
            if (klavesnice.IsKeyDown(Keys.Escape))
                Exit();
            kobliha.PohniSe(klavesnice);
            base.Update(gameTime);

            kobliha.PohniSe(klavesnice);

            base.Update(gameTime);

            Console.WriteLine(dedek.PoziceX);

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

            if (cislo_obrazovky == 10)
            {
                if (kobliha.PoziceX < 0)
                {
                    kobliha.PoziceX = 0;
                }
                
                if (kobliha.PoziceX > sirkaOkna - 10)
                {
                    kobliha.PoziceX = sirkaOkna / 2;
                    cislo_obrazovky = 2;
                }
            }

            if (cislo_obrazovky == 11)
            {
                if (kobliha.PoziceX < 0)
                {
                    kobliha.PoziceX = 0;
                }

                if (kobliha.PoziceX > sirkaOkna - 10)
                {
                    kobliha.PoziceX = sirkaOkna / 2;
                    cislo_obrazovky = 3;
                }
            }

            if (cislo_obrazovky == 12)
            {
                if (kobliha.PoziceX < 0)
                {
                    kobliha.PoziceX = 0;
                }

                if (kobliha.PoziceX > sirkaOkna - 10)
                {
                    kobliha.PoziceX = sirkaOkna / 2;
                    cislo_obrazovky = 4;
                }
            }

            if (cislo_obrazovky == 1)
            {
                if (kobliha.PoziceX > dedek.PoziceX && kobliha.PoziceX < dedek.PoziceX + 70)
                {
                    konec = true;
                }
                dedek.PohniSe();
                babka.PohniSe();
            }

            if (cislo_obrazovky == 2)
            {
                if (kobliha.PoziceX > zajic.PoziceX && kobliha.PoziceX < zajic.PoziceX + 70)
                {
                    if (klavesnice.IsKeyDown(Keys.Space))
                    {
                        cislo_obrazovky = 10;
                        kobliha.PoziceX = 10;
                    }
                        
                }
            }

            if (cislo_obrazovky == 3)
            {
                if (kobliha.PoziceX > vlk.PoziceX && kobliha.PoziceX < vlk.PoziceX + 90)
                {
                    if (klavesnice.IsKeyDown(Keys.Space))
                    {
                        cislo_obrazovky = 11;
                        kobliha.PoziceX = 10;
                    }
                }
            }

            if (cislo_obrazovky == 4)
            {
                if (kobliha.PoziceX > medved.PoziceX && kobliha.PoziceX < medved.PoziceX + 120)
                {
                    if (klavesnice.IsKeyDown(Keys.Space))
                    {
                        cislo_obrazovky = 12;
                        kobliha.PoziceX = 10;
                    }
                }
            }

            if (cislo_obrazovky == 5)
            {
                if (kobliha.PoziceX > liska.PoziceX && kobliha.PoziceX < liska.PoziceX + 90)
                {
                    if (klavesnice.IsKeyDown(Keys.Space))
                        cislo_obrazovky = 9;
                }
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
                if (kobliha.PoziceX > stop4.PoziceX && kobliha.PoziceX < stop4.PoziceX + 400)
                {
                    Exit();
                }
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
                if (konec == true) 
                {
                    ending1.VykresliSe(_spriteBatch);
                    kobliha.PoziceX = 200;
                }
            }

            if (cislo_obrazovky == 2)
            {
                zajic.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > zajic.PoziceX && kobliha.PoziceX < zajic.PoziceX + 120)
                {
                    _spriteBatch.DrawString(spriteFont, "Mam pro tebe ukol, spln ho a ziskas odmenu (potvrd mezernikem)", new Vector2(600, 500), Color.Black);
                }
            }

            if (cislo_obrazovky == 3)
            {
                vlk.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > vlk.PoziceX && kobliha.PoziceX < vlk.PoziceX + 120)
                {
                    _spriteBatch.DrawString(spriteFont, "Jestli si splnil zajcuv ukol, ceka te tu tezsi (potvrd mezernikem)", new Vector2(600, 500), Color.Black);
                }
            }

            if (cislo_obrazovky == 4)
            {
                medved.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > medved.PoziceX && kobliha.PoziceX < medved.PoziceX + 200)
                {
                    _spriteBatch.DrawString(spriteFont, "Pokud si splnil predesle dva ukoly, uvidime jak si poradis s timhle (potvrd mezernikem)", new Vector2(400, 500), Color.Black);
                }
            }

            if (cislo_obrazovky == 5)
            {
                liska.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > liska.PoziceX && kobliha.PoziceX < liska.PoziceX + 120)
                {
                    _spriteBatch.DrawString(spriteFont, "ahoj ja jsem liska a to vse dekuji za pochopeni", new Vector2(600, 500), Color.Black);
                }
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
            if (konec != true)
            {
                kobliha.VykresliSe(_spriteBatch);
            }
            

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
