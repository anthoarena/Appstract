using AcmeInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeInfrastructure.Interfaces {
    public interface IContest {
        ContestantDTO NewContestant(ContestantRequestDTO contestant);
        IEnumerable<ContestantDTO> AllContestant();
    }
}