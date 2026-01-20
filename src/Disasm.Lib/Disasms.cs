using System;
using System.Collections.Generic;
using System.Data;

namespace Disasm.Lib
{
    public static class Disasms
    {
        private static readonly Lazy<IntelDisasm> Intel = new();
        private static readonly Lazy<SuperDisasm> Super = new();

        private const char Nl = '\n';

        public static string ToText(this List<string> res) => string.Join(Nl, res);

        public static List<string> Parse(string txt, DisasmKind kind)
        {
            var obj = GetDisasm(kind);
            var lines = txt.Split(Nl);
            var res = new List<string>();
            foreach (var line in lines)
            {
                var tmp = line.Replace(" ", "").Trim();
                try
                {
                    var one = obj.Decode(Convert.FromHexString(tmp));
                    res.Add(one ?? string.Empty);
                }
                catch (ReadOnlyException)
                {
                    res.Add(string.Empty);
                }
                catch (Exception e)
                {
                    res.Add(e.Message);
                }
            }
            return res;
        }

        private static IDisasm GetDisasm(DisasmKind kind)
        {
            IDisasm obj = kind switch
            {
                DisasmKind.x86 => Intel.Value,
                DisasmKind.sh3 => Super.Value,
                _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
            };
            return obj;
        }
    }
}