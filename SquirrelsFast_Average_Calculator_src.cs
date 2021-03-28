using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SquirrelsFastAverageCalculator
{
    class Program
    {
        public static int commandResult, commandResult2;
        public static string command = "Wrong command! Try again!";
        public static string format = "Wrong format! Try again!";

        public static void Choose()
        {
            bool state = true;
            while (state)
            {
                if (commandResult == -2 || commandResult == -3)
                {
                    state = false;
                    if (commandResult2 == -2)
                    {
                        Environment.Exit(0);
                    }
                    else if (commandResult2 == -3)
                    {
                        Input();
                    }
                }   
                else
                {
                    try
                    {
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("Wrong command! Try again!");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("Enter the command: ");
                        string commandInput2 = Console.ReadLine();
                        commandResult2 = int.Parse(commandInput2);

                        if (commandResult2 == -2)
                        {
                            Environment.Exit(0);
                        }
                        else if (commandResult2 == -3)
                        {
                            Input();
                        }
                    }
                    catch (FormatException)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("");
                        Console.WriteLine(format);
                    }

                }
            }
        }

        public static void Start()
        {
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            Console.WriteLine("SquirrelsFast - AVERAGE CALCULATOR ALPHA 1.0 - 2021.03.28");
            Console.WriteLine("");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** RULES ***");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("ONLY THE FIVE-POINT SCALE GRADING SYSTEM ALLOWED HERE!");
            Console.WriteLine("IT MEANS, THAT YOU CAN ONLY ENTER NUMBERS BETWEEN 1 AND 5");
            Console.WriteLine("THE ENTERED NUMBER HAS TO BE A FLOAT WITH A COMMA, LIKE 2,8");
            Console.WriteLine("OR A WHOLE NUMBER, LIKE 4");
            Console.WriteLine("YOU CAN'T ENTER NUMBERS LONGER THAN 20");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("*** USER GUIDE ***");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("1. TYPE THE SCORE");
            Console.WriteLine("2. PRESS ENTER");
            Console.WriteLine("3. TYPE THE NEXT ONE");
            Console.WriteLine("YOU CAN GET THE RESULT WITH THE -1 COMMAND!");
        }

        public static void Input()
        {
            float score = 0f;
            float result = 0f;
            float average = 0f;
            float student = 0f;
            bool wait = true;

            while (wait)
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter the score: ");
                try
                {
                    string input = Console.ReadLine();
                    int scoreLength = input.Length;
                    if (scoreLength > 20)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("");
                        Console.WriteLine("It's too long, enter again!");
                        continue;
                    }
                    else
                    {
                        score = float.Parse(input);
                        if (score == -1)
                        {
                            wait = false;
                        }
                        else
                        {
                            if (score > -1)
                            {
                                if (score > 5)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("");
                                    Console.WriteLine("The entered number is bigger than 5! Try Again!");
                                }
                                else if (score < 1)
                                {
                                    Console.ForegroundColor = ConsoleColor.DarkRed;
                                    Console.WriteLine("");
                                    Console.WriteLine("The entered number is lower than 1! Try Again!");
                                }
                                else
                                {
                                    result += score;
                                    student += 1;

                                    Console.ForegroundColor = ConsoleColor.Blue;
                                    Console.WriteLine("Values so far: " + result);
                                    if (student == 1)
                                    {
                                        Console.WriteLine("Student: " + student);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Students: " + student);
                                    }
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                Console.WriteLine("");
                                Console.WriteLine(command);
                            }
                        }
                    }

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("");
                    Console.WriteLine(format);
                }
            }

            average = result / student;

            string grade = "";

            if (average <= 5.0f && average >= 4.5f || average > 5)
            {
                grade = "A";
            }
            else if (average <= 4.5f && average >= 3.5f)
            {
                grade = "B";
            }
            else if (average <= 3.5f && average >= 2.5f) 
            {
                grade = "C";
            }
            else if (average <= 2.5f && average >= 1.5f)
            {
                grade = "D";
            }
            else if (average <= 1.5f && average >= 1.0f || average < 1)
            {
                grade = "E/F";
            }

            bool notANumber = Double.IsNaN(average);

            if (notANumber)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("");
                Console.WriteLine("You've entered nothing...");
                Console.WriteLine("Try again!");
                Input();
            }
            else
            {
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("***-------------------- R E S U L T --------------------***");
                Console.WriteLine("");
                Console.WriteLine("STUDENTS: " + student);
                Console.WriteLine("THE AVERAGE SCORE OF THE STUDENTS IS: " + average);
                Console.WriteLine("IT EQUALS TO U.S. GRADE: " + grade);
                Console.WriteLine("");
                Console.WriteLine("***------------------ C O M M A N D S ------------------***");
                Console.WriteLine("");
                Console.WriteLine("ENTER -2 TO EXIT.");
                Console.WriteLine("ENTER -3 TO TRY AGAIN!");
                Console.WriteLine("");
                Console.WriteLine("***----------------------------------------------------***");
                Console.WriteLine("");
                Console.Write("Enter the command: ");
                try
                {
                    string commandInput = Console.ReadLine();
                    commandResult = int.Parse(commandInput);

                    if (commandResult == -2 || commandResult == -3)
                    {
                        if (commandResult == -2)
                        {
                            Environment.Exit(0);
                        }
                        if (commandResult == -3)
                        {
                            Input();
                        }
                    }
                    else Choose();

                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("");
                    Console.WriteLine(format);
                    Choose();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.Title = "SquirrelsFast - Average Calculator";
            Start();
            Input();
            Console.Read();
        }
    }
}