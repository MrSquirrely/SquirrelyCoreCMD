using System;
using System.Collections.Generic;
using System.Text;

namespace SquirrelyCoreCMD.Class {
    public static class Color {

        public static void ChangeColor() {

            if (Reference.HasSecondIsntNull()) {

                switch (Reference.command[1].ToLower()) {
                    case "black":
                        ChangeConsoleColor(ConsoleColor.Black);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "blue":
                        ChangeConsoleColor(ConsoleColor.Blue);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "cyan":
                        ChangeConsoleColor(ConsoleColor.Cyan);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "darkblue":
                        ChangeConsoleColor(ConsoleColor.DarkBlue);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "darkcyan":
                        ChangeConsoleColor(ConsoleColor.DarkCyan);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "darkgray":
                        ChangeConsoleColor(ConsoleColor.DarkGray);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "darkgreen":
                        ChangeConsoleColor(ConsoleColor.DarkGreen);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "darkmagenta":
                        ChangeConsoleColor(ConsoleColor.DarkMagenta);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "darkred":
                        ChangeConsoleColor(ConsoleColor.DarkRed);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "darkyellow":
                        ChangeConsoleColor(ConsoleColor.DarkYellow);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "gray":
                        ChangeConsoleColor(ConsoleColor.Gray);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "green":
                        ChangeConsoleColor(ConsoleColor.Green);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "magenta":
                        ChangeConsoleColor(ConsoleColor.Magenta);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "red":
                        ChangeConsoleColor(ConsoleColor.Red);
                        ChangeTextColor(ConsoleColor.White);
                        break;
                    case "white":
                        ChangeConsoleColor(ConsoleColor.White);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "yellow":
                        ChangeConsoleColor(ConsoleColor.Yellow);
                        ChangeTextColor(ConsoleColor.Black);
                        break;
                    case "reset":
                        Console.ResetColor();
                        break;
                    default:
                        break;
                }

                if (Reference.HasThirdIsntNull()) {
                    switch (Reference.command[2].ToLower()) {
                        case "black":
                            ChangeTextColor(ConsoleColor.Black);
                            break;
                        case "blue":
                            ChangeTextColor(ConsoleColor.Blue);
                            break;
                        case "cyan":
                            ChangeTextColor(ConsoleColor.Cyan);
                            break;
                        case "darkblue":
                            ChangeTextColor(ConsoleColor.DarkBlue);
                            break;
                        case "darkcyan":
                            ChangeTextColor(ConsoleColor.DarkCyan);
                            break;
                        case "darkgray":
                            ChangeTextColor(ConsoleColor.DarkGray);
                            break;
                        case "darkgreen":
                            ChangeTextColor(ConsoleColor.DarkGreen);
                            break;
                        case "darkmagenta":
                            ChangeTextColor(ConsoleColor.DarkMagenta);
                            break;
                        case "darkred":
                            ChangeTextColor(ConsoleColor.DarkRed);
                            break;
                        case "darkyellow":
                            ChangeTextColor(ConsoleColor.DarkYellow);
                            break;
                        case "gray":
                            ChangeTextColor(ConsoleColor.Gray);
                            break;
                        case "green":
                            ChangeTextColor(ConsoleColor.Green);
                            break;
                        case "magenta":
                            ChangeTextColor(ConsoleColor.Magenta);
                            break;
                        case "red":
                            ChangeTextColor(ConsoleColor.Red);
                            break;
                        case "white":
                            ChangeTextColor(ConsoleColor.White);
                            break;
                        case "yellow":
                            ChangeTextColor(ConsoleColor.Yellow);
                            break;
                        default:
                            break;
                    }
                }
                Console.Clear();
            }
        }

        private static void ChangeConsoleColor(ConsoleColor color) => Console.BackgroundColor = color;
        private static void ChangeTextColor(ConsoleColor color) => Console.ForegroundColor = color;

    }
}
