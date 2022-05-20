using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D tribbleGreyTexture;
        Rectangle tribbleGreyRect;
        Vector2 tribbleGreySpeed;
        Texture2D tribbleCreamTexture;
        Rectangle tribbleCreamRect;
        Vector2 tribbleCreamSpeed;
        Texture2D tribbleBrownTexture;
        Rectangle tribbleBrownRect;
        Vector2 tribbleBrownSpeed;
        Texture2D tribbleOrangeTexture;
        Rectangle tribbleOrangeRect;
        Vector2 tribbleOrangeSpeed;
        List<Color> tribbleColourMaskList = new List<Color>() {Color.Red, Color.Blue, Color.Green, Color.LimeGreen, Color.Pink, Color.Purple, Color.Orange, Color.Yellow, Color.CornflowerBlue, Color.Indigo, Color.Aquamarine, Color.White, Color.Brown, Color.Black, Color.DeepSkyBlue, Color.Coral};
        Random generator = new Random();
        int generatorStored;
        int tribbleBrownXLocation;
        List<Color> backgroundColourMask = new List<Color>() { Color.AliceBlue, Color.AntiqueWhite, Color.Aqua, Color.Aquamarine, Color.Azure, Color.Beige, Color.Bisque, Color.Black, Color.BlanchedAlmond, Color.Blue, Color.BlueViolet, Color.Brown, Color.BurlyWood, Color.CadetBlue, Color.Chartreuse, Color.Chocolate, Color.Coral, Color.CornflowerBlue, Color.Cornsilk, Color.Crimson, Color.Cyan, Color.DarkBlue, Color.DarkCyan, Color.DarkGoldenrod, Color.DarkGray, Color.DarkGreen, Color.DarkKhaki, Color.DarkMagenta, Color.DarkOliveGreen, Color.DarkOrange, Color.DarkOrchid, Color.DarkRed, Color.DarkSalmon, Color.DarkSeaGreen, Color.DarkSlateBlue, Color.DarkSlateGray, Color.DarkTurquoise, Color.DarkViolet, Color.DeepPink, Color.DeepSkyBlue, Color.DimGray, Color.DodgerBlue, Color.Firebrick, Color.FloralWhite, Color.ForestGreen, Color.Fuchsia, Color.Gainsboro, Color.GhostWhite, Color.Gold, Color.Goldenrod, Color.Gray, Color.Green, Color.GreenYellow, Color.Honeydew, Color.HotPink, Color.IndianRed, Color.Indigo, Color.Ivory, Color.Khaki, Color.Lavender, Color.LavenderBlush, Color.LawnGreen, Color.LemonChiffon, Color.LightBlue, Color.LightCoral, Color.LightCyan, Color.LightGoldenrodYellow, Color.LightGray, Color.LightGreen, Color.LightPink, Color.LightSalmon, Color.LightSeaGreen, Color.LightSkyBlue, Color.LightSlateGray, Color.LightSteelBlue, Color.LightYellow, Color.Lime, Color.LimeGreen, Color.Linen, Color.Magenta, Color.Maroon, Color.MediumAquamarine, Color.MediumBlue, Color.MediumOrchid, Color.MediumPurple, Color.MediumSeaGreen, Color.MediumSlateBlue, Color.MediumSpringGreen, Color.MediumTurquoise, Color.MediumVioletRed, Color.MidnightBlue, Color.MintCream, Color.MistyRose, Color.Moccasin, Color.MonoGameOrange, Color.NavajoWhite, Color.Navy, Color.OldLace, Color.Olive, Color.OliveDrab, Color.Orange, Color.OrangeRed, Color.Orchid, Color.PaleGoldenrod, Color.PaleGreen, Color.PaleTurquoise, Color.PaleVioletRed, Color.PapayaWhip, Color.PeachPuff, Color.Peru, Color.Pink, Color.Plum, Color.PowderBlue, Color.Purple, Color.Red, Color.RosyBrown, Color.RoyalBlue, Color.SaddleBrown, Color.Salmon, Color.SandyBrown, Color.SeaGreen, Color.SeaShell, Color.Sienna, Color.Silver, Color.SkyBlue, Color.SlateBlue, Color.SlateGray, Color.Snow, Color.SpringGreen, Color.SteelBlue, Color.Tan, Color.Teal, Color.Thistle, Color.Tomato, Color.Transparent, Color.Turquoise, Color.Violet, Color.Wheat, Color.White, Color.WhiteSmoke, Color.Yellow, Color.YellowGreen };
        int colourGeneration;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            generatorStored = generator.Next(tribbleColourMaskList.Count);
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            this.Window.Title = "Tribbles";
            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            tribbleGreySpeed = new Vector2(32, 0);
            tribbleCreamSpeed = new Vector2(75, 1);
            tribbleBrownSpeed = new Vector2(0, 50);
            tribbleOrangeSpeed = new Vector2(60, 1);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleGreyRect = new Rectangle(300, 620, 100, 100);
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleCreamRect = new Rectangle(300, 10, 100, 100);
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            tribbleBrownRect = new Rectangle(300, 100, 100, 100);
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleOrangeRect = new Rectangle(300, 100, 100, 100);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            tribbleGreyRect.X += (int)tribbleGreySpeed.X;
            tribbleGreyRect.Y += (int)tribbleGreySpeed.Y;
            tribbleCreamRect.X += (int)tribbleCreamSpeed.X;
            tribbleCreamRect.Y += (int)tribbleCreamSpeed.Y;
            tribbleBrownRect.X += (int)tribbleBrownSpeed.X;
            tribbleBrownRect.Y += (int)tribbleBrownSpeed.Y;
            tribbleOrangeRect.X += (int)tribbleOrangeSpeed.X;
            tribbleOrangeRect.Y += (int)tribbleOrangeSpeed.Y;


            if (tribbleGreyRect.Right > _graphics.PreferredBackBufferWidth || tribbleGreyRect.X < 0)
            {
                tribbleGreySpeed.X *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);

            }    
            if (tribbleGreyRect.Top < 0 || tribbleGreyRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleGreySpeed.Y *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);
            }
                
            if (tribbleCreamRect.Right > _graphics.PreferredBackBufferWidth || tribbleCreamRect.X < 0)
            {
                tribbleCreamSpeed.X *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);
                generatorStored = generator.Next(tribbleColourMaskList.Count);
            }
                
            if (tribbleCreamRect.Top < 0 || tribbleCreamRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleCreamSpeed.Y *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);
                generatorStored = generator.Next(tribbleColourMaskList.Count);
            }
                
            if (tribbleBrownRect.Right > _graphics.PreferredBackBufferWidth || tribbleBrownRect.X < 0)
            {
                tribbleBrownSpeed.X *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);
            }
                
            if (tribbleBrownRect.Top < 0 || tribbleBrownRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleBrownXLocation = generator.Next(_graphics.PreferredBackBufferWidth);
                tribbleBrownRect = new Rectangle(tribbleBrownXLocation, 0, 100, 100);
                colourGeneration = generator.Next(backgroundColourMask.Count);
            }
                
            if (tribbleOrangeRect.Right > _graphics.PreferredBackBufferWidth || tribbleOrangeRect.X < 0)
            {
                tribbleOrangeSpeed.X *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);
            }
                
            if (tribbleOrangeRect.Top < 0 || tribbleOrangeRect.Bottom > _graphics.PreferredBackBufferHeight)
            {
                tribbleOrangeSpeed.Y *= -1;
                colourGeneration = generator.Next(backgroundColourMask.Count);
            }
                

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColourMask[colourGeneration]);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(tribbleGreyTexture, tribbleGreyRect, Color.White);
            _spriteBatch.Draw(tribbleCreamTexture, tribbleCreamRect, tribbleColourMaskList[generatorStored]);
            _spriteBatch.Draw(tribbleBrownTexture, tribbleBrownRect, Color.White);
            _spriteBatch.Draw(tribbleOrangeTexture, tribbleOrangeRect, Color.White);
            


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
