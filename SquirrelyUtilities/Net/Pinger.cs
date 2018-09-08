using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SquirrelyUtilities.Net {
    public class Pinger {

        public static PingReply Ping(string Address) {
            Ping ping = null;
            try {
                ping = new Ping();
                PingReply reply = ping.Send(Address);
                return reply;
            } catch (Exception ex) {
                //todo add logging
                ping.Dispose();
                Console.WriteLine(ex);
                return null;
            } finally {
                if (ping != null) {
                    ping.Dispose();
                }
            }
        }
    }
}
