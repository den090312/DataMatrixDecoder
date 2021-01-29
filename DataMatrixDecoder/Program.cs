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
            var fileName = "1185754.jpg";
            //var fileName = "1201614.jpg";
            //var fileName = "wiki.png";

            var filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";

            var options = new DecodeOptions();
            var bitmap = new Bitmap(filePath);
            var domain = AppDomain.CreateDomain("MyDomain", null);

            new Dmtx().DenisDecode(bitmap, options, domain);
        }
    }
}
