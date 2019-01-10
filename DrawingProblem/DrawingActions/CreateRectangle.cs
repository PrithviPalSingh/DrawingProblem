using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem.DrawingActions
{
    class CreateRectangle : IDrawing
    {
        //public void Draw(char[][] matrix, params T[] param)
        //{
        //    //T x1 = param[0];
        //    //T y1 = param[1];
        //    //T x2 = param[2];
        //    //T y2 = param[3];

        //    //for (int i = 0; i < matrix.Length; i++)
        //    //{
        //    //    for (int j = 0; j < matrix[i].Length; j++)
        //    //    {
        //    //        if ((i == y1 || i == y2) && j >= x1 && j <= x2)
        //    //        {
        //    //            matrix[i][j] = 'x';
        //    //        }

        //    //        if ((j == x1 || j == x2) && i >= y1 && i <= y2)
        //    //        {
        //    //            matrix[i][j] = 'x';
        //    //        }
        //    //    }
        //    //}
        //}

        public void Draw(char[][] matrix, bool[][] checkMatrix = null, char c = ' ', params int[] param)
        {
            int x1 = param[0];
            int y1 = param[1];
            int x2 = param[2];
            int y2 = param[3];

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if ((i == y1 || i == y2) && j >= x1 && j <= x2)
                    {
                        matrix[i][j] = 'x';
                    }

                    if ((j == x1 || j == x2) && i >= y1 && i <= y2)
                    {
                        matrix[i][j] = 'x';
                    }
                }
            }
        }
    }
}
