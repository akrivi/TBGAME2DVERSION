using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace TBGAME2DVERSION
{
    class AnimateSprite 
    {
        
            //public int positionX;
            //public int positionY;

            public Texture2D Texture { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
            private int currentFrame;
            private int totalFrames;

            private int timeSinceLastFrame = 0;

            private int millisecondsPerFrame = 100;

            public AnimateSprite(Texture2D texture, int rows, int columns)
            {
                Texture = texture;
                Rows = rows;
                Columns = columns;
                currentFrame = 0;
                totalFrames = Rows * Columns;
            }



            public void Update(GameTime gameTime)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= +millisecondsPerFrame;
                    currentFrame++;
                    timeSinceLastFrame = 0;
                    if (currentFrame == totalFrames)
                    {
                        currentFrame = 0;
                    }
                }
            }

            public void Drawn(SpriteBatch spriteBatch, Vector2 location)
            {
                int width = Texture.Width / Columns;
                int height = Texture.Height / Rows;
                int row = (int)((float)currentFrame / Columns);
                int column = currentFrame % Columns;
                //positionX = (int) location.X;
                //positionY = (int)location.Y;


                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();

            }



            //    public int getlocationX()
            //    {
            //        return positionX;
            //    }
        }
    }


