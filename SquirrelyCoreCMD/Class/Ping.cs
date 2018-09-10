using SquirrelyUtilities.Net;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;
using ConsoleTables;

namespace SquirrelyCoreCMD.Class {
    internal static class ConsolePing {

        private static int numPing;
        private static Pinger pinger;
        private static ConsoleTable table;

        internal static void Ping() {
            table = new ConsoleTable("Status", "Round Trip Time", "Address");

            if (Reference.HasSecondIsntNull()) {
                if (Reference.HasThirdIsntNull()) {
                    pinger = new Pinger(Reference.command[1].ToLower());
                    Console.WriteLine($"Pinging {Reference.command[1].ToLower()} [{pinger.GetIP()}]");
                    switch (Reference.command[2].ToLower()) {
                        case "/a":
                            if (Reference.command.Count >= 4 && Reference.command[3] != null) {
                                try {
                                    numPing = int.Parse(Reference.command[3]);
                                    StartPing();
                                } catch (Exception ex) {
                                    Console.WriteLine(ex);
                                }
                            } else {
                                StartPing();
                            }
                            break;
                        // I might add this later. It doesn't work as intended
                        //case "/i":
                        //    for (int i = 0; i < numPing; i++) {
                        //        PingReply reply = new Pinger(Reference.command[1].ToLower()).Ping();
                        //        if (reply != null) {
                        //            table.AddRow($"{reply.Status}", $"{reply.RoundtripTime}ms", $"{reply.Address}");
                        //            table.Write();
                        //        }
                        //        numPing++;
                        //    }
                        //    break;
                    }
                } else {
                    numPing = 4;
                    StartPing();
                }
            }
        }

        private static void StartPing() {
            for (int i = 0; i < numPing; i++) {
                PingReply reply = new Pinger(Reference.command[1].ToLower()).Ping();
                if (reply != null) {
                    table.AddRow($"{reply.Status}", $"{reply.RoundtripTime}ms", $"{reply.Address}");
                }
            }
            table.Write();
        }
    }
}
