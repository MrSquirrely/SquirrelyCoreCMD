using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SquirrelyUtilities.IO {
    public class Dir {
        public static bool IsDirectory(string value) {
            if (File.Exists(value)) {
                return false;
            } else if (Directory.Exists(value)) {
                return true;
            } else {
                return false;
            }
        }
    }
}
