using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SquirrelyUtilities.IO {
    public static class ScanDir {

        /// <summary>
        /// Where we store all the File Info for each file
        /// </summary>
        private static List<FileInfo> fileInfos;
        /// <summary>
        /// Where we store all the Directory Info for each directory
        /// </summary>
        private static List<DirectoryInfo> directoryInfos;

        /// <summary>
        /// Gets the File Infos list
        /// </summary>
        public static List<FileInfo> GetFiles() => fileInfos;

        /// <summary>
        /// Gets the Directory Infos list
        /// </summary>
        public static List<DirectoryInfo> GetDirectories() => directoryInfos;

        /// <summary>
        /// Scans the given directory for all files and directories
        /// </summary>
        /// <param name="Directory">The directory to scan</param>
        public static void ScanDirectory(string Directory) {
            try {
                fileInfos = new List<FileInfo>();
                directoryInfos = new List<DirectoryInfo>();

                DirectoryInfo directory = new DirectoryInfo(Directory);

                foreach (FileInfo fileInfo in directory.GetFiles()) {
                    fileInfos.Add(fileInfo);
                }

                foreach (DirectoryInfo directoryInfo in directory.GetDirectories()) {
                    directoryInfos.Add(directoryInfo);
                }

            } catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

    }
}
