using System;
using BlazoreGameEngine.GraphicsEngine.Interfaces;

namespace BlazorGameEngine.Core.Interfaces
{
    /// <summary>
    /// Primary driver for connecting graphics and controls 
    /// </summary>
    public interface IGameDriver
    {
        /// <summary>
        /// Register a graphics layer with the graphics driver
        /// </summary>
        /// <param name="graphicsLayer"></param>
        void CreateLayer(IGraphicsLayer graphicsLayer, int layerNumber);
    }
}
