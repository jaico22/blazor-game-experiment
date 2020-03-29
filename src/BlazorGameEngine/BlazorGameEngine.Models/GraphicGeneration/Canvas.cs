using Blazor.Extensions.Canvas.Canvas2D;

namespace BlazorGameEngine.Models.GraphicGeneration
{
    public class Canvas
    {
        public Canvas2DContext Context { get; set; }

        public int CanvasWidth { get; set; }

        public int CanvasHeight { get; set; }

        public Canvas(Canvas2DContext context, int height, int width)
        {
            Context = context;
            CanvasHeight = height;
            CanvasWidth = width;
        }
    }
}

