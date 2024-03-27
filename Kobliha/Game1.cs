using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Kobliha
{
    public class Game1 : Game
    {
        // atributy
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D _texture;
        
        private int sirkaOkna = 1600;
        private int vyskaOkna = 900;
        private int cislo_obrazovky = 1;
        Koblizek kobliha;
        NPC dedek, babka;
       
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
            kobliha = new Koblizek(GraphicsDevice, 62, "koblizek.png",
                 Keys.A, Keys.D, Keys.W, sirkaOkna, vyskaOkna);

            dedek = new NPC(GraphicsDevice, 100, "dedek.png",
                125 , vyskaOkna - 150);

            babka = new NPC(GraphicsDevice, 100, "babka.png",
                50, vyskaOkna - 150);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState klavesnice = Keyboard.GetState();
            if (klavesnice.IsKeyDown(Keys.Escape))
                Exit();
            kobliha.PohniSe(klavesnice);
            base.Update(gameTime);
        
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
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            
            dedek.VykresliSe(_spriteBatch);
            babka.VykresliSe(_spriteBatch);
            kobliha.VykresliSe(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
