using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeCore.ApiValidation {
    /// <summary>
    /// Validation of Contest rules
    /// </summary>
    public static class ContestRulesValidation {

        /// <summary>
        /// Minimum Age of 18 Validation
        /// </summary>
        /// <param name="birthdate"></param>
        /// <returns></returns>
        public static bool HasContestantMinimumAge(DateTime birthdate) {

            //  have to  subtract a year due to Gregorian Calendar.
            var span = DateTime.Now - birthdate;
            var age = (new DateTime(1, 1, 1) + span).Year - 1;

            return age >= 18;
        }

        /// <summary>
        /// Maximum number of 2 participations validation
        /// </summary>
        /// <param name="numberOfParticipation"></param>
        /// <returns></returns>
        public static bool HasValidNummerOfParticipation(int numberOfParticipation) {
            int max = 2;
            return max <= numberOfParticipation;
        }
    }
}
