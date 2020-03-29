using System;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Interfaces;
using BlazorGameEngine.Models.Common;

namespace BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.Models
{
    public class ShapeObject
    {
        /// <summary>
        /// Shape to render
        /// </summary>
        public Shapes Shape { get; set; }

        /// <summary>
        /// Fill color of shape
        /// </summary>
        public string FillColor { get; set; }

        /// <summary>
        /// Rendere to generate the shape
        /// </summary>
        public IShapeRenderer Renderer { get; set; }

        /// <summary>
        /// Position of the shape
        /// </summary>
        public Pose Position { get; set; }
    }
}
