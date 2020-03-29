using System;
using BlazoreGameEngine.GraphicsEngine.Interfaces;
using BlazorGameEngine.Core.Interfaces;

namespace BlazorGameEngine.Core.Implementation
{
    public class GameDriver : IGameDriver
    {
        private readonly IGraphicsDriver _graphicsDriver;

        public GameDriver(IGraphicsDriver graphicsDriver)
        {
            _graphicsDriver = graphicsDriver;
        }

        public void CreateLayer(IGraphicsLayer graphicsLayer, int layerNumber)
        {
            _graphicsDriver.RegisterLayer(graphicsLayer, layerNumber);
        }
    }
}
