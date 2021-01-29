using Libdmtx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            var domain = AppDomain.CreateDomain("MyDomain", null);

            //var fileName = "1185754.jpg";
            var fileName = "236003_2.jpg";
            //var fileName = "1223495.jpg";
            //var fileName = "wiki.png";

            var filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";

            DecodeOptions o = new DecodeOptions();
            Bitmap b = new Bitmap(filePath);
            //DmtxDecoded[] res = Dmtx.Decode(b, o);
            //for (uint i = 0; i < res.Length; i++)
            //{
            //    string str = Encoding.ASCII.GetString(res[i].Data).TrimEnd('\0');
            //    Console.WriteLine("Code " + i + ": " + str);
            //}

            new Dmtx().Decode(b, o);
            //new Dmtx().DecodeSingle(b, o, domain);
        }
    }
}
