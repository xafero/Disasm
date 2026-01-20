using System.Data;
using Iced.Intel;
using SuperHot;

namespace Disasm.Lib
{
    internal sealed class SimpleReader : CodeReader, IByteReader
    {
        private byte[] _bytes;
        private int _index;

        public SimpleReader(byte[] bytes)
        {
            Reset(bytes);
            _bytes ??= [];
        }

        public override int ReadByte() => _index >= _bytes.Length ? -1 : _bytes[_index++];

        public byte ReadOne()
        {
            var res = ReadByte();
            if (res < 0) throw new ReadOnlyException();
            return (byte)res;
        }

        public override string ToString() => _bytes.ToHexString();

        public void Reset(byte[] bytes)
        {
            _bytes = bytes;
            _index = 0;
        }
    }
}