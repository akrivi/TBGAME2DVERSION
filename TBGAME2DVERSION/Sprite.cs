using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TBGAME2DVERSION
{
    class Sprite : GameComponent
    {
        private Texture2D sprite0;
        private int width;
        private int height;
        private Vector2 position;
        //private float layerDepth;

        //CONSTRUCTOR
        public Sprite(Texture2D sp, int w, int h, Vector2 p)
        {
            sprite0 = sp;
            width = w;
            height = h;
            position = p;
            //layerDepth = l;

        }

        public override void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Begin();
            spritebatch.Draw(sprite0, new Rectangle((int)position.X, (int)position.Y, width, height), Color.White);
            spritebatch.End();
        }

        public override void Update(double gameTime)
        {
            throw new NotImplementedException();
        }

        public float getlocationX()
        {
            return position.X;
        }
    }
}

