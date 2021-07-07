using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCore.Model {
    public class Contestant {
        public int ContestantId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Guid SerialNumber { get; set; }
    }
}
