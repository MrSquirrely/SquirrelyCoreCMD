using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SquirrelyUtilities.IO;

namespace SquirrelyCoreCMD.Class {
    public static class ChangeDirectory {

        public static void CD() {
            if (Reference.HasSecondIsntNull()) {
                if (Reference.command[1].ToLower() == ".." && Reference.inDirectory) {
                    if (Directory.GetParent(Reference.currentDirectory) != null) {
                        Reference.currentDirectory = $"{Directory.GetParent(Reference.currentDirectory)}";
                    }
                }else if (Dir.IsDirectory(Reference.command[1]) != false && Reference.command[1] != "..") {
                    Reference.inDirectory = true;
                    Reference.currentDirectory = Reference.command[1];
                } else {
                    Console.WriteLine("That directory doesn't exist or you are not in a directory if used '..' ");
                }
            }
        }
    }
}
