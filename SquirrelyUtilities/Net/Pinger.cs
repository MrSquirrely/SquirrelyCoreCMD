using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace SquirrelyUtilities.Net {
    public class Pinger {
        private string address;
        private Ping ping = null;
        private PingReply pingReply;

        public Pinger(string Address) {
            address = Address;
            ping = new Ping();
            pingReply = ping.Send(Address);
        }

        public PingReply Ping() {
            try {
                PingReply reply = ping.Send(address);
                return reply;
            } catch (Exception ex) {
                //todo add logging
                DisposePing();
                Console.WriteLine();
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                return null;
            } finally {
                if (ping != null) {
                    DisposePing();
                }
            }
        }

        public string GetIP() => pingReply.Address.ToString();
        public void DisposePing() => ping.Dispose();

    }
}
