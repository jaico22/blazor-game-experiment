using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorGameEngine.Models.GraphicGeneration;

namespace BlazoreGameEngine.GraphicsEngine.Interfaces
{
    public interface IGraphicsLayer
    {
        /// <summary>
        /// Returns delegates to draw current frame
        /// </summary>
        /// <typeparam name="Delegate"></typeparam>
        /// <param name=""></param>
        /// <param name=""></param>
        IEnumerable<Func<Task>> DrawFrame(RenderWindow renderWindow, Canvas canvas);
    }
}
