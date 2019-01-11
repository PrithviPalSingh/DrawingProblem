using DrawingProblem.Models;
using DrawingProblem.Utilities;
using System;
using System.Collections.Generic;

namespace DrawingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int width = -1;
                int height = -1;
                char c = ' ';
                char[][] matrix = null;

                bool IssueCommand = true;
                while (IssueCommand)
                {                    
                    Console.Write(Constants.EnterCommandMessage);
                    string[] command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    if (command.Length == 0)
                    {
                        Console.WriteLine(Constants.NoCommandMessage);
                        continue;
                    }

                    List<Point> list = new List<Point>();
                    bool hasError = false;
                    IssueCommand = ProcessCommand(command, list, ref matrix, ref width, ref height,
                        ref c, ref hasError);

                    if (!hasError)
                    {
                        IDrawingFactory df = new DrawingFactory.DrawingFactory();
                        IDrawing drawing = null;
                        drawing = df.CreateObject(command[0].ToUpper());
                        drawing.Draw(matrix, list, c);
                        Utilities.Utilities.DrawCanvas(matrix);
                    }

                    Console.WriteLine();
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(Constants.ExitMessage);
            }
            finally
            {
                Console.Read();
            }
        }

        /// <summary>
        /// Process command and perform following tasks
        ///     - Store inputs as per the command e.g. list of points
        ///     - creat matrix to hold canvas information
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="c"></param>
        /// <param name="matrix"></param>
        /// <param name="command"></param>
        /// <param name="action"></param>
        /// <param name="list"></param>
        private static bool ProcessCommand(string[] command, List<Point> list, ref char[][] matrix,
            ref int width, ref int height, ref char c, ref bool hasError)
        {
            bool issueCommand = true;
            switch (command[0].ToUpper())
            {
                case "C":
                    if (command.Length != 3)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.ImproperCreateCommandMessage);
                        break;
                    }

                    width = Convert.ToInt32(command[1]);
                    height = Convert.ToInt32(command[2]);

                    if (width <= 0 || height <= 0) {
                        hasError = true;
                        Console.WriteLine(Constants.CannotCreateCanvasMessage);
                        break;
                    }

                    list.Add(new Point { X = width, Y = height });
                    matrix = new char[height + 2][];
                    break;
                case "L":
                    if (matrix == null)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.CanvasNotPresentMessage);
                        break;
                    }

                    if (command.Length != 5)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.ImproperNewLineCommandMessage);
                        break;
                    }

                    list.Add(new Point { X = Convert.ToInt32(command[1]), Y = Convert.ToInt32(command[2]) });
                    list.Add(new Point { X = Convert.ToInt32(command[3]), Y = Convert.ToInt32(command[4]) });

                    break;
                case "R":

                    if (matrix == null)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.CanvasNotPresentMessage);
                        break;
                    }

                    if (command.Length != 5)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.ImproperRectangleCommandMessage);
                        break;
                    }

                    list.Add(new Point { X = Convert.ToInt32(command[1]), Y = Convert.ToInt32(command[2]) });
                    list.Add(new Point { X = Convert.ToInt32(command[3]), Y = Convert.ToInt32(command[4]) });

                    break;
                case "B":
                    if (matrix == null)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.CanvasNotPresentMessage);
                        break;
                    }

                    if (command.Length != 4)
                    {
                        hasError = true;
                        Console.WriteLine(Constants.ImproperFillCommandMessage);
                        break;
                    }

                    list.Add(new Point { X = Convert.ToInt32(command[1]), Y = Convert.ToInt32(command[2]) });
                    c = Convert.ToChar(command[3]);

                    break;
                case "Q":
                    hasError = true;
                    issueCommand = false;
                    Console.WriteLine(Constants.ExitMessage);
                    break;
                default:
                    hasError = true;
                    Console.WriteLine(Constants.BadCommandMessage);
                    break;
            }

            if (!hasError && !Utilities.Utilities.ValidCoordinates(list, width, height))
            {
                hasError = true;
                Console.WriteLine(Constants.CoordinatesOutsideCanvasMessage);
            }

            return issueCommand;
        }
    }
}
