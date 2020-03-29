using System;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Implementations;
using BlazorGameEngine.Models.Common;

namespace BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.Models
{
    public class Rectangle : ShapeObject
    {
        /// <summary>
        /// Height of the rectangle
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Width of the rectangle
        /// </summary>
        public int Width { get; set; }

        public Rectangle()
        {
            Renderer = new RectangleRenderer(this);
        }

        /// <summary>
        /// Cached base position of the top left corner of the rectangle 
        /// </summary>
        public Pose TopLeftCornerBasePosition { get; set; }

        /// <summary>
        /// Cached base positon of the bottom right corner of the rectangle
        /// </summary>
        public Pose BottomRightCornerBasePosition { get; set; }

        /// <summary>
        /// Cached render position of the object
        /// </summary>
        public Pose RenderPosition { get; set; }
    }
}
