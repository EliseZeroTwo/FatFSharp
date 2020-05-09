using System.IO;

namespace fatfsharp.StreamHelpers
{
    public class Cluster : StreamHelper
    {
        public Cluster(Stream _stream, uint ClusterNumber, long startingOffset, ushort ClusterSize)
        {
            stream = _stream;
            UnitSize = ClusterSize;
            Start = startingOffset + (ClusterNumber * ClusterSize);
        }
    }
}