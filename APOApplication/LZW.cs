using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    public class LZWEncoder
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        ANSI table = null;

        int codeLen = 8;
        public LZWEncoder()
        {
            table = new ANSI();
            dict = table.Table;
        }

        public string EncodeToCodes(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;

                while (dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                    i++;
                }

                if (dict.ContainsKey(w) == false)
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(dict[matchKey] + ", ");

                    dict.Add(w, dict.Count);
                    i--;
                }
                else
                {
                    sb.Append(dict[w] + ", ");
                }
            }

            return sb.ToString();
        }

        public string Encode(string input)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            while (i < input.Length)
            {
                w = input[i].ToString();

                i++;

                while (dict.ContainsKey(w) && i < input.Length)
                {
                    w += input[i];
                    i++;
                }

                if (dict.ContainsKey(w) == false)
                {
                    string matchKey = w.Substring(0, w.Length - 1);
                    sb.Append(Convert.ToString(dict[matchKey], 2).FillWithZero(codeLen));

                    if (Convert.ToString(dict.Count, 2).Length > codeLen)
                        codeLen++;

                    dict.Add(w, dict.Count);
                    i--;
                }
                else
                {
                    sb.Append(Convert.ToString(dict[w], 2).FillWithZero(codeLen));

                    if (Convert.ToString(dict.Count, 2).Length > codeLen)
                        codeLen++;

                }
            }

            return sb.ToString();
        }

        public byte[] EncodeToByteList(string input)
        {
            string encodedInput = Encode(input);
            return encodedInput.ToByteArray();
        }

    }

    public class LZWDecoder
    {
        public Dictionary<string, int> dict = new Dictionary<string, int>();
        int codeLen = 8;
        ANSI table;
        public LZWDecoder()
        {
            table = new ANSI();
            dict = table.Table;
        }

        public string DecodeFromCodes(byte[] bytes)
        {
            string output = bytes.GetBinaryString();

            return Decode(output);
        }

        public string Decode(string output)
        {
            StringBuilder sb = new StringBuilder();

            int i = 0;
            string w = "";
            int prevValue = -1;

            while (i < output.Length)
            {
                if (i + codeLen + 8 <= output.Length)
                {
                    w = output.Substring(i, codeLen);
                }
                else if (i + codeLen <= output.Length)
                {
                    int encodedLen = i + codeLen;
                    int trimBitsLen = output.Length - encodedLen;

                    w = output.Substring(i, codeLen - (8 - trimBitsLen)) + output.Substring(output.Length - (8 - trimBitsLen), (8 - trimBitsLen));
                }
                else
                {
                    break;
                }

                i += codeLen;

                int value = Convert.ToInt32(w, 2);

                string key = dict.FindKey(value);
                string prevKey = dict.FindKey(prevValue);

                if (prevKey == null)
                {
                    prevKey = "";
                }

                if (key == null)
                {
                    //handles the situation cScSc
                    key = prevKey;

                    sb.Append(prevKey + key.Substring(0, 1));
                }
                else
                {
                    sb.Append(key);
                }

                string finalKey = prevKey + key.Substring(0, 1);

                if (dict.ContainsKey(finalKey) == false)
                {
                    dict[finalKey] = dict.Count;
                }

                if (Convert.ToString(dict.Count, 2).Length > codeLen)
                    codeLen++;

                prevValue = value;
            }

            return sb.ToString();
        }

    }

    public class ANSI
    {
        Dictionary<string, int> table = new Dictionary<string, int>();
        public Dictionary<string, int> Table
        {
            get
            {
                return table;
            }
        }

        public ANSI()
        {
            for (int i = 0; i < 256; i++)
            {
                table.Add(System.Text.Encoding.Default.GetString(new byte[1] { Convert.ToByte(i) }), i);
            }
        }

        public void WriteLine()
        {
            table.WriteLine();
        }

        public void WriteToFile()
        {
            File.WriteAllText("ANSI.txt", table.ToStringLines(), Encoding.Default);
        }
    }

    class BitReader : IDisposable
    {
        BufferedStream s = null;
        MemoryStream ms = null;

        bool disposed = false;
        byte? b = null;
        int pos = 0;

        public BitOrder bitOrder = BitOrder.LeftToRight;
        public bool EndOfStream;

        public BitReader(BufferedStream _s)
        {
            s = _s;
        }

        public BitReader(byte[] bytes)
        {
            MemoryStream ms = new MemoryStream(bytes);
            ms.Position = 0;

            s = new BufferedStream(ms);
        }


        public bool? ReadBit()
        {
            bool? result = null;

            try
            {
                if (b == null || (pos % 8 == 0))
                {
                    int i = s.ReadByte();

                    if (i == -1)
                    {
                        throw new EndOfStreamException();
                    }
                    else
                    {
                        b = Convert.ToByte(i);
                    }

                    pos = 0;
                }

                if (bitOrder == BitOrder.LeftToRight)
                {
                    result = Convert.ToBoolean(b & (1 << (7 - pos)));
                }
                else if (bitOrder == BitOrder.RightToLeft)
                {
                    result = Convert.ToBoolean((b >> pos) % 2);
                }

                pos++;

                return result;
            }
            catch (EndOfStreamException)
            {
                EndOfStream = true;

                return null;
            }
        }

        public bool?[] ReadBits(int n)
        {
            bool?[] bits = new bool?[n];

            for (int i = 0; i < n; i++)
            {
                bool? bit = ReadBit();
                bits[i] = bit;
            }

            return bits;
        }

        public bool[] ReadAll()
        {
            List<bool> bits = new List<bool>();
            bool? bit = null;
            while ((bit = ReadBit()) != null)
            {
                bits.Add(bit.Value);
            }

            return bits.ToArray();
        }

        public long Position
        {
            get
            {
                return ((s.Position - 1) * 8) + (pos - 1);
            }
        }

        public long Length
        {
            get
            {
                return s.Length * 8;
            }
        }


        #region IDisposable Members

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose managed resources
                if (disposing)
                {
                    if (this.s != null)
                    {
                        s.Close();
                    }

                    if (this.ms != null)
                    {
                        ms.Close();
                    }
                }

                // Dispose unmanaged resources
                disposed = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);

            GC.SuppressFinalize(this);
        }

        #endregion

        public enum BitOrder
        {
            LeftToRight = 0,
            RightToLeft = 1
        }
    }

    public static class ExtensionMethods
    {
        public static void ForEach<T>(this IEnumerable<T> sequance, Action<T> action)
        {
            foreach (T item in sequance)
            {
                action(item);
            }
        }

        public static void WriteLine<T>(this IEnumerable<T> sequence)
        {
            foreach (T item in sequence)
            {
                Console.WriteLine(item);
            }
        }

        public static void WriteLine<K, V>(this Dictionary<K, V> dict)
        {
            foreach (var pair in dict)
            {
                Console.WriteLine("Key: " + pair.Key + ", Value: " + pair.Value);
            }
        }

        public static string ToStringLines<K, V>(this Dictionary<K, V> dict)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var pair in dict)
            {
                sb.Append(("Key: " + pair.Key + ", Value: " + pair.Value));
                sb.AppendLine();
            }

            return sb.ToString();
        }


        public static string FillWithZero(this string value, int len)
        {
            while (value.Length < len)
            {
                value = "0" + value;
            }

            return value;
        }

        public static byte[] ToByteArray(this string value)
        {
            List<byte> l = new List<byte>();

            int i = 0;
            for (i = 0; i < value.Length; i += 8)
            {
                string bs = "";
                if (i + 8 <= value.Length)
                {
                    bs = value.Substring(i, 8);
                }
                else
                {
                    bs = value.Substring(i, value.Length - i);
                }

                byte b = Convert.ToByte(bs, 2);

                l.Add(b);
            }

            return l.ToArray();
        }

        public static string GetBinaryString(this byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();

            using (BitReader br = new BitReader(bytes))
            {
                bool[] bb = br.ReadAll();
                for (int i = 0; i < bb.Length; i++)
                {
                    bool b = bb[i];
                    sb.Append(Convert.ToInt32(b).ToString());
                }
            }

            return sb.ToString();
        }

        public static string FindKey(this IDictionary<string, int> lookup, int value)
        {
            foreach (var pair in lookup)
            {
                if (pair.Value == value)
                {
                    return pair.Key;
                }
            }

            return null;
        }

    }
}
