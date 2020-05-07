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
                Console.WriteLine(($"Volume {fatfs.hdr.VolumeName} is {fatfs.hdr.FATName}"));
                if (fatfs.hdr.Magic == Fat32.Magic)
                {
                    Console.WriteLine("Main magic is intact!");
                    if (fatfs.hdr.ExtMagic == Fat32.ExtMagic)
                        Console.WriteLine("Extended magic is intact!");
                }
                else
                {
                    Console.WriteLine($"Bad magic! Got {fatfs.hdr.ExtMagic:x}");
                }
            }
        }
    }
}
