using AcmeInfrastructure.DTO;
using AcmeInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCore.Repository {
    public class ContestService : IContest {
        public IEnumerable<ContestantDTO> AllContestant() {
            throw new NotImplementedException();
        }

        public ContestantDTO NewContestant(ContestantRequestDTO contestant) {
            throw new NotImplementedException();
        }
    }
}
