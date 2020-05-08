using System.Runtime.InteropServices;

namespace fatfsharp
{
    [Flags]
    public enum DirAttributeFlags
    {
        READ_ONLY = 0b_0000_0001,
        HIDDEN    = 0b_0000_0010,
        SYSTEM    = 0b_0000_0100,
        VOLUME_ID = 0b_0000_1000,
        DIRECTORY = 0b_0001_0000,
        ARCHIVE   = 0b_0010_0000,
        LFN       = READ_ONLY | HIDDEN | SYSTEM | VOLUME_ID
    }

    [StructLayout(LayoutKind.Sequential, Size=0x20)]
    public struct DirEntHdr
    {
        public string FileName;
        public byte Attribute;
        public byte Res;
        public byte CreationTimeTenth;
        public ushort CreationTime;
        public ushort CreationDate;
        public ushort LastAccessedDate;
        public ushort FirstClusterHigh;
        public ushort LastModificationTime;
        public ushort LastModificationDate;
        public ushort FirstClusterLow;
        public uint Size;
    }
    public class DirEnt
    {
        
    }
}