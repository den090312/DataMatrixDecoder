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
            //var fileName = "1185754.jpg";
            var fileName = "236003_2.jpg";
            //var fileName = "1223495.jpg";
            //var fileName = "wiki.png";

            var filePath = $@"{AppDomain.CurrentDomain.BaseDirectory}{fileName}";

            var options = new DecodeOptions();
            var bitmap = new Bitmap(filePath);

            //new Dmtx().DecodeSingle(
            //    bitmap, 
            //    options, 
            //    new Barcode { date = DateTime.Now, filename = filePath }, 
            //    AppDomain.CreateDomain("MyDomain", null));

            //_ = Task.Factory.StartNew(() =>
            //{
            //    new Dmtx().Decode(
            //        bitmap,
            //        new Barcode { date = DateTime.Now, filename = filePath },
            //        options);
            //});

            new Dmtx().Decode(
                bitmap,
                new Barcode { date = DateTime.Now, filename = filePath },
                options);

            PrintBarcodes();
            //DeleteAllBarcodes();
        }

        public static void PrintBarcodes()
        {
            using (var context = new Context())
            {
                foreach (var barcode in context.Barcodes)
                {
                    Console.WriteLine("---------------------");
                    Console.WriteLine($@"- {barcode.date}");
                    Console.WriteLine($@"- {barcode.filename}");
                    Console.WriteLine($@"- {barcode.value}");
                    Console.WriteLine("---------------------");
                }
            }
        }

        public static void DeleteAllBarcodes()
        {
            using (var context = new Context())
            {
                context.Database.ExecuteSqlCommand("DELETE FROM Barcodes");
                context.SaveChanges();
            }
        }
    }
}
