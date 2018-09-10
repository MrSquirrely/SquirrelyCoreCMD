using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using SquirrelyUtilities.IO;
using SquirrelyUtilities.Net;
using SquirrelyCoreCMD.Class;

namespace SquirrelyCoreCMD {
    class Program {

        private static void Main(string[] args) {
            Console.WriteLine("Squirrely Core CMD (C) 2018 MrSquirrely.net");
            for (; true;) {
            START:
                Console.WriteLine();
                if (!Reference.inDirectory) {
                    Console.Write(">>");
                } else {
                    Console.Write($"{Reference.currentDirectory} >>");
                }

                Reference.commandWrote = Console.ReadLine();
                Reference.command.Clear();
                foreach (string word in Reference.commandWrote.Split(new char[] { ' ' })) {
                    Reference.command.Add(word);
                }

                switch (Reference.command[0].ToLower()) {
                    case "ping":
                        ConsolePing.Ping();
                        break;
                    case "cd":
                        ChangeDirectory.CD();
                        break;
                    case "dir":
                        ListDirectory.DIR();
                        break;
                    case "color":
                        Color.ChangeColor();
                        break;
                    case "date":
                        Console.WriteLine(DateTime.Now);
                        break;
                    case "echo":
                        string echo = "";
                        for (int i = 1; i < Reference.command.Count; i++) {
                            echo = $"{echo}{Reference.command[i]} ";
                        }
                        Console.WriteLine(echo);
                        break;
                    case "cls":
                    case "clear":
                        Console.Clear();
                        break;
                    case "?":
                    case "help":
                        Help.ShowHelp();
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
    }
}
