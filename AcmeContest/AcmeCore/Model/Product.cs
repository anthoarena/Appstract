using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCore.Model {
    public class Product {
        public int ProductId { get; set; }
        public Guid SerialNumber { get; set; }
        public string Name { get; set; }
    }
}
