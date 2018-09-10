using SquirrelyUtilities.Net;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SquirrelyCoreCMD.Class {
    internal static class ConsolePing {

        private static int numPing;
        private static Pinger pinger;

        internal static void Ping() {
            if (Reference.HasSecondIsntNull()) {
                if (Reference.HasThirdIsntNull()) {
                    numPing = 4;
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
                        case "/i":
                            for (int i = 0; i < numPing; i++) {
                                PingReply reply = pinger.Ping();
                                if (reply != null) {
                                    Console.WriteLine($"{reply.Status}  {reply.RoundtripTime}ms");
                                }
                                numPing++;
                            }
                            break;
                    }
                } else {
                    numPing = 4;
                    pinger = new Pinger(Reference.command[1].ToLower());

                    StartPing();
                }
            }
        }

        private static void StartPing() {
            for (int i = 0; i < numPing; i++) {
                PingReply reply = pinger.Ping();
                if (reply != null) {
                    Console.WriteLine($"{reply.Status}  {reply.RoundtripTime}ms");
                }
                
            }
        }
    }
}
