using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace TBGAME2DVERSION
{
    class backgroundsprite:Sprite
    {

            private Texture2D sprite1;
            private int widt;
            private int heigh;
            private Vector2 positio;
            //private float layerDepth;

            public backgroundsprite(Texture2D sp, int w, int h, Vector2 p) : base(sp, w, h, p)
            {
                sprite1 = sp;
                widt = w;
                heigh = h;
                positio = p;
                //layerDepth = l;
            }

            public override void Draw(SpriteBatch spritebatch)
            {
                spritebatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
                spritebatch.Draw(sprite1, new Rectangle((int)positio.X, (int)positio.Y, widt, heigh), Color.White);
                spritebatch.End();
            }
        }
    }

