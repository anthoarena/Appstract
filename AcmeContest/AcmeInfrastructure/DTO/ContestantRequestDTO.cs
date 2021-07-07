using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeInfrastructure.DTO {
    public class ContestantRequestDTO {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Guid SerialNumber { get; set; }

        public DateTime Birthdate { get; set; }
    }

}
