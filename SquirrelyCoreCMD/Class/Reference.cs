using System;
using System.Collections.Generic;
using System.Text;

namespace SquirrelyCoreCMD.Class {
    internal static class Reference {

        internal static string currentDirectory = "";
        internal static bool inDirectory = false;

        internal static string commandWrote;
        internal static List<string> command = new List<string>();
        
        internal static bool HasSecondIsntNull() {
            if (command.Count > 1 && command[1] != null) {
                return true;
            } else {
                return false;
            }
        }

        internal static bool HasThirdIsntNull() {
            if (command.Count > 2 && command[2] != null) {
                return true;
            } else {
                return false;
            }
        }

        internal static bool HasFourthInstNull() {
            if (command.Count > 3 && command[3] != null) {
                return true;
            } else {
                return false;
            }
        }
    }
}
