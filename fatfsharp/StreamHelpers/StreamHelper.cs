using System.IO;

namespace fatfsharp.StreamHelpers
{
    public class StreamHelper
    {
        protected ushort UnitSize;
        protected Stream stream;
        protected long Start;
        public virtual int Read(byte[] outputArray, int arrayOffset, int readOffset, int length)
        {
            long oldPos = stream.Position;
            stream.Seek(Start + readOffset, SeekOrigin.Begin);
            int res = stream.Read(outputArray, arrayOffset, length);
            stream.Seek(oldPos, SeekOrigin.Begin);
            return res;
        }
        public virtual void Write(byte[] inputArray, int arrayOffset, int writeOffset, int length)
        {
            long oldPos = stream.Position;
            stream.Seek(Start + writeOffset, SeekOrigin.Begin);
            stream.Write(inputArray, arrayOffset, length);
            stream.Seek(oldPos, SeekOrigin.Begin);
        }
    }
}