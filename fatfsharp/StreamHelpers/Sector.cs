using System;
using System.IO;

namespace fatfsharp.StreamHelpers
{
    public class Sector : StreamHelper
    {
        new const ushort UnitSize = 512;
        
        public Sector(Stream _stream, uint LBA, long startingOffset)
        {
            stream = _stream;
            Start = startingOffset + (LBA * UnitSize);
        }

        public byte this[int i]
        {
            get
            {
                long oldPos = stream.Position;
                stream.Seek(Start + i, SeekOrigin.Begin);
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
                stream.Seek(Start + i, SeekOrigin.Begin);
                stream.WriteByte(value);
                stream.Seek(oldPos, SeekOrigin.Begin);
            }
        }
    }
}