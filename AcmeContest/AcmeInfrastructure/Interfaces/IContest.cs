using AcmeInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeInfrastructure.Interfaces {
    public interface IContest {
        bool NewContestant(ContestantRequestDTO contestant);
        IEnumerable<ContestantDTO> AllContestant();
        IEnumerable<ProductDTO> AllProducts();
    }
}