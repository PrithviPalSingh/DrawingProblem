using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem.DrawingActions
{
    class FillArea : IDrawing
    {
        //public void Draw(char[][] matrix, bool[][] checkMatrix, int x1, int y1, char c)
        //public void Draw(char[][] matrix, params object[] param)
        //{
        //    bool[][] checkMatrix = (bool[][])param[0];
        //    int x1 = (int)param[1];
        //    int y1 = (int)param[2];
        //    char c = (char)param[3];

        //    if (x1 < 1 || y1 < 1 || matrix[y1][x1] == 'x' || matrix[y1][x1] == '-' || matrix[y1][x1] == '|')
        //        return;

        //    matrix[y1][x1] = c;
        //    checkMatrix[y1][x1] = true;

        //    if (x1 > 0 && !checkMatrix[y1][x1 - 1])
        //        Draw(matrix, checkMatrix, x1 - 1, y1, c);

        //    if (x1 < matrix[y1].Length - 1 && !checkMatrix[y1][x1 + 1])
        //        Draw(matrix, checkMatrix, x1 + 1, y1, c);

        //    if (y1 > 0 && !checkMatrix[y1 - 1][x1])
        //        Draw(matrix, checkMatrix, x1, y1 - 1, c);

        //    if (y1 < matrix.Length - 1 && !checkMatrix[y1 + 1][x1])
        //        Draw(matrix, checkMatrix, x1, y1 + 1, c);
        //}

        public void Draw(char[][] matrix, bool[][] checkMatrix = null, char c = ' ', params int[] param)
        {
            int x1 = param[0];
            int y1 = param[1];

            if (x1 < 1 || y1 < 1 || matrix[y1][x1] == 'x' || matrix[y1][x1] == '-' || matrix[y1][x1] == '|')
                return;

            matrix[y1][x1] = c;
            checkMatrix[y1][x1] = true;

            if (x1 > 0 && !checkMatrix[y1][x1 - 1])
                Draw(matrix, checkMatrix, c, x1 - 1, y1);

            if (x1 < matrix[y1].Length - 1 && !checkMatrix[y1][x1 + 1])
                Draw(matrix, checkMatrix, c, x1 + 1, y1);

            if (y1 > 0 && !checkMatrix[y1 - 1][x1])
                Draw(matrix, checkMatrix, c, x1, y1 - 1);

            if (y1 < matrix.Length - 1 && !checkMatrix[y1 + 1][x1])
                Draw(matrix, checkMatrix, c, x1, y1 + 1);
        }
    }
}
