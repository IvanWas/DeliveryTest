
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryTest
{
    class DBContext
    {
        private static MusicalInstrumentShopEntities1 _context;
        public static MusicalInstrumentShopEntities1 GetContext()
        {
            if (_context == null)
                _context = new MusicalInstrumentShopEntities1();
            return _context;
        }
    }
}
