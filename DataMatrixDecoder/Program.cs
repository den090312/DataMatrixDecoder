using Libdmtx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixDecoder
{
    class Program
    {
        static void Main(string[] args)
        {
            DecodeGoodReadPictures();
            //PrintBarcodes();
            //DeleteAllBarcodes();
        }

        private static void DecodeGoodReadPictures()
        {
            var images = new DirectoryInfo(@"C:\Users\ASAP\Downloads\Telegram Desktop\GoodRead\GoodRead")
                .GetFiles("*.jpg");

            foreach (var image in images)
                new Task(() => DecodeAndSave(image.FullName)).RunSynchronously();
        }

        private static void DecodeAndSave(string filePath)
        {
            using (var context = new Context())
            {
                new Dmtx().DecodeAndSave(
                    new Bitmap(filePath),
                    new Barcode { date = DateTime.Now, filename = filePath },
                    new DecodeOptions(),
                    context);
            }
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
