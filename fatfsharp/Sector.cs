using System;
using System.IO;

namespace fatfsharp
{
    public class Sector
    {
        public const ushort size = 512;
        
        private Stream stream;
        long start;
        public Sector(Stream _stream, uint LBA, long startingOffset)
        {
            stream = _stream;
            start = startingOffset * 512;
        }

        public byte this[int i]
        {
            get
            {
                long oldPos = stream.Position;
                stream.Seek(start + i, SeekOrigin.Begin);
                int resInt = stream.ReadByte();
                byte res;

                if (resInt != -1)
                    res = (byte)resInt;
                else
                    throw new IndexOutOfRangeException();

                stream.Seek(oldPos, SeekOrigin.Begin);
                return res;
            }
            set
            {
                long oldPos = stream.Position;
                stream.Seek(start + i, SeekOrigin.Begin);
                stream.WriteByte(value);
                stream.Seek(oldPos, SeekOrigin.Begin);
            }
        }

        public int Read(byte[] outputArray, int arrayOffset, int readOffset, int length)
        {
            long oldPos = stream.Position;
            stream.Seek(start + readOffset, SeekOrigin.Begin);
            int res = stream.Read(outputArray, arrayOffset, length);
            stream.Seek(oldPos, SeekOrigin.Begin);
            return res;
        }
        public void Write(byte[] inputArray, int arrayOffset, int writeOffset, int length)
        {
            long oldPos = stream.Position;
            stream.Seek(start + writeOffset, SeekOrigin.Begin);
            stream.Write(inputArray, arrayOffset, length);
            stream.Seek(oldPos, SeekOrigin.Begin);
        }
    }
}