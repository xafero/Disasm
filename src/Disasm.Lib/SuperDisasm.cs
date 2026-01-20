using SuperHot;

namespace Disasm.Lib
{
    public sealed class SuperDisasm : IDisasm
    {
        private readonly SimpleReader _reader;
        private readonly IDecoder _decoder;

        public SuperDisasm()
        {
            _reader = new SimpleReader([]);

            const Dialect mode = Dialect.Sh3;
            var decoder = Decoders.GetDecoder(mode);
            _decoder = decoder;
        }

        public string? Decode(byte[] bytes)
        {
            _reader.Reset(bytes);
            var i = _decoder.Decode(_reader, fail: false);
            return i?.ToString();
        }
    }
}