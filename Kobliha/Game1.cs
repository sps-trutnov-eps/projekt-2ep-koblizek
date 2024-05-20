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
        private bool vyhra = false;
        private bool vzduch = true;
        private int rychlost_skoku = 0;
        private int pocet_penez = 0;
        
        Koblizek kobliha;
        NPC dedek, babka, vlk, zajic, medved, liska, stop1, stop2, stop3, stop4, lava;
        Endingy ending1, ending2, ending3, ending4, ending5, ending6;
        Zem zem1, zem2, zem3, zem4, zem5, zem6, zem7, zem8, zem9, zem10, zem11, zem12, zem13, zem14, zem15, zem16, zem17, zem18, zem19, zem20, zem21, zem22, zem23, zem24, zem25, zem26, zem27, zem28, zem29, zem30, zem31, zem32, zem33;
        Penize peniz1, peniz_ikona, peniz2, peniz3, peniz4, peniz5, peniz6;
        
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

            ending5 = new Endingy(GraphicsDevice, "Content/obrazky/ending5.png", 0, 0);
            
            ending6 = new Endingy(GraphicsDevice, "Content/obrazky/ending6.png", 0, 0);
            
            lava = new NPC(GraphicsDevice, 100, "Content/obrazky/lava.png", 100, 880);

            //PLATFORMY

            zem1 = new Zem(GraphicsDevice, 0, vyskaOkna - 15, sirkaOkna, 15);
            
            //ZAJIC
            zem2 = new Zem(GraphicsDevice, 200, 820, 100, 20);
            zem3 = new Zem(GraphicsDevice, 500, 800, 100, 20);
            zem4 = new Zem(GraphicsDevice, 730, 750, 100, 20);
            zem5 = new Zem(GraphicsDevice, 930, 670, 100, 20);
            zem6 = new Zem(GraphicsDevice, 1230, 650, 100, 20);
            zem7 = new Zem(GraphicsDevice, 550, 650, 100, 20);

            //VLK
            zem8 = new Zem(GraphicsDevice, 200, 820, 100, 20);
            zem9 = new Zem(GraphicsDevice, 500, 760, 100, 20);
            zem10 = new Zem(GraphicsDevice, 250, 660, 100, 20);
            zem11 = new Zem(GraphicsDevice, 730, 750, 100, 20);
            zem12 = new Zem(GraphicsDevice, 980, 660, 100, 20);
            zem13 = new Zem(GraphicsDevice, 1230, 570, 100, 20);
            zem14 = new Zem(GraphicsDevice, 980, 470, 100, 20);
            zem15 = new Zem(GraphicsDevice, 700, 450, 100, 20);
            zem16 = new Zem(GraphicsDevice, 1360, 750, 100, 20);
            zem17 = new Zem(GraphicsDevice, 400, 450, 100, 20);
            zem18 = new Zem(GraphicsDevice, 80, 400, 100, 20);

            //MEDVED
            zem19 = new Zem(GraphicsDevice, 200, 820, 100, 20);
            zem20 = new Zem(GraphicsDevice, 500, 740, 100, 20);
            zem21 = new Zem(GraphicsDevice, 200, 660, 100, 20);
            zem22 = new Zem(GraphicsDevice, 800, 700, 100, 20);
            zem23 = new Zem(GraphicsDevice, 1050, 620, 100, 20);
            zem24 = new Zem(GraphicsDevice, 1300, 530, 100, 20);
            zem25 = new Zem(GraphicsDevice, 1000, 440, 100, 20);
            zem26 = new Zem(GraphicsDevice, 660, 420, 100, 20);
            zem27 = new Zem(GraphicsDevice, 330, 400, 100, 20);
            zem28 = new Zem(GraphicsDevice, 0, 380, 100, 20);
            zem29 = new Zem(GraphicsDevice, 1420, 700, 100, 20);
            zem30 = new Zem(GraphicsDevice, 0, 290, 100, 20);
            zem31 = new Zem(GraphicsDevice, 140, 200, 100, 20);
            zem32 = new Zem(GraphicsDevice, 280, 110, 100, 20);
            zem33 = new Zem(GraphicsDevice, 600, 110, 100, 20);

            //PENIZKY
            
            peniz_ikona = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 50, 50);
            peniz1 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 600, 610);
            peniz2 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 300, 620);
            peniz3 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 130, 360);
            peniz4 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 250, 620);
            peniz5 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 50, 340);
            peniz6 = new Penize(GraphicsDevice, 21, "Content/obrazky/penizek.png", 650, 70);
            
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
                    {
                        if (pocet_penez == 6)
                        {
                            vyhra = true;
                        }
                        if (pocet_penez != 6)
                        {
                            konec = true;
                        }
                    }
                }
            }

            if (cislo_obrazovky == 6)
            {
                
            }

            if (cislo_obrazovky == 7)
            {
                if (kobliha.PoziceX > stop2.PoziceX && kobliha.PoziceX < stop2.PoziceX + 120)
                {
                    if (klavesnice.IsKeyDown(Keys.Space))
                    {
                        cislo_obrazovky = 14;
                        kobliha.PoziceX = 100;
                    }
                }
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
                //PENIZE
                if (kobliha.PoziceX + kobliha.Velikost > peniz1.PoziceX && kobliha.PoziceX < peniz1.PoziceX + peniz1.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz1.PoziceY && kobliha.PoziceY < peniz1.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz1.Zmiz();
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
                else if (kobliha.PoziceY + kobliha.Velikost > zem4.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem4.PoziceY + zem4.Vyska && kobliha.PoziceX > zem4.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem4.PoziceX + zem4.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem5.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem5.PoziceY + zem5.Vyska && kobliha.PoziceX > zem5.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem5.PoziceX + zem5.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem6.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem6.PoziceY + zem6.Vyska && kobliha.PoziceX > zem6.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem6.PoziceX + zem6.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem7.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem7.PoziceY + zem7.Vyska && kobliha.PoziceX > zem7.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem7.PoziceX + zem7.Sirka)
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
                //PENIZE
                if (kobliha.PoziceX + kobliha.Velikost > peniz2.PoziceX && kobliha.PoziceX < peniz2.PoziceX + peniz2.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz2.PoziceY && kobliha.PoziceY < peniz2.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz2.Zmiz();
                }
                if (kobliha.PoziceX + kobliha.Velikost > peniz3.PoziceX && kobliha.PoziceX < peniz3.PoziceX + peniz3.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz3.PoziceY && kobliha.PoziceY < peniz3.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz3.Zmiz();
                }

                //Platformy

                else if (kobliha.PoziceY + kobliha.Velikost > zem8.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem8.PoziceY + zem8.Vyska && kobliha.PoziceX > zem8.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem8.PoziceX + zem8.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem9.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem9.PoziceY + zem9.Vyska && kobliha.PoziceX > zem9.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem9.PoziceX + zem9.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem10.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem10.PoziceY + zem10.Vyska && kobliha.PoziceX > zem10.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem10.PoziceX + zem10.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem11.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem11.PoziceY + zem11.Vyska && kobliha.PoziceX > zem11.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem11.PoziceX + zem11.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem12.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem12.PoziceY + zem12.Vyska && kobliha.PoziceX > zem12.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem12.PoziceX + zem12.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem13.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem13.PoziceY + zem13.Vyska && kobliha.PoziceX > zem13.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem13.PoziceX + zem13.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem14.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem14.PoziceY + zem14.Vyska && kobliha.PoziceX > zem14.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem14.PoziceX + zem14.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem15.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem15.PoziceY + zem15.Vyska && kobliha.PoziceX > zem15.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem15.PoziceX + zem15.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem16.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem16.PoziceY + zem16.Vyska && kobliha.PoziceX > zem16.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem16.PoziceX + zem16.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem17.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem17.PoziceY + zem17.Vyska && kobliha.PoziceX > zem17.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem17.PoziceX + zem17.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem18.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem18.PoziceY + zem18.Vyska && kobliha.PoziceX > zem18.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem18.PoziceX + zem18.Sirka)
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
                //PENIZE
                if (kobliha.PoziceX + kobliha.Velikost > peniz4.PoziceX && kobliha.PoziceX < peniz4.PoziceX + peniz4.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz4.PoziceY && kobliha.PoziceY < peniz4.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz4.Zmiz();
                }
                if (kobliha.PoziceX + kobliha.Velikost > peniz5.PoziceX && kobliha.PoziceX < peniz5.PoziceX + peniz5.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz5.PoziceY && kobliha.PoziceY < peniz5.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz5.Zmiz();
                }
                if (kobliha.PoziceX + kobliha.Velikost > peniz6.PoziceX && kobliha.PoziceX < peniz6.PoziceX + peniz6.Velikost && kobliha.PoziceY + kobliha.Velikost > peniz6.PoziceY && kobliha.PoziceY < peniz6.PoziceY + 26)
                {
                    pocet_penez += 1;
                    peniz6.Zmiz();
                }
                //Platformy
                else if (kobliha.PoziceY + kobliha.Velikost > zem19.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem19.PoziceY + zem19.Vyska && kobliha.PoziceX > zem19.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem19.PoziceX + zem19.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem20.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem20.PoziceY + zem20.Vyska && kobliha.PoziceX > zem20.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem20.PoziceX + zem20.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem21.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem21.PoziceY + zem21.Vyska && kobliha.PoziceX > zem21.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem21.PoziceX + zem21.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem22.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem22.PoziceY + zem22.Vyska && kobliha.PoziceX > zem22.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem22.PoziceX + zem22.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem23.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem23.PoziceY + zem23.Vyska && kobliha.PoziceX > zem23.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem23.PoziceX + zem23.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem24.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem24.PoziceY + zem24.Vyska && kobliha.PoziceX > zem24.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem24.PoziceX + zem24.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem25.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem25.PoziceY + zem25.Vyska && kobliha.PoziceX > zem25.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem25.PoziceX + zem25.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem26.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem26.PoziceY + zem26.Vyska && kobliha.PoziceX > zem26.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem26.PoziceX + zem26.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem27.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem27.PoziceY + zem27.Vyska && kobliha.PoziceX > zem27.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem27.PoziceX + zem27.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem28.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem28.PoziceY + zem28.Vyska && kobliha.PoziceX > zem28.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem28.PoziceX + zem28.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem29.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem29.PoziceY + zem29.Vyska && kobliha.PoziceX > zem29.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem29.PoziceX + zem29.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem30.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem30.PoziceY + zem30.Vyska && kobliha.PoziceX > zem30.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem30.PoziceX + zem30.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem31.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem31.PoziceY + zem31.Vyska && kobliha.PoziceX > zem31.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem31.PoziceX + zem31.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem32.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem32.PoziceY + zem32.Vyska && kobliha.PoziceX > zem32.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem32.PoziceX + zem32.Sirka)
                {
                    vzduch = false;
                }
                else if (kobliha.PoziceY + kobliha.Velikost > zem33.PoziceY && kobliha.PoziceY + kobliha.Velikost < zem33.PoziceY + zem33.Vyska && kobliha.PoziceX > zem33.PoziceX - kobliha.Velikost && kobliha.PoziceX < zem33.PoziceX + zem33.Sirka)
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
            if (cislo_obrazovky == 14)
            {
                
                if (kobliha.PoziceX > sirkaOkna - 11)
                {
                    kobliha.PoziceX = 400;
                    cislo_obrazovky = 7;
                }
                if (kobliha.PoziceX < 0)
                {
                    kobliha.PoziceX = 400;
                    cislo_obrazovky = 7;
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
                _spriteBatch.DrawString(spriteFont, "Utec pryc od dedka a babky!", new Vector2(650, 500), Color.Black);
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
                    _spriteBatch.DrawString(spriteFont, "Koblizku, koblizku, mam pro tebe ukol, spln ho a ziskas odmenu, nesplnis ho a sezeru te (potvrd mezernikem)", new Vector2(200, 500), Color.Black);
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
                    _spriteBatch.DrawString(spriteFont, "Koblizku, koblizku, ja te SNIM! zaplat 6 zlataku a ja te necham jit (potvrd mezernikem) ", new Vector2(400, 500), Color.Black);
                }
                if (konec)
                {   
                  ending5.VykresliSe(_spriteBatch);
                  kobliha.PoziceX = 200;
                }
                if (vyhra)
                {
                  ending6.VykresliSe(_spriteBatch);
                  kobliha.PoziceY = 2000;
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
                peniz1.VykresliSe(_spriteBatch);
                lava.VykresliSe(_spriteBatch);
                zem2.VykresliSe(_spriteBatch);
                zem3.VykresliSe(_spriteBatch);
                zem4.VykresliSe(_spriteBatch);
                zem5.VykresliSe(_spriteBatch);
                zem6.VykresliSe(_spriteBatch);
                zem7.VykresliSe(_spriteBatch);
                if (konec == true)
                {
                    ending2.VykresliSe(_spriteBatch);
                    kobliha.PoziceX = 200;
                }
                
            }

            if (cislo_obrazovky == 11)
            {
                peniz2.VykresliSe(_spriteBatch);
                peniz3.VykresliSe(_spriteBatch);
                lava.VykresliSe(_spriteBatch);
                zem8.VykresliSe(_spriteBatch);
                zem9.VykresliSe(_spriteBatch);
                zem10.VykresliSe(_spriteBatch);
                zem11.VykresliSe(_spriteBatch);
                zem12.VykresliSe(_spriteBatch);
                zem13.VykresliSe(_spriteBatch);
                zem14.VykresliSe(_spriteBatch);
                zem15.VykresliSe(_spriteBatch);
                zem16.VykresliSe(_spriteBatch);
                zem17.VykresliSe(_spriteBatch);
                zem18.VykresliSe(_spriteBatch);
                if (konec == true)
                {
                    ending3.VykresliSe(_spriteBatch);
                    kobliha.PoziceX = 200;
                }
            }

            if (cislo_obrazovky == 12)
            {
                peniz4.VykresliSe(_spriteBatch);
                peniz5.VykresliSe(_spriteBatch);
                peniz6.VykresliSe(_spriteBatch);
                lava.VykresliSe(_spriteBatch);
                zem19.VykresliSe(_spriteBatch);
                zem20.VykresliSe(_spriteBatch);
                zem21.VykresliSe(_spriteBatch);
                zem22.VykresliSe(_spriteBatch);
                zem23.VykresliSe(_spriteBatch);
                zem24.VykresliSe(_spriteBatch);
                zem25.VykresliSe(_spriteBatch);
                zem26.VykresliSe(_spriteBatch);
                zem27.VykresliSe(_spriteBatch);
                zem28.VykresliSe(_spriteBatch);
                zem29.VykresliSe(_spriteBatch);
                zem30.VykresliSe(_spriteBatch);
                zem31.VykresliSe(_spriteBatch);
                zem32.VykresliSe(_spriteBatch);
                zem33.VykresliSe(_spriteBatch);
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

            if (cislo_obrazovky == 14)
            {
                zajic.VykresliSe(_spriteBatch);
                vlk.VykresliSe(_spriteBatch);
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
