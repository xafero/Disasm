namespace Disasm.Web.Models
{
    internal static class State
    {
        public static int Arch { get; set; } = 1;

        public static int Bit { get; set; } = 1;

        public static int Order { get; set; } = 1;

        public static string Base { get; set; } = "0x0";

        public static int Style { get; set; } = 1;
    }
}