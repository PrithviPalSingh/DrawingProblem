using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int w = -1; int h = -1;
            int x1 = -1; int y1 = -1;
            int x2 = -1; int y2 = -1;
            char c = ' ';
            char[][] matrix = null; bool[][] checkMatrix = null;
            IDrawingFactory df = new DrawingFactory.DrawingFactory();
            IDrawing drawing = null;

            bool IssueCommand = true;
            while (IssueCommand)
            {
                Console.Write("Enter command: ");
                string[] command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                string action = command.Length > 0 ? command[0].ToUpper() : string.Empty;

                if (action == "Q") {
                    Console.WriteLine("Press enter to exit!!");
                    IssueCommand = false;
                    break;
                }

                drawing = df.CreateObject(action);

                if (drawing == null)
                {
                    Console.WriteLine("Invalid command!! Please re-enter");
                    continue;
                }

                switch (action)
                {
                    case "C":
                        if (command.Length != 3)
                        {
                            Console.WriteLine("Improper create command!!");
                            break;
                        }

                        w = Convert.ToInt32(command[1]);
                        h = Convert.ToInt32(command[2]);
                        matrix = new char[h + 2][];
                        checkMatrix = new bool[h + 2][];
                        InitiateCheckMatrix(w, checkMatrix);
                        drawing.Draw(matrix, checkMatrix, ' ', w, h);
                        Utilities.Utilities.DrawCanvas(matrix);
                        break;
                    case "L":
                        if (matrix == null)
                        {
                            Console.WriteLine("Create canvas before issuing this command");
                            break;
                        }

                        if (command.Length != 5)
                        {
                            Console.WriteLine("Improper new line command!!");
                            break;
                        }

                        x1 = Convert.ToInt32(command[1]);
                        y1 = Convert.ToInt32(command[2]);
                        x2 = Convert.ToInt32(command[3]);
                        y2 = Convert.ToInt32(command[4]);
                        drawing.Draw(matrix, checkMatrix, ' ', x1, y1, x2, y2);
                        Utilities.Utilities.DrawCanvas(matrix);
                        break;
                    case "R":

                        if (matrix == null)
                        {
                            Console.WriteLine("Create canvas before issuing this command");
                            break;
                        }

                        if (command.Length != 5)
                        {
                            Console.WriteLine("Improper rectangle line command!!");
                            break;
                        }

                        x1 = Convert.ToInt32(command[1]);
                        y1 = Convert.ToInt32(command[2]);
                        x2 = Convert.ToInt32(command[3]);
                        y2 = Convert.ToInt32(command[4]);
                        drawing.Draw(matrix, checkMatrix, ' ', x1, y1, x2, y2);
                        Utilities.Utilities.DrawCanvas(matrix);
                        break;
                    case "B":
                        if (matrix == null)
                        {
                            Console.WriteLine("Create canvas before issuing this command!!");
                            break;
                        }

                        if (command.Length != 4)
                        {
                            Console.WriteLine("Improper fill command!!");
                            break;
                        }

                        x1 = Convert.ToInt32(command[1]);
                        y1 = Convert.ToInt32(command[2]);
                        c = Convert.ToChar(command[3]);
                        drawing.Draw(matrix, checkMatrix, c, x1, y1);
                        Utilities.Utilities.DrawCanvas(matrix);
                        break;                   
                    default:
                        break;
                }
            }

            Console.Read();
        }

        //private static void OldMethod(ref int w, ref int h, ref int x1, ref int y1, ref int x2, ref int y2, ref char c, ref char[][] matrix, ref bool[][] checkMatrix)
        //{
        //    bool IssueCommad = true;

        //    IDrawing draw = new Drawing();

        //    while (IssueCommad)
        //    {
        //        Console.Write("Enter command: ");
        //        string[] command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        //        switch (command[0].ToUpper())
        //        {
        //            case "C":
        //                if (command.Length != 3)
        //                {
        //                    Console.WriteLine("Improper create command!!");
        //                    break;
        //                }

        //                w = Convert.ToInt32(command[1]);
        //                h = Convert.ToInt32(command[2]);
        //                matrix = new char[h + 2][];
        //                checkMatrix = new bool[h + 2][];
        //                InitiateCheckMatrix(w, checkMatrix);
        //                draw.CreateCanvas(matrix, w, h);
        //                draw.DrawCanvas(matrix);
        //                break;
        //            case "L":
        //                if (matrix == null)
        //                {
        //                    Console.WriteLine("Create canvas before issuing this command");
        //                    break;
        //                }

        //                if (command.Length != 5)
        //                {
        //                    Console.WriteLine("Improper new line command!!");
        //                    break;
        //                }

        //                x1 = Convert.ToInt32(command[1]);
        //                y1 = Convert.ToInt32(command[2]);
        //                x2 = Convert.ToInt32(command[3]);
        //                y2 = Convert.ToInt32(command[4]);
        //                draw.CreateNewLine(matrix, x1, y1, x2, y2);
        //                draw.DrawCanvas(matrix);
        //                break;
        //            case "R":

        //                if (matrix == null)
        //                {
        //                    Console.WriteLine("Create canvas before issuing this command");
        //                    break;
        //                }

        //                if (command.Length != 5)
        //                {
        //                    Console.WriteLine("Improper rectangle line command!!");
        //                    break;
        //                }

        //                x1 = Convert.ToInt32(command[1]);
        //                y1 = Convert.ToInt32(command[2]);
        //                x2 = Convert.ToInt32(command[3]);
        //                y2 = Convert.ToInt32(command[4]);
        //                draw.CreateRectangle(matrix, x1, y1, x2, y2);
        //                draw.DrawCanvas(matrix);
        //                break;
        //            case "B":
        //                if (matrix == null)
        //                {
        //                    Console.WriteLine("Create canvas before issuing this command!!");
        //                    break;
        //                }

        //                if (command.Length != 4)
        //                {
        //                    Console.WriteLine("Improper fill command!!");
        //                    break;
        //                }

        //                x1 = Convert.ToInt32(command[1]);
        //                y1 = Convert.ToInt32(command[2]);
        //                c = Convert.ToChar(command[3]);
        //                draw.FillColor(matrix, checkMatrix, x1, y1, c);
        //                draw.DrawCanvas(matrix);
        //                break;
        //            case "Q":
        //                Console.WriteLine("Press any key to exit!!");
        //                IssueCommad = false;
        //                break;
        //            default:
        //                Console.WriteLine("Invalid command!! Please re-enter");
        //                break;
        //        }
        //    }
        //}

        private static void InitiateCheckMatrix(int w, bool[][] checkMatrix)
        {
            for (int i = 0; i < checkMatrix.Length; i++)
            {
                checkMatrix[i] = new bool[w + 2];
            }
        }
    }
}
