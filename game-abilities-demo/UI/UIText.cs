﻿using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace GameAbilitiesDemo
{
    class UIText : Actor
    {

        public string Text;
        public int Width;
        public int Height;
        public int FontSize;
        public Font Font;
        public Color FontColor;

        /// <summary>
        /// Sets the starting values for the text box
        /// </summary>
        /// <param name="x">The x position of the text box</param>
        /// <param name="y">The y position of the text box</param>
        /// <param name="name">The name of the text box</param>
        /// <param name="color">The color of the text</param>
        /// <param name="width">How wide the text box is</param>
        /// <param name="height">How tall the text box is</param>
        /// <param name="text">The tex that will be displayed</param>
        public UIText(float x, float y, float z, Shape shape, string name, Color color, int width,
            int height, int fontSize, string text = "")
            : base(x, y, z, shape, color, name)
        {
            Text = text;
            Width = width;
            Height = height;
            FontColor = color;
            FontSize = fontSize;
            Font = Raylib.LoadFont("resources/fonts/alagard.png");
        }
        public override void Draw()
        {
            //Creating rectangle to use inside of Raylib's draw function
            Rectangle textBox = new Rectangle(WorldPosition.X, WorldPosition.Y, Width, Height);

            //Raylib.DrawRectangleRec(textBox, Color.BLACK);
            //Raylib's text box
            Raylib.DrawTextRec(Font, Text, textBox, FontSize, 1, true, FontColor);
        }
    }
}
