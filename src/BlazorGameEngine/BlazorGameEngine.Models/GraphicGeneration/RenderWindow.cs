using System;
using BlazorGameEngine.Models.Common;

namespace BlazorGameEngine.Models.GraphicGeneration
{
    public class RenderWindow
    {
        /// <summary>
        /// Top left corner where graphics will be rendered
        /// </summary>
        public Pose TopLeftCorner { get; set; }

        /// <summary>
        /// Bottom right corner where graphics will be rendered
        /// </summary>
        public Pose BottomRightCorner { get; set; }

        public Pose BottomLeftCorner { get; set; }

        public RenderWindow(Pose topLeftCorner, Pose bottomRightCorner)
        {
            TopLeftCorner = topLeftCorner;
            BottomRightCorner = bottomRightCorner;
            BottomLeftCorner = topLeftCorner - new Pose(Math.Abs(topLeftCorner.X - bottomRightCorner.X),
                Math.Abs(topLeftCorner.Y - bottomRightCorner.Y));
        }
    }
}
