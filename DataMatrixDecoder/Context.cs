using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMatrixDecoder
{
    public class Context : DbContext
    {
        public DbSet<Barcode> Barcodes { get; set; }
    }
}
