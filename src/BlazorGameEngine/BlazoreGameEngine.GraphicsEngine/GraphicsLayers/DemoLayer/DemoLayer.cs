using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.Models;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Implementations;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Interfaces;
using BlazoreGameEngine.GraphicsEngine.Interfaces;
using BlazorGameEngine.Models.GraphicGeneration;

namespace BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer
{
    /// <summary>
    /// Demo of layer and graphics driver logic
    /// </summary>
    public class DemoLayer : IGraphicsLayer
    {
        private readonly IList<IShapeRenderer> _shapeRenderers;

        public IEnumerable<Func<Task>> DrawFrame(RenderWindow renderWindow, Canvas canvas)
        {
            var funcList = new List<Func<Task>>();

            foreach(var shapeRenderer in _shapeRenderers)
            {
                var shouldRender = shapeRenderer.SetShouldRender(renderWindow);
                if (shouldRender)
                {
                    funcList.Add(shapeRenderer.Render(renderWindow, canvas));
                }
            }

            return funcList;
        }

        /// <summary>
        /// Regiser a shape object with with the graphics layer. 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public void RegisterShape(Rectangle rectangle)
        {
            // Create and register shape render
            _shapeRenderers.Add(new RectangleRenderer(rectangle));
        }

    }
}
