using System.Collections.Generic;
using System.IO;

namespace fatfsharp
{
    public class Fat32
    {
        public const ushort Magic = 0xAA55; // Offset: 0x1FE
        public const ushort BytesPerSector = 512; // Offset: 0x0B
        public const byte FATCount = 2; // Offset: 0x10  
        private byte _sectorsPerCluster; // Offset: 0x0D

        public byte SectorsPerCluster
        {
            get
            {
                return _sectorsPerCluster;
            }
            set
            {
                const List<byte> validInputs = {1, 2, 4, 8, 16, 32, 64, 128};
                if (validInputs.Contains(value))
                    _sectorsPerCluster = value;
                else
                    throw new System.ArgumentException($"SectorsPerCluster must be either 1, 2, 4, 8, 16, 32, 64, or 128");
            }
        }

        public ushort ReservedSectorCount; // Offset: 0x0E
        public uint SectorsPerFat; // Offset: 0x24
        public uint RootDirFirstCluster; // Offset: 0x2c

    }
}