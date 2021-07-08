using AcmeCore.ApiValidation;
using AcmeCore.Model;
using AcmeInfrastructure.DTO;
using AcmeInfrastructure.DTO.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcmeWebAPI.Validation {
    public static class RequestValidation {

        public static  Response<ContestantDTO> ValidateDrawRequest(ContestantRequestDTO contestant, List<ContestantDTO> contestants, List<ProductDTO> products) {
            var response = new Response<ContestantDTO>();
            response.Errors = new List<string>();
            if (contestant == null) {
                response.Errors.Add("Invalid request - All fields are missing");
                response.Message = "Bad Request";
                response.StatusCode = 404;
                response.Succeeded = false;
                response.Data = null;

                return response;
            }

            if (ContestDataValidation.CheckContestantDraw(contestant).Count > 0) {
                ContestDataValidation.CheckContestantDraw(contestant).ForEach(error => response.Errors.Add(error));
            }

            if (!string.IsNullOrEmpty(ContestDataValidation.ValidateBirthdate(contestant.Birthdate))) {
                response.Errors.Add(ContestDataValidation.ValidateBirthdate(contestant.Birthdate));
            }

            if (contestant.Email != null)
                if (!string.IsNullOrEmpty(ContestDataValidation.ValidateEmail(contestant.Email))) {
                    response.Errors.Add(ContestDataValidation.ValidateEmail(contestant.Email));
                }

            if (!string.IsNullOrEmpty(ContestDataValidation.ValidateSerialNumber(products, contestant.SerialNumber))) {
                response.Errors.Add(ContestDataValidation.ValidateSerialNumber(products, contestant.SerialNumber));
            }

            if (!ContestRulesValidation.HasContestantMinimumAge(contestant.Birthdate)) {
                response.Errors.Add("Participant under age limit of 18 years old");
            }

            if (!ContestRulesValidation.HasValidNummerOfParticipation(contestants.Count(x => x.Email.Equals(contestant.Email, System.StringComparison.InvariantCultureIgnoreCase)))) {
                response.Errors.Add("Participant has reached the limit number of participation.");
            }

            if (response.Errors.Count > 0) {
                response.Message = "Bad Request";
                response.StatusCode = 400;
                response.Succeeded = false;
                response.Data = null;
                return response;
            }
            else {
                response.Message = "OK";
                response.StatusCode = 200;
                response.Succeeded = true;
                response.Data = new ContestantDTO { Firstname = contestant.Firstname, Lastname = contestant.Lastname, Email = contestant.Email, SerialNumber = contestant.SerialNumber };
            }

            return response;
        }
    }
}
