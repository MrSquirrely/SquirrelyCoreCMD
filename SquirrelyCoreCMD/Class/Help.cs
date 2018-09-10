using System;
using System.Collections.Generic;
using System.Text;

namespace SquirrelyCoreCMD.Class {
    public static class Help {
        public static void ShowHelp() {
            if (Reference.HasSecondIsntNull()) {
                switch (Reference.command[1].ToLower()) {
                    case "cd":
                        Console.WriteLine("Changes the current directory to choosen directory");
                        Console.WriteLine("More options comming soon");
                        break;
                    case "dir":
                        Console.WriteLine("List all files and directories in the current directory");
                        Console.WriteLine("More options comming soon");
                        break;
                    case "color":
                        Console.WriteLine("Changes the color of the console");
                        Console.WriteLine("     Possible colors:    BLACK");
                        Console.WriteLine("                         BLUE");
                        Console.WriteLine("                         CYAN");
                        Console.WriteLine();
                        Console.WriteLine("More colors coming");
                        break;
                    case "date":
                        Console.WriteLine("Shows the current date and time");
                        Console.WriteLine("More options comming soon");
                        break;
                    case "echo":
                        Console.WriteLine("Echos a given word or words");
                        break;
                    case "help":
                    case "?":
                        Console.WriteLine("Shows a list of all possible commands");
                        break;
                    case "ping":
                        Console.WriteLine("Pings a host to see if it is reachable");
                        Console.WriteLine("More options comming soon");
                        break;
                    case "cls":
                    case "clear":
                        Console.WriteLine("Clears the console");
                        break;
                    case "exit":
                        Console.WriteLine("Exits the console");
                        break;
                }
            } else {
                Console.WriteLine("Add command to end to find more info on the command (Ex. help ping)");
                Console.WriteLine("Possible Commands");
                Console.WriteLine( "\n HELP    :: Shows all the possible commands"
                                 + "\n PING    :: Pings a host to see if it is reachable"
                                 + "\n CLS     :: Clears the screen"
                                 + "\n EXIT    :: Closes SquirrelyCMD"
                                 + "\n CD      :: Changes directory"
                                 + "\n DIR     :: List all files and folders in current directory"
                                 + "\n COLOR   :: Changes color of console"
                                 + "\n DATE    :: Shows current date"
                                 + "\n ECHO    :: Echos an inputed string");
            }
        }
    }
}
