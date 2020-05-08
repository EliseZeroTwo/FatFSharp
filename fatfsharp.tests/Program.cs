using System;
using System.IO;
using fatfsharp;

namespace fatfsharp.tests
{
    class Program
    {
        static void Main(string[] args)
        {
            using(FileStream fs = File.OpenRead(args[0]))
            {
                Fat32 fatfs = new Fat32(fs);
                Console.WriteLine(($"Opened volume {fatfs.hdr.VolumeName}"));
            }
        }
    }
}
