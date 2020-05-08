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

                Sector sector = fatfs.Sectors[0];
                byte[] outB = new byte[8];
                sector.Read(outB, 0, 0x47, 8);
                Console.WriteLine(($"Opened volume {fatfs.hdr.VolumeName} {System.Text.Encoding.ASCII.GetString(outB)}"));
            }
        }
    }
}
