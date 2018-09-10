using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using SquirrelyUtilities.IO;
using ConsoleTables;

namespace SquirrelyCoreCMD.Class {
    public static class ListDirectory {

        private static ConsoleTable table = new ConsoleTable("Creation Time", "File Type", "File Name", " File Size");

        public static void DIR() {
            if (Reference.HasSecondIsntNull()) {
                ScanDir.ScanDirectory(Reference.command[1]);
            } else if (Reference.inDirectory) {
                ScanDir.ScanDirectory(Reference.currentDirectory);
            } else {
                ScanDir.ScanDirectory(Environment.CurrentDirectory);
            }

            Console.WriteLine();
            
            foreach (FileInfo info in ScanDir.GetFiles()) {
                table.AddRow($"{info.CreationTime}", "[FILE]", $"{info.Name}", $"{info.Length}");
            }

            foreach (DirectoryInfo info in ScanDir.GetDirectories()) {
                table.AddRow($"{info.CreationTime}", "[DIR]", $"{info.Name}", "");
            }
            table.Write();
        }

    }
}
