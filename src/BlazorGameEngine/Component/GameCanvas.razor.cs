using System;
using System.Threading.Tasks;
using Blazor.Extensions;
using Blazor.Extensions.Canvas.Canvas2D;
using BlazoreGameEngine.GraphicsEngine.Interfaces;
using BlazorGameEngine.Core.Interfaces;
using BlazorGameEngine.Models.GraphicGeneration;
using Microsoft.AspNetCore.Components;
using BlazorGameEngine.GraphicsDemo;

namespace BlazorGameEngine.Component
{
    public partial class GameCanvas : ComponentBase
    {
        private Canvas _canvas;

        private readonly IGameDriver _gameDriver;

        private GraphicsDemoProgram _graphicsDemo;

        protected Canvas2DContext _context;

        protected BECanvasComponent _canvasReference;

        private IGraphicsDriver _graphicsDriver;

        public GameCanvas(IGameDriver gameDriver, IGraphicsDriver graphicsDriver)
        {
            _gameDriver = gameDriver;
            _graphicsDriver = graphicsDriver;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            // Setup Canvas
            _context = _canvasReference.CreateCanvas2D();
            _canvas = new Canvas(_context, 200, 300);

            // Setup and run game
            _graphicsDemo = new GraphicsDemoProgram(_gameDriver);
            await _graphicsDemo.ExecuteAsync();
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            // Create mock render windo
            var renderWindow = new RenderWindow(new Models.Common.Pose(0, 200),
                new Models.Common.Pose(300, 0));

            // Call Graphics driver to draw a frame
            _graphicsDriver.DrawFrame(renderWindow, _canvas);

            // Wait 33ms to regenerate
            await Task.Delay(33);
            StateHasChanged();
        }
    }
}
