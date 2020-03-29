using System;
using BlazorGameEngine.Models.Common;

namespace BlazorGameEngine.Models.GraphicGeneration
{
    /// <summary>
    /// Base model of all render objects.
    /// This model is fairly usefull by itself and should be extended
    /// </summary>
    public class BaseRenderObject
    {
        /// <summary>
        /// Center location of object
        /// </summary>
        public Pose CenterLocation { get; set; }

        /// <summary>
        /// Number of pixels wide the object will be
        /// </summary>
        public int RenderWidth { get; set; }

        /// <summary>
        /// Number of pixel high the object will be
        /// </summary>
        public int RenderHeight { get; set; }
    }
}
