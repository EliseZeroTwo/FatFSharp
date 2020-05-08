using System;
using System.Runtime.InteropServices;

namespace fatfsharp
{
    [Flags]
    public enum VolumeIDFlags
    {
        ActiveFATCopy = 0b_0001_1111,
        FATMirroring  = 0b_1000_0000,
    }

    [StructLayout(LayoutKind.Sequential, Pack=1, CharSet=CharSet.Ansi, Size=VolumeID.HdrSize)]
    public struct VolumeIDHdr
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=3)]
        public byte[] JMPIns;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
        public string OEM;
        public ushort BytesPerSector;
        public byte SectorsPerCluster;
        public ushort ReservedSectors;
        public byte FATCount;
        public ushort MaxRootDirEntries; // 0 in fat32
        public ushort SmallSectorCount; // For partitions under 32MB, 0 in fat32
        public byte MediaDescriptor;
        public ushort SectorsPerFATOld;
        public ushort SectorsPerTrack;
        public ushort HeadCount;
        public uint HiddenSectorCount;
        public uint SectorCount;
        public uint SectorsPerFAT;
        public ushort Flags;
        public ushort Version;
        public uint RootDirCluster;
        public ushort SectorNumFSInfoSector;
        public ushort BackupBootSector;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=12)]
        public byte[] Res;
        public byte LogicalDriveNumber;
        public byte Res2;
        public byte ExtMagic; //0x29
        public uint PartitionSerialNumber;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=11)]
        public string VolumeName;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst=8)]
        public string FATName;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst=420)]
        public byte[] ExecutableCode;
        public ushort Magic;
    }
    
    public static class VolumeID
    {
        public const ushort HdrSize = 0x200;
        public static T RawDataToObject<T>(byte[] rawData) where T : struct
        {
            var pinnedRawData = GCHandle.Alloc(rawData,
                                            GCHandleType.Pinned);
            try
            {
                // Get the address of the data array
                var pinnedRawDataPtr = pinnedRawData.AddrOfPinnedObject();

                // overlay the data type on top of the raw data
                return (T) Marshal.PtrToStructure(pinnedRawDataPtr, typeof(T));
            }
            finally
            {
                // must explicitly release
                pinnedRawData.Free();
            }
        }  
    }
}