using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorGameEngine.Models.GraphicGeneration;

namespace BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Interfaces
{
    public interface IShapeRenderer
    {
        /// <summary>
        /// Return the list of delegates to render the object on the screen
        /// </summary>
        /// <param name="canvas"></param>
        /// <returns></returns>
        Func<Task> Render(RenderWindow renderWindow, Canvas canvas);

        /// <summary>
        /// Returns true if object should render
        /// </summary>
        /// <param name="renderWindow"></param>
        /// <returns></returns>
        bool SetShouldRender(RenderWindow renderWindow);
    }
}
