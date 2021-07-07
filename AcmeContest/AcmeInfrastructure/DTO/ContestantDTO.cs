using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeInfrastructure.DTO {
    public class ContestantDTO {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Guid SerialNumber { get; set; }

    }
}