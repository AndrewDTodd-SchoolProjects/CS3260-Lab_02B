using System.Text.RegularExpressions;

namespace ElectricalResistors
{
    internal class Program
    {
        #region MEMEBERS
        private enum ColorCodesEnum
        {
            Black,
            Brown,
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Violet,
            Grey,
            White
        }

        private static byte[] ColorCodesArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        #endregion

        #region PRIVATE_METHODS
        //Method to take input color as string and return the index associated from the ColorCodesEnum
        //Method will handle case of string
        //Will throw "ArgumentExeption" in the event that the input is unsuported
        private static void GetColorIndexEnum(string color)
        {
            color = color.ToLower();

            switch (color)
            {
                case "black":
                    Console.WriteLine($"Black has an index of: {((byte)ColorCodesEnum.Black)} (enum).");
                    break;

                case "brown":
                    Console.WriteLine($"Brown has an index of: {((byte)ColorCodesEnum.Brown)} (enum).");
                    break;

                case "red":
                    Console.WriteLine($"Red has an index of: {((byte)ColorCodesEnum.Red)} (enum).");
                    break;

                case "orange":
                    Console.WriteLine($"Orange has an index of: {((byte)ColorCodesEnum.Orange)} (enum).");
                    break;

                case "yellow":
                    Console.WriteLine($"Yellow has an index of: {((byte)ColorCodesEnum.Yellow)} (enum).");
                    break;

                case "green":
                    Console.WriteLine($"Green has an index of: {((byte)ColorCodesEnum.Green)} (enum).");
                    break;

                case "blue":
                    Console.WriteLine($"Blue has an index of: {((byte)ColorCodesEnum.Blue)} (enum).");
                    break;

                case "violet":
                    Console.WriteLine($"Violet has an index of: {((byte)ColorCodesEnum.Violet)} (enum).");
                    break;

                case "grey":
                    Console.WriteLine($"Grey has an index of: {((byte)ColorCodesEnum.Grey)} (enum).");
                    break;

                case "white":
                    Console.WriteLine($"White has an index of: {((byte)ColorCodesEnum.White)} (enum).");
                    break;

                default:
                    throw new ArgumentException($"String passed in ({color}) is invalid input.\nPlease enter a valid color selection.");
            }
        }

        //Method to take input color as string and return the index associated from the ColorCodesArray
        //Method will handle case of string
        //Will throw "ArgumentExeption" in the event that the input is unsuported
        private static void GetColorIndexArray(string color)
        {
            color = color.ToLower();

            switch (color)
            {
                case "black":
                    Console.WriteLine($"Black has an index of: 0 (array).");
                    break;

                case "brown":
                    Console.WriteLine($"Brown has an index of: 1 (array).");
                    break;

                case "red":
                    Console.WriteLine($"Red has an index of: 2 (array).");
                    break;

                case "orange":
                    Console.WriteLine($"Orange has an index of: 3 (array).");
                    break;

                case "yellow":
                    Console.WriteLine($"Yellow has an index of: 4 (array).");
                    break;

                case "green":
                    Console.WriteLine($"Green has an index of: 5 (array).");
                    break;

                case "blue":
                    Console.WriteLine($"Blue has an index of: 6 (array).");
                    break;

                case "violet":
                    Console.WriteLine($"Violet has an index of: 7 (array).");
                    break;

                case "grey":
                    Console.WriteLine($"Grey has an index of: 8 (array).");
                    break;

                case "white":
                    Console.WriteLine($"White has an index of: 9 (array).");
                    break;

                default:
                    throw new ArgumentException($"String passed in ({color}) is invalid input.\nPlease enter a valid color selection.");
            }
        }
        #endregion

        static void Main(string[] args)
        {
            if(args.Length != 0)
            {
                foreach(string arg in args)
                {
                    if(Regex.IsMatch(arg, @"^[a-zA-Z]+$"))
                    {
                        try
                        {
                            GetColorIndexEnum(arg);
                            GetColorIndexArray(arg);
                        }
                        catch (ArgumentException exept)
                        {
                            Console.WriteLine(exept.Message);
                        }
                    }
                    else
                        Console.WriteLine($"Command line argument {arg} is not valid input.\nOnly alphabetical characters will be accepted. Ignoring input.");
                }

                Console.WriteLine("Would you like to keep entering colors? (y/n)");
                string cont = "";
                bool checkInput = true;
                byte timesAsked = 0;
                do
                {
                    timesAsked++;
                    cont = Console.ReadLine();
                    cont = cont.ToLower();

                    switch (cont)
                    {
                        case "y":
                            Console.WriteLine("Continuing...");
                            checkInput = false;
                            break;
                        case "n":
                            Console.WriteLine("Exiting Program...");
                            checkInput = false;
                            return;
                        default:
                            Console.WriteLine("Invalid answer");
                            if(timesAsked >= 3)
                            {
                                checkInput = false;
                            }
                            break;
                    }
                } while (checkInput);
            }

            Console.WriteLine($"Please enter a color code to check the index of.\nValid inputs are Black, Brown, Red, Orange, Yellow,\n" +
                    $"Green, Blue, Violet, Grey, White. (NOT case sensitive)\n" +
                    $"Enter 'q' to quit the program");
            string input;
            do
            {
                input = Console.ReadLine();

                if (Regex.IsMatch(input, @"^[a-zA-Z]+$"))
                {
                    if (input.ToLower() == "q")
                    {
                        Console.WriteLine("Exiting program...");
                        return;
                    }

                    try
                    {
                        GetColorIndexEnum(input);
                        GetColorIndexArray(input);
                    }
                    catch(ArgumentException exept)
                    {
                        Console.WriteLine(exept.Message);
                    }
                }
                else
                    Console.WriteLine($"Command line argument {input} is not valid input.\nOnly alphabetical characters will be accepted. Ignoring input.");
            } while (true);
        }
    }
}