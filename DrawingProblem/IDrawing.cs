using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem
{
    public interface IDrawing
    {
        //void CreateCanvas(char[][] matrix, int w, int h);

        //void CreateNewLine(char[][] matrix, int x1, int y1, int x2, int y2);

        //void CreateRectangle(char[][] matrix, int x1, int y1, int x2, int y2);

        //void FillColor(char[][] matrix, bool[][] checkMatrix, int x1, int y1, char c);

        //void DrawCanvas(char[][] matrix);

        void Draw(char[][] matrix, bool[][] checkMatrix = null, char c = ' ', params int[] param);
    }
}
