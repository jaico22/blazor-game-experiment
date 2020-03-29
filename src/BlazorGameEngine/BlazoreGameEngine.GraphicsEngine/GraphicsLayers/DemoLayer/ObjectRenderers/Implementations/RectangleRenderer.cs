using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.Models;
using BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Interfaces;
using BlazorGameEngine.Models.Common;
using BlazorGameEngine.Models.GraphicGeneration;

namespace BlazoreGameEngine.GraphicsEngine.GraphicsLayers.DemoLayer.ObjectRenderers.Implementations
{
    public class RectangleRenderer : IShapeRenderer
    {
        private readonly Rectangle _rectangle;

        public bool? ShouldRender { get; set; }

        public RectangleRenderer(Rectangle rectangle)
        {
            _rectangle = rectangle;
        }

        public Func<Task> Render(RenderWindow renderWindow, Canvas canvas)
        {
            if (!ShouldRender.HasValue)
            {
                throw new Exception("Object render state was not set");
            }

            if (ShouldRender.Value)
            {
                ShouldRender = null;

                return async () =>
                {
                    await canvas.Context.SetFillStyleAsync(_rectangle.FillColor);
                    await canvas.Context.FillRectAsync(_rectangle.Position.X, _rectangle.Position.Y,
                        _rectangle.Width, _rectangle.Height);
                };
            }

            // Return an empty task if called erroneously 
            return async () => { };
        }

        public bool SetShouldRender(RenderWindow renderWindow)
        {
            _rectangle.TopLeftCornerBasePosition = new Pose(_rectangle.Position.X - _rectangle.Width / 2,
                    _rectangle.Position.Y - _rectangle.Height / 2);

            _rectangle.BottomRightCornerBasePosition = new Pose(_rectangle.Position.X + _rectangle.Width / 2,
                    _rectangle.Position.Y + _rectangle.Height / 2);

            var underTopLeftWindowCorner =
                _rectangle.BottomRightCornerBasePosition.X >= renderWindow.TopLeftCorner.X &&
                _rectangle.BottomRightCornerBasePosition.Y <= renderWindow.TopLeftCorner.Y;

            var overBottomRightWindowCorner =
                _rectangle.TopLeftCornerBasePosition.X <= renderWindow.BottomRightCorner.X &&
                _rectangle.TopLeftCornerBasePosition.Y >= renderWindow.BottomRightCorner.Y;

            if (!underTopLeftWindowCorner || !overBottomRightWindowCorner)
            {
                ShouldRender = false;
                return false;
            }

            ShouldRender = true;
            _rectangle.RenderPosition = _rectangle.TopLeftCornerBasePosition - renderWindow.BottomLeftCorner;

            return true;
        }
    }
}
