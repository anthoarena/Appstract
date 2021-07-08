using AcmeInfrastructure.DTO;
using NUnit.Framework;
using System;
using AcmeCore.ApiValidation;
using AcmeCore.Model;
using System.Linq;
using System.Collections.Generic;
using AcmeInfrastructure.Interfaces;

namespace UnitTestAcme {
    public class Tests {

        private readonly AcmeContext _db;
        private readonly IContest _repo;

      
        ContestantRequestDTO contestantJohn1 = new ContestantRequestDTO { Firstname = "John", Lastname = "Smith", Email = "jo@mail.com", SerialNumber = new Guid("d9eb561d-1834-4d6b-a7df-b775105210b3"), Birthdate = new DateTime(1980, 1, 1) };
        ContestantRequestDTO contestantJohn2 = new ContestantRequestDTO { Firstname = "John", Lastname = "Smith", Email = "jo@mail.com", SerialNumber = new Guid("07907046-946e-42ca-b830-f7702e34130b"), Birthdate = new DateTime(1980, 1, 1) };
       
        ContestantRequestDTO contestantJohnWrongEmail = new ContestantRequestDTO { Firstname = "John", Lastname = "Smith", Email = "jomail.com", SerialNumber = new Guid("07907046-946e-42ca-b830-f7702e34130b"), Birthdate = new DateTime(1980, 1, 1) };

        ContestantRequestDTO contestantJohnUnderAge = new ContestantRequestDTO { Firstname = "John", Lastname = "Smith", Email = "jo@mail.com", SerialNumber = new Guid("b04f9697-314c-4b92-8042-f4d42f5db79e"), Birthdate = new DateTime(2010, 1, 1) };
        ContestantRequestDTO contestantJohnOver100 = new ContestantRequestDTO { Firstname = "John", Lastname = "Smith", Email = "jo@mail.com", SerialNumber = new Guid("c78da42e-2d08-42ad-9383-17e5553cf845"), Birthdate = new DateTime(1800, 1, 1) };


        ContestantRequestDTO contestantJohnWrongSN = new ContestantRequestDTO { Firstname = "John", Lastname = "Smith", Email = "jo@mail.com", SerialNumber = new Guid("123f9697-314c-4b92-8042-f4d42f5db79e"), Birthdate = new DateTime(2010, 1, 1) };

        /*
         * 
         *  
            
            
            
             
         */
        public List<ProductDTO> InitProductList() {
            List<ProductDTO> products = new List<ProductDTO>();
            products.Add( new ProductDTO { Name = "Prodone", SerialNumber = new Guid("d9eb561d-1834-4d6b-a7df-b775105210b3") } );
            products.Add(new ProductDTO { Name = "Prodtwo", SerialNumber = new Guid("80830ebe-b4de-4855-ac1c-2ac0ba01e752") } );
            products.Add(new ProductDTO { Name = "Prodthree", SerialNumber = new Guid("d354c9f5-e8b5-425c-8110-10ebe0589c0b") });
            products.Add(new ProductDTO { Name = "Podfour", SerialNumber = new Guid("de365596-c3c6-4ce8-a700-355061ff5145") });
            products.Add(new ProductDTO { Name = "Podfive", SerialNumber = new Guid("07907046-946e-42ca-b830-f7702e34130b") });
            return products;
        }

        [TestCase]
        public void TestBirthdateValidation() {
            string result1 = ContestDataValidation.ValidateBirthdate(contestantJohn1.Birthdate);
     
            Assert.AreEqual(0, result1.Length);

            var result2 = ContestDataValidation.ValidateBirthdate(contestantJohnOver100.Birthdate);
            Assert.AreNotEqual(string.Empty, result2);

        }

        [TestCase]
        public void TestSN() {

            var products = InitProductList();

            var result1 = ContestDataValidation.ValidateSerialNumber(products, contestantJohn1.SerialNumber);
            Assert.AreEqual(string.Empty, result1);

            var result2 = ContestDataValidation.ValidateSerialNumber(products, contestantJohnWrongSN.SerialNumber);
            Assert.AreNotEqual(string.Empty, result2);

        }
      
        [TestCase]
        public void TestEmailFormat() {
           var result1 = ContestDataValidation.ValidateEmail(contestantJohn2.Email);
           Assert.AreEqual(string.Empty, result1);

            var result2 = ContestDataValidation.ValidateEmail(contestantJohnWrongEmail.Email);
            Assert.AreNotEqual(string.Empty, result2);
        }

        [TestCase]
        public void TestDrawRuleMinimumAge() {
            bool overAged = ContestRulesValidation.HasContestantMinimumAge(contestantJohn1.Birthdate);
            Assert.AreEqual(true, overAged);
        }

    }
}