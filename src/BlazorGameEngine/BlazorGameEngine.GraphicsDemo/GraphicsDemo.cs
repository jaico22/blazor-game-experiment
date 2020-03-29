using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.Models;
using BlazorGameEngine.Core.Interfaces;
using BlazorGameEngine.Models.Common;

namespace BlazorGameEngine.GraphicsDemo
{
    public class GraphicsDemoProgram
    {
        private readonly IGameDriver _gameDriver;

        // Layer Data
        // The graphics layer is not responsible for managing objects.
        // Each rectangle object will be registered with the demo layer,
        // but the game logic is resonsible for managing how these objects change.
        private DemoLayer _demoLayer0;
        private List<Rectangle> _demoLayer0Rectangles;
        private DemoLayer _demoLayer1;
        private List<Rectangle> _demoLayer1Rectangles;

        public GraphicsDemoProgram(IGameDriver gameDriver)
        {
            // Inject game driver and create demo layers
            _gameDriver = gameDriver;
            _demoLayer0 = new DemoLayer();
            _demoLayer1 = new DemoLayer();

            // Register graphic layers with the graphics engine
            RegisterGraphicLayers();

            // Initialize objects used for testing
            InitializeLayers();
        }

        public async Task ExecuteAsync()
        {
            while (true)
            {
                // Randomize Rectangles
                RandomizeRectangles(_demoLayer0Rectangles);
                RandomizeRectangles(_demoLayer1Rectangles);

                await Task.Delay(32);
            }
        }

        private void RegisterGraphicLayers()
        {
            _gameDriver.CreateLayer(_demoLayer0, 0);
            _gameDriver.CreateLayer(_demoLayer1, 1);
        }

        private void InitializeLayers()
        {
            // Add 50 random rectangles to each demo layer
            for(int i = 0; i < 50; i++)
            {
                _demoLayer0Rectangles.Add(new Rectangle());
                _demoLayer0.RegisterShape(_demoLayer0Rectangles[i]);

                _demoLayer1Rectangles.Add(new Rectangle());
                _demoLayer1.RegisterShape(_demoLayer1Rectangles[i]);

            }
        }

        private void RandomizeRectangles(List<Rectangle> rectangles)
        {
            var random = new Random();
            var colors = new string[] { "green", "red", "blue", "pink", "yellow" };
            foreach (var rectangle in rectangles)
            {
                rectangle.Height = random.Next(3, 50);
                rectangle.Width = random.Next(3, 50);
                rectangle.Position = new Pose(random.Next(0, 300), random.Next(0, 200));
                rectangle.FillColor = colors[random.Next(0, colors.Length)];
            }
        }
        
    }
}
