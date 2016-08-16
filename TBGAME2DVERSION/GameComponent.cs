using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TBGAME2DVERSION
{
    //TO BE OVERIDDEN
    abstract class GameComponent
    {
            private GameObject gameObject;

            //CONSTRUCTOR
            public void Initialize(GameObject g)
            {
                g = gameObject;
            }

            //GET
            public int GetId()
            {
                return gameObject.ID;
            }

            //REMOVE
            public void Remove()
            {
                gameObject.RemoveComponent(this);
            }

            public abstract void Update(double gameTime);
            public abstract void Draw(SpriteBatch spritebatch);
        }
    }


