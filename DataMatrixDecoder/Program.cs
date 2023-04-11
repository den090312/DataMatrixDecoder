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
        static async Task Main(string[] args)
        {
            await DecodeGoodReadPicturesAsync();
            //PrintBarcodes();
            //DeleteAllBarcodes();
        }

        private static async Task DecodeGoodReadPicturesAsync()
        {
            var images = new DirectoryInfo(@"C:\Users\ASAP\Downloads\Telegram Desktop\GoodRead\GoodRead")
                .GetFiles("*.jpg");

            var tasks = new List<Task>();

            foreach (var image in images)
                tasks.Add(Task.Run(() => DecodeAndSave(image.FullName)));

            await Task.WhenAll(tasks);
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
