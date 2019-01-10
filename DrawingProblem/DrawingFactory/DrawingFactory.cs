using DrawingProblem.DrawingActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem.DrawingFactory
{
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
