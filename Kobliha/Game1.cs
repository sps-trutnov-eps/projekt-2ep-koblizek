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
        private bool konec = false;
        private bool vzduch = true;
        private int rychlost_skoku = 0;
        private int pocet_penez = 0;
        
        Koblizek kobliha;
        NPC dedek, babka, vlk, zajic, medved, liska, stop1, stop2, stop3, stop4, lava;
        Endingy ending1, ending2, ending3, ending4;
        Zem zem1, zem2, zem3;
        Penize peniz1, peniz_ikona;
        
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

            kobliha = new Koblizek(GraphicsDevice, 70, "Content/obrazky/koblizek.png",
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

            ending2 = new Endingy(GraphicsDevice, "Content/obrazky/ending2.png", 0, 0);

            ending3 = new Endingy(GraphicsDevice, "Content/obrazky/ending3.png", 0, 0);

            ending4 = new Endingy(GraphicsDevice, "Content/obrazky/ending4.png", 0, 0);

            lava = new NPC(GraphicsDevice, 100, "Content/obrazky/lava.png", 100, 880);

            //PLATFORMY

            zem1 = new Zem(GraphicsDevice, 0, vyskaOkna - 15, sirkaOkna, 15);
            zem2 = new Zem(GraphicsDevice, 500, 800, 100, 20);
            zem3 = new Zem(GraphicsDevice, 200, 820, 100, 20);


            //PENIZKY
            peniz_ikona = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 50, 50);
            peniz1 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 500, 850);
        }


        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();
            if (klavesnice.IsKeyDown(Keys.Escape))
                Exit();
            kobliha.PohniSe(klavesnice);
            base.Update(gameTime);

            
            
            base.Update(gameTime);

          
            //PLATFORMY

            if (kobliha.PoziceY + 61 > zem1.PoziceY && kobliha.PoziceY + 61 < zem1.PoziceY + 15)
            {
                vzduch = false;
                
            } 
            
           
            
         

            //SKOK

            if (vzduch == false)
            {
                rychlost_skoku = 0;
                if (klavesnice.IsKeyDown(Keys.W))
                {
                    vzduch = true;
                    rychlost_skoku = 15;
                }
            }

            if (vzduch == true)
            {

                rychlost_skoku -= 1;
                kobliha.PoziceY -= rychlost_skoku;
                
            }
            if (rychlost_skoku < -13) 
            {
                rychlost_skoku = (-13);
            }



            //PŘEHAZOVÁNÍ OBRAZOVEK 


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


            //INTERAKCE V OBRAZOVKÁCH

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
                if (kobliha.PoziceX > zajic.PoziceX && kobliha.PoziceX < zajic.PoziceX + 120)
                {
                    if (klavesnice.IsKeyDown(Keys.Space))
                    {
                        cislo_obrazovky = 10;
                        kobliha.PoziceX = 10;
                    } 
                }

                if (kobliha.PoziceX + kobliha.Velikost > peniz1.PoziceX && kobliha.PoziceX < peniz1.PoziceX + peniz1.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz1.PoziceY && kobliha.PoziceY < peniz1.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz1.Zmiz();
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
                

                //Platformy

                else if (kobliha.PoziceY + kobliha.Velikost > zem2.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem2.PoziceY + zem2.Vyska && kobliha.PoziceX > zem2.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem2.PoziceX + zem2.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem3.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem3.PoziceY + zem3.Vyska && kobliha.PoziceX > zem3.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem3.PoziceX + zem3.Sirka)
                {
                    vzduch = false;
                }
                else
                {
                    vzduch = true;
                }

                //lava

                if (kobliha.PoziceY + kobliha.Velikost > lava.PoziceY && kobliha.PoziceX + 50 > 100)
                {
                    konec = true;
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

                //Platformy


                //lava
                if (kobliha.PoziceY + kobliha.Velikost > lava.PoziceY && kobliha.PoziceX + 50 > 100)
                {
                    konec = true;
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
                
                //Platformy


                //lava
                if (kobliha.PoziceY + kobliha.Velikost > lava.PoziceY && kobliha.PoziceX + 50 > 100)
                {
                    konec = true;
                }
            }
        }
       
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            zem1.VykresliSe(_spriteBatch);
            peniz_ikona.VykresliSe(_spriteBatch);
            _spriteBatch.DrawString(spriteFont, pocet_penez.ToString(), new Vector2(80, 50), Color.Black);

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
                peniz1.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > zajic.PoziceX && kobliha.PoziceX < zajic.PoziceX + 120)
                {
                    _spriteBatch.DrawString(spriteFont, "Koblizku, koblizku, mam pro tebe ukol, spln ho a ziskas odmenu, nespnis ho a sezeru te (potvrd mezernikem)", new Vector2(200, 500), Color.Black);
                }
            }

            if (cislo_obrazovky == 3)
            {
                vlk.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > vlk.PoziceX && kobliha.PoziceX < vlk.PoziceX + 120)
                {
                    _spriteBatch.DrawString(spriteFont, "Koblizku, koblizku, mam pro tebe ukol, nedas ho a skoncis u me v brise! (potvrd mezernikem)", new Vector2(400, 500), Color.Black);
                }
            }

            if (cislo_obrazovky == 4)
            {
                medved.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > medved.PoziceX && kobliha.PoziceX < medved.PoziceX + 200)
                {
                    _spriteBatch.DrawString(spriteFont, "Koblizku, koblizku, dam ti ukol, spln ho nebo zemres! (potvrd mezernikem)", new Vector2(600, 500), Color.Black);
                }
            }

            if (cislo_obrazovky == 5)
            {
                liska.VykresliSe(_spriteBatch);
                if (kobliha.PoziceX > liska.PoziceX && kobliha.PoziceX < liska.PoziceX + 120)
                {
                    _spriteBatch.DrawString(spriteFont, "Koblizku, koblizku, ja te SNIM! ", new Vector2(400, 500), Color.Black);
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

            if (cislo_obrazovky == 10)
            {
                lava.VykresliSe(_spriteBatch);
                zem2.VykresliSe(_spriteBatch);
                zem3.VykresliSe(_spriteBatch);
                if (konec == true)
                {
                    ending2.VykresliSe(_spriteBatch);
                    kobliha.PoziceX = 200;
                }
                
            }

            if (cislo_obrazovky == 11)
            {
                lava.VykresliSe(_spriteBatch);
                if (konec == true)
                {
                    ending3.VykresliSe(_spriteBatch);
                    kobliha.PoziceX = 200;
                }
            }

            if (cislo_obrazovky == 12)
            {
                lava.VykresliSe(_spriteBatch);
                if (konec == true)
                {
                    ending4.VykresliSe(_spriteBatch);
                    kobliha.PoziceX = 200;
                }
            }

            if (cislo_obrazovky == 13)
            {
                lava.VykresliSe(_spriteBatch);
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
