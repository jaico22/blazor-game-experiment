using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Extensions.Canvas.Canvas2D;
using BlazorGameEngine.Models.GraphicGeneration;

namespace BlazoreGameEngine.GraphicsEngine.Interfaces
{
    /// <summary>
    /// This is the main graphics driver
    /// </summary>
    public interface IGraphicsDriver
    {
        /// <summary>
        /// Register a graphics layer with the graphics driver
        /// </summary>
        /// <param name="graphicsLayer"></param>
        /// <param name="layerNumber"></param>
        void RegisterLayer(IGraphicsLayer graphicsLayer, int layerNumber);

        /// <summary>
        /// Call graphic layers to draw frames
        /// </summary>
        /// <param name="renderWindow"></param>
        /// <param name="canvas2DContext">Canvas context to use for rendering</param>
        /// <returns></returns>
        IEnumerable<Func<Task>> DrawFrame(RenderWindow renderWindow, Canvas canvas);
    }
}
