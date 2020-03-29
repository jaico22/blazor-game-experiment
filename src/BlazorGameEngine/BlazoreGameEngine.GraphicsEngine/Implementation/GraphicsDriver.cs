using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazoreGameEngine.GraphicsEngine.Interfaces;
using BlazorGameEngine.Models.GraphicGeneration;

namespace BlazoreGameEngine.GraphicsEngine.Implementation
{
    public class GraphicsDriver : IGraphicsDriver
    {
        private IDictionary<int,IGraphicsLayer> _graphicsLayers;

        private int _numberOfLayers;

        /// <summary>
        /// Call all registered graphic layers to draw frames
        /// </summary>
        /// <param name="renderWindow"></param>
        /// <param name="canvas"></param>
        /// <returns></returns>
        public IEnumerable<Func<Task>> DrawFrame(RenderWindow renderWindow, Canvas canvas)
        {
            var drawingDelegates = new List<Func<Task>>();

            for(int layerNumber = 0; layerNumber <= _numberOfLayers; layerNumber++)
            {
                if (_graphicsLayers.ContainsKey(layerNumber))
                {
                    drawingDelegates = drawingDelegates
                        .Concat(_graphicsLayers[layerNumber].DrawFrame(renderWindow, canvas))
                        .ToList();
                }
            }

            return drawingDelegates;
        }

        /// <summary>
        /// Register a graphics layer with the graphics driver at layer number
        /// specified
        /// </summary>
        /// <param name="graphicsLayer"></param>
        /// <param name="layerNumber"></param>
        public void RegisterLayer(IGraphicsLayer graphicsLayer, int layerNumber)
        {
            if(!_graphicsLayers.TryAdd(layerNumber, graphicsLayer))
            {
                throw new ArgumentException($"A graphics layer has already been " +
                    $"registered at layer {layerNumber}", nameof(layerNumber));
            }

            _numberOfLayers = layerNumber > _numberOfLayers ? layerNumber :
                _numberOfLayers;
        }
    }
}
    