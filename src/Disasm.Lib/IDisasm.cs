namespace Disasm.Lib
{
    public interface IDisasm
    {
        string? Decode(byte[] bytes);
    }
}