using DrawingProblem.Models;
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
                IDrawingFactory df = new DrawingFactory.DrawingFactory();
                IDrawing drawing = null;

                bool IssueCommand = true;
                while (IssueCommand)
                {
                    Console.Write("Enter command: ");
                    string[] command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    if (command.Length == 0)
                    {
                        Console.WriteLine("No command to execute!! Please re-enter");
                        continue;
                    }

                    List<Point> list = new List<Point>();
                    IssueCommand = ProcessCommand(command, list, ref matrix, ref width, ref height, ref c);

                    if (!Utilities.Utilities.ValidCoordinates(list, width, height))
                    {
                        Console.WriteLine("Improper command!!");
                        Console.WriteLine("1. Either canvas is not created.");
                        Console.WriteLine("2. Coordinates provided are not inside canvas.");
                        Console.WriteLine("Please re-enter command");
                    }
                    else
                    {
                        drawing = df.CreateObject(command[0].ToUpper());
                        if (drawing == null)
                        {
                            Console.WriteLine("Invalid command!! Please re-enter");
                            continue;
                        }

                        drawing.Draw(matrix, list, c);
                        Utilities.Utilities.DrawCanvas(matrix);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("!!!!!Press enter to exit!!!!!!");
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
        private static bool ProcessCommand(string[] command,List<Point> list, ref char[][] matrix, 
            ref int width, ref int height, ref char c)
        {
            bool issueCommand = true;
            switch (command[0].ToUpper())
            {
                case "C":
                    if (command.Length == 3)
                    {
                        //    Console.WriteLine("Improper create command!!");
                        //    break;
                        //}

                        width = Convert.ToInt32(command[1]);
                        height = Convert.ToInt32(command[2]);
                        list.Add(new Point { X = width, Y = height });
                        matrix = new char[height + 2][];
                    }
                    break;
                case "L":
                    if (matrix == null)
                    {
                        Console.WriteLine("Create canvas before issuing this command");
                        break;
                    }

                    if (command.Length == 5)
                    {
                        //    Console.WriteLine("Improper new line command!!");
                        //    break;
                        //}

                        list.Add(new Point { X = Convert.ToInt32(command[1]), Y = Convert.ToInt32(command[2]) });
                        list.Add(new Point { X = Convert.ToInt32(command[3]), Y = Convert.ToInt32(command[4]) });
                    }
                    break;
                case "R":

                    if (matrix == null)
                    {
                        Console.WriteLine("Create canvas before issuing this command");
                        break;
                    }

                    if (command.Length == 5)
                    {
                        //    Console.WriteLine("Improper rectangle line command!!");
                        //    break;
                        //}

                        list.Add(new Point { X = Convert.ToInt32(command[1]), Y = Convert.ToInt32(command[2]) });
                        list.Add(new Point { X = Convert.ToInt32(command[3]), Y = Convert.ToInt32(command[4]) });
                    }
                    break;
                case "B":
                    if (matrix == null)
                    {
                        Console.WriteLine("Create canvas before issuing this command!!");
                        break;
                    }

                    if (command.Length == 4)
                    {
                        //    Console.WriteLine("Improper fill command!!");
                        //    break;
                        //}

                        list.Add(new Point { X = Convert.ToInt32(command[1]), Y = Convert.ToInt32(command[2]) });
                        c = Convert.ToChar(command[3]);
                    }
                    break;
                case "Q":
                    issueCommand = false;
                    Console.WriteLine("Press enter to exit application");
                    break;
                default:
                    break;
            }

            return issueCommand;
        }
    }
}
