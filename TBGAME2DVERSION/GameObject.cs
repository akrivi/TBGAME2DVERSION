using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TBGAME2DVERSION
{
    class GameObject
    {
            public int ID { get; set; }
            private List<GameComponent> componentlist;

            //CONSTRUCTOR - LIST STORING ALL COMPONENTS
            public GameObject()
            {
                componentlist = new List<GameComponent>();
            }

            //ADD COMPONENTS
            public void AddComponent(GameComponent c)
            {
                componentlist.Add(c);
                c.Initialize(this);

            }

            //public void AddComponent(List<GameComponent> clist)
            //{
            //    componentlist.AddRange(clist);
            //    foreach (var c in clist)
            //    {
            //        c.Initialize(this);
            //    }
            //}


            //REMOVE COMPONENTS
            public void RemoveComponent(GameComponent c)
            {
                componentlist.Remove(c);
            }

            public void Update(double gameTime)
            {
                foreach (var c in componentlist)
                {
                    c.Update(gameTime);
                }
            }

            public void Draw(SpriteBatch s)
            {
                foreach (var c in componentlist)
                {
                    c.Draw(s);
                }
            }
        }
    }



