using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Convert_tool
{
    class Program
    {
        public static string BinaryStringToHexString(string binary)
        {
            StringBuilder result = new StringBuilder(binary.Length / 8 + 1);

            // TODO: check all 1's or 0's... Will throw otherwise

            int mod4Len = binary.Length % 8;
            if (mod4Len != 0)
            {
                // pad to length multiple of 8
                binary = binary.PadLeft(((binary.Length / 8) + 1) * 8, '0');
            }

            for (int i = 0; i < binary.Length; i += 8)
            {
                string eightBits = binary.Substring(i, 8);
                result.AppendFormat("{0:X2}", Convert.ToByte(eightBits, 2));
            }

            return result.ToString();
        }

        public static string HexStringToBinaryString(string hex)
        {
            return String.Join(String.Empty, hex.Select(
                    c => Convert.ToString(Convert.ToInt32(c.ToString(), 16), 2).PadLeft(4, '0')
                  )
                );
        }

        static void Main(string[] args)
        {
            Console.Write("input (binary) : ");
            string binary = Console.ReadLine();
            Console.WriteLine("output (hex) : " + BinaryStringToHexString(binary));
            Console.WriteLine();
            Console.Write("input (hex) : ");
            string hex = Console.ReadLine();
            Console.WriteLine("output (binary) : " + HexStringToBinaryString(hex));
        }
    }
}
