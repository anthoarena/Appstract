using AcmeCore.Model;
using AcmeInfrastructure.DTO;
using AcmeInfrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCore.Repository {
    public class ContestService : IContest {

        private readonly AcmeContext _db;

        public ContestService(AcmeContext db) {
            _db = db;
        }

        /// <summary>
        /// Get All Contestants to contest
        /// </summary>
        /// <returns>list of contestantDto´or null if exception caught</returns>
        public IEnumerable<ContestantDTO> AllContestant() {
            try {
                List<ContestantDTO> contestantList = new List<ContestantDTO>();
                var contestants = _db.GetAllContestants();

                if (contestants != null)
                    foreach (var contestant in contestants) {
                        contestantList.Add(new ContestantDTO {
                            Firstname = contestant.Firstname,
                            Lastname = contestant.Lastname,
                            Email = contestant.Email,
                            SerialNumber = contestant.SerialNumber
                        });
                    }
                return contestantList;
            }
            catch (Exception) {
                return null;
            }
        }

        /// <summary>
        /// Create new contestant to the acme contest
        /// </summary>
        /// <param name="contestant"></param>
        /// <returns>true if object saved</returns>
        public bool NewContestant(ContestantRequestDTO contestant) {
            try {
                _db.Contestants.Add(new Contestant {
                    Firstname = contestant.Firstname,
                    Lastname = contestant.Lastname,
                    Email = contestant.Email,
                    SerialNumber = contestant.SerialNumber
                });
                return _db.SaveChanges() > 0 ? true : false;
            }
            catch (Exception) {
                return false;
            }
        }

        /// <summary>
        /// Get All products with serial number 
        /// </summary>
        /// <returns>list of serial number with product name or null</returns>
        public IEnumerable<ProductDTO> AllProducts() {
            try {
                List<ProductDTO> productList = new List<ProductDTO>();
                var products = _db.GetAllProducts();

                if (products != null)
                    foreach (var product in products) {
                        productList.Add(new ProductDTO {
                            Name = product.Name,
                            SerialNumber = product.SerialNumber
                        });
                    }
                return productList;
            }
            catch (Exception) {
                return null;
            }        
        }

    }
}
