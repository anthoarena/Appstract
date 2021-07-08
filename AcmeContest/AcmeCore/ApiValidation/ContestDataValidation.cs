using AcmeInfrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AcmeCore.ApiValidation {

    /// <summary>
    /// Contestant data validation
    /// creation of error message for invalid data
    /// </summary>
    public static class ContestDataValidation {

        /// <summary>
        /// Validate all mandatory data
        /// </summary>
        /// <param name="contestant"></param>
        /// <returns>an error message if not valid or an empty string list</returns>
        public static List<string> CheckContestantDraw(ContestantRequestDTO contestant) {
            var errors = new List<string>();
            if (contestant.Birthdate == null)
                errors.Add("Birthdate value is missing");

            if (string.IsNullOrEmpty(contestant.Firstname))
                errors.Add("First name value is missing");

            if (string.IsNullOrEmpty(contestant.Lastname))
                errors.Add("Last name value is missing");

            if (string.IsNullOrEmpty(contestant.Email))
                errors.Add("Email value is missing");

            if (contestant.SerialNumber == Guid.Empty)
                errors.Add("Serial number is missing");

            return errors;
        }

        /// <summary>
        /// Validate Birthdate under 100 years old
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns>an error message if not valid or an empty string </returns>
        public static string ValidateBirthdate(DateTime birthdate) {
            if (birthdate > new DateTime(1920, 1, 1))
                return "Error with birthdate, over 100 years old.";
            return String.Empty;
        }

        /// <summary>
        /// Validate input Serial Number is an Acme serial Number
        /// </summary>
        /// <param name="productList"></param>
        /// <param name="sn"></param>
        /// <returns>an error message if not valid or an empty string </returns>
        public static string ValidateSerialNumber(List<ProductDTO> productList, Guid sn) {
            var product = productList.Where(x => x.SerialNumber == sn).FirstOrDefault();
            if (product == null)
                return $"Error the SerialNumber {sn} is not valid";
            return string.Empty;
        }

        /// <summary>
        /// Validate Email format
        /// </summary>
        /// <param name="email"></param>
        /// <returns>an error message if not valid or an empty string </returns>
        public static string ValidateEmail(string email) {
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            bool isValidEmail = regex.IsMatch(email);
            if (!isValidEmail) {
                return $"The email {email} is invalid";
            }

            return string.Empty;
        }
    }
}
