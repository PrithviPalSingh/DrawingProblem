using DrawingProblem.DrawingActions;

namespace DrawingProblem.DrawingFactory
{
    /// <summary>
    /// Factory class that will return object of intened drawing class as per command send accross
    /// </summary>
    class DrawingFactory : IDrawingFactory
    {
        public IDrawing CreateObject(string c)
        {
            IDrawing drawing = null;
            switch (c)
            {
                case "C":
                    drawing = new CreateCanvas();
                    break;
                case "L":
                    drawing = new CreateNewLine();
                    break;
                case "R":
                    drawing = new CreateRectangle();
                    break;
                case "B":
                    drawing = new FillArea();
                    break;
                default:
                    break;
            }

            return drawing;
        }
    }
}
