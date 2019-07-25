using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APOApplication
{
    class RLE
    {
        public RLE() { }

        public byte[] Encode(byte[] data)
        {
            byte[] output = new byte[data.Length * 2];
            byte count = 1;
            byte current = data[0];
            int o = 0;
            for (int i = 1; i < data.Length; ++i)
            {
                if (count == 255)
                {
                    output[o] = count;
                    output[o + 1] = current;
                    count = 1;
                    o += 2;
                    current = data[i];
                }
                else if (current == data[i])
                {
                    count++;
                }
                else
                {
                    output[o] = count;
                    output[o + 1] = current;
                    count = 1;
                    o += 2;
                    current = data[i];
                }
            }
            output[o] = count;
            output[o + 1] = current;
            o += 2;
            Array.Resize(ref output, o);
            return output;
        }
    }
}
