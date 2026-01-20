using Iced.Intel;

namespace Disasm.Lib
{
    public sealed class IntelDisasm : IDisasm
    {
        private readonly SimpleReader _reader;
        private readonly Decoder _decoder;

        public IntelDisasm()
        {
            _reader = new SimpleReader([]);

            const DecoderOptions o = DecoderOptions.NoInvalidCheck | DecoderOptions.OldFpu;
            const int bitness = 16;
            const ulong ip = 0;
            var decoder = Decoder.Create(bitness, _reader, ip, o);
            _decoder = decoder;
        }

        public string? Decode(byte[] bytes)
        {
            _reader.Reset(bytes);
            var r = _decoder.Decode();
            Instruction? i = r.IsInvalid ? null : r;
            return i?.ToString();
        }
    }
}