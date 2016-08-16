using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.VisualBasic;


namespace TBGAME2DVERSION
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AnimateSprite player;
        Sprite sock;
        Sprite dialogbox;
        backgroundsprite background;

        int a = 100;
        int b = 470;
        int hplayer;
        int wplayer;
        bool col;

        Point playerFrameSize;
        Point sockFrameSize;

        int playerCollisionOffset = 20;
        int sockCollisionOffset = 20;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //CHANGE WINDOW SIZE
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
        }

        protected bool Collide()
        {
            Rectangle playerRect = new Rectangle((int)a + playerCollisionOffset, (int)b + playerCollisionOffset, playerFrameSize.X - (playerCollisionOffset * 2), playerFrameSize.Y - (playerCollisionOffset * 2));

            Rectangle sockRect = new Rectangle((int)sock.getlocationX() + sockCollisionOffset, (int)b + sockCollisionOffset, sockFrameSize.X - (sockCollisionOffset * 2), sockFrameSize.Y - (sockCollisionOffset * 2));
            return playerRect.Intersects(sockRect);
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>(@"Graphics/spriteki");
            Texture2D texturebackground = Content.Load<Texture2D>(@"Graphics/forestbackground");
            Texture2D texturesock = Content.Load<Texture2D>(@"Graphics/sock");
            Texture2D texturedialogbox = Content.Load<Texture2D>(@"Graphics/dialogbox");
            player = new AnimateSprite(texture, 1, 8);
            background = new backgroundsprite(texturebackground, 1280, 720, new Vector2(1, 1));
            sock = new Sprite(texturesock, 50, 50, new Vector2(750, 545));
            dialogbox = new Sprite(texturedialogbox, 1200, 100, new Vector2(50, 10));


            hplayer = texture.Height;
            wplayer = texture.Width;
            playerFrameSize = new Point(hplayer, wplayer);
            sockFrameSize = new Point(50, 50);



            //player.AddComponent(new Sprite(Content.Load<Texture2D>(@"Graphics\spriteki"),13,23,new Vector2(50,78)));

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                a += 2;
                player.Update(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                a -= 2;
                player.Update(gameTime);
            }
            //NOT REALISTIC(CANNOT MOVE UP-DOWN) TO BE CHANGED TO JUMP!!
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                b -= 2;
                player.Update(gameTime);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                b += 2;
                player.Update(gameTime);
            }

            //collision detection
            if (Collide())
            {
                col = true;
            }


            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //CHANGE SCREEN COLOR
            GraphicsDevice.Clear(new Color(123, 732, 155));

            // TODO: Add your drawing code here


            background.Draw(spriteBatch);
            player.Drawn(spriteBatch, new Vector2(a, b));
            sock.Draw(spriteBatch);
            if (col)
            {
                dialogbox.Draw(spriteBatch);
            }
            //Interaction.InputBox("Question?", "Title", "Default Text");



            base.Draw(gameTime);
        }
    }
}
