using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;

namespace fatfsharp
{
    public class Fat32
    {
        public readonly Stream Stream;
        public VolumeIDHdr hdr;
        public const ushort Magic = 0xAA55; // Offset: 0x1FE
        public const ushort ExtMagic = 0x29;
        public const ushort BytesPerSector = 512; // Offset: 0x0B
        public const byte FATCount = 2; // Offset: 0x10 

        public Sectors Sectors;

        public Fat32(Stream _stream)
        {
            Stream = _stream;
            
            byte[] hdrByteArr = new byte[Marshal.SizeOf(typeof(VolumeIDHdr))];
            Stream.Read(hdrByteArr, 0, Marshal.SizeOf(typeof(VolumeIDHdr)));
            
            hdr = VolumeID.RawDataToObject<VolumeIDHdr>(hdrByteArr);
            
            if (hdr.Magic != Fat32.Magic)
                throw new ApplicationException($"Fat32 Magic {hdr.Magic:x} is invalid");
            
            if (hdr.ExtMagic != Fat32.ExtMagic)
                throw new ApplicationException($"Fat32 Extended Magic {hdr.ExtMagic:x} is invalid");

            Sectors = new Sectors(this);
        }

    }
}