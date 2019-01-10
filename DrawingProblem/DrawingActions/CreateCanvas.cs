using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem.DrawingActions
{
    class CreateCanvas : IDrawing
    {
        //public void Draw(char[][] matrix, params int[] param)
        //{
        //    int w = param[0];
        //    int h = param[1];

        //    for (int i = 0; i < h + 2; i++)
        //    {
        //        matrix[i] = new char[w + 2];
        //        for (int j = 0; j < w + 2; j++)
        //        {
        //            if (i == 0 || i == h + 1)
        //            {
        //                matrix[i][j] = '-';
        //            }
        //            else
        //            {
        //                if (j == 0 || j == (w + 1))
        //                {
        //                    matrix[i][j] = '|';
        //                }
        //            }
        //        }
        //    }
        //}

        public void Draw(char[][] matrix, bool[][] checkMatrix = null, char c = ' ', params int[] param)
        {
            int w = param[0];
            int h = param[1];

            for (int i = 0; i < h + 2; i++)
            {
                matrix[i] = new char[w + 2];
                for (int j = 0; j < w + 2; j++)
                {
                    if (i == 0 || i == h + 1)
                    {
                        matrix[i][j] = '-';
                    }
                    else
                    {
                        if (j == 0 || j == (w + 1))
                        {
                            matrix[i][j] = '|';
                        }
                    }
                }
            }
        }
    }
}
