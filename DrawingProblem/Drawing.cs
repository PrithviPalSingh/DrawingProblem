using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem
{
    class Drawing //: IDrawing
    {
        public void CreateCanvas(char[][] matrix, int w, int h)
        {
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

        public void CreateNewLine(char[][] matrix, int x1, int y1, int x2, int y2)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (i >= y1 && i <= y2 && j >= x1 && j <= x2)
                    {
                        matrix[i][j] = 'x';
                    }
                }
            }
        }

        public void CreateRectangle(char[][] matrix, int x1, int y1, int x2, int y2)
        {
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

        public void FillColor(char[][] matrix, bool[][] checkMatrix, int x1, int y1, char c)
        {
            if (x1 < 1 || y1 < 1 || matrix[y1][x1] == 'x' || matrix[y1][x1] == '-' || matrix[y1][x1] == '|')
                return;

            matrix[y1][x1] = c;
            checkMatrix[y1][x1] = true;

            if (x1 > 0 && !checkMatrix[y1][x1 - 1])
                FillColor(matrix, checkMatrix, x1 - 1, y1, c);

            if (x1 < matrix[y1].Length - 1 && !checkMatrix[y1][x1 + 1])
                FillColor(matrix, checkMatrix, x1 + 1, y1, c);

            if (y1 > 0 && !checkMatrix[y1 - 1][x1])
                FillColor(matrix, checkMatrix, x1, y1 - 1, c);

            if (y1 < matrix.Length - 1 && !checkMatrix[y1 + 1][x1])
                FillColor(matrix, checkMatrix, x1, y1 + 1, c);
        }

        public void DrawCanvas(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }

                Console.WriteLine();
            }
        }
    }
}
