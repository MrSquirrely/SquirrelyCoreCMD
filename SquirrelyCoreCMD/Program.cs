using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using SquirrelyUtilities.IO;
using SquirrelyUtilities.Net;

namespace SquirrelyCoreCMD {
    class Program {

        private static string currentDirectory = "";
        private static bool inDirectory = false;

        private static string commandWrote;
        private static List<string> command = new List<string>();

        private static void Main(string[] args) {
            Console.WriteLine("Squirrely Core CMD (C) 2018 MrSquirrely.net");
            for (; true;) {
            START:
                Console.WriteLine();
                if (!inDirectory) {
                    Console.Write(">>");
                } else {
                    Console.Write($"{currentDirectory} >>");
                }

                commandWrote = Console.ReadLine();
                command.Clear();
                foreach (string word in commandWrote.Split(new char[] { ' ' })) {
                    command.Add(word);
                }

                switch (command[0].ToLower()) {
                    case "ping":
                        if (HasSecondIsntNull()) {
                            if (command.Count > 2) {
                                int numTimes = int.Parse(command[2]);
                                for (int i = 0; i < numTimes; i++) {
                                    PingReply reply = Pinger.Ping(command[1]);

                                    if (reply != null) {
                                        Console.WriteLine($"{reply.Status} {reply.RoundtripTime} {reply.Address}");
                                    }
                                }
                            } else {
                                for (int i = 0; i < 4; i++) {
                                    PingReply reply = Pinger.Ping(command[1]);

                                    if (reply != null) {
                                        Console.WriteLine($"{reply.Status} {reply.RoundtripTime} {reply.Address}");
                                    }
                                }
                            }

                        }
                        break;
                    case "cd":
                        if (HasSecondIsntNull()) {
                            if (command[1].ToLower() == ".." && inDirectory) {
                                if (Directory.GetParent(currentDirectory) != null) {
                                    currentDirectory = $"{Directory.GetParent(currentDirectory)}";
                                }
                            } else if (Dir.IsDirectory(command[1]) != false && command[1].ToLower() != "..") {
                                inDirectory = true;
                                currentDirectory = command[1];
                            } else {
                                Console.WriteLine("That Directory doesn't exist or you are not in a directory if used '..'");
                            }
                        }
                        break;
                    case "dir":
                        if (HasSecondIsntNull()) {
                            ScanDir.ScanDirectory(command[1]);
                        } else if (inDirectory) {
                            ScanDir.ScanDirectory(currentDirectory);
                        } else {
                            ScanDir.ScanDirectory(Directory.GetCurrentDirectory());
                        }

                        Console.WriteLine();

                        foreach (FileInfo info in ScanDir.GetFiles()) {
                            Console.WriteLine($" {info.Name} :: {info.Length}");
                        }

                        foreach (DirectoryInfo info in ScanDir.GetDirectories()) {
                            Console.WriteLine($" {info.Name}\\");
                        }
                        break;
                    case "color":
                        if (HasSecondIsntNull()) {
                            switch (command[1].ToLower()) {
                                case "blue":
                                    Console.BackgroundColor = ConsoleColor.Blue;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    break;
                                case "cyan":
                                    Console.BackgroundColor = ConsoleColor.Cyan;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    break;
                                case "black":
                                    Console.BackgroundColor = ConsoleColor.Black;
                                    Console.ForegroundColor = ConsoleColor.White;
                                    Console.Clear();
                                    break;
                                case "reset":
                                    Console.ResetColor();
                                    Console.Clear();
                                    break;
                            }
                        }
                        break;
                    case "date":
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "echo":
                        string echo = "";
                        for (int i = 1; i < command.Count; i++) {
                            echo = $"{echo}{command[i]} ";
                        }
                        Console.WriteLine(echo);
                        break;
                    case "cls":
                    case "clear":
                        Console.Clear();
                        break;
                    case "?":
                    case "help":
                        if (HasSecondIsntNull()) {
                            switch (command[1].ToLower()) {
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
                            Console.WriteLine("\n HELP    :: Shows all the possible commands"
                                             + "\n PING    :: Pings a host to see if it is reachable"
                                             + "\n CLS     :: Clears the screen"
                                             + "\n EXIT    :: Closes SquirrelyCMD"
                                             + "\n CD      :: Changes directory"
                                             + "\n DIR     :: List all files and folders in current directory"
                                             + "\n COLOR   :: Changes color of console"
                                             + "\n DATE    :: Shows current date"
                                             + "\n ECHO    :: Echos an inputed string");
                        }

                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Unknow command, Type in '?' in to see a list of possible commands");
                        break;
                }

                goto START;
            }
        }

        private static bool HasSecondIsntNull() {
            if (command.Count > 1 && command[1] != null) {
                return true;
            } else {
                return false;
            }
        }
    }
}
