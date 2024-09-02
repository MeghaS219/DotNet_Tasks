
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoctorManagementSystem
{
    public static class Validator
    {
        public static bool ValidateRegistrationNo(string regNo)
        {
            return Regex.IsMatch(regNo, @"^\d{7}$");
        }

        public static bool ValidateName(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Z\s]+$");
        }

        public static bool ValidateContactNo(string contactNo)
        {
            return Regex.IsMatch(contactNo, @"^\d{10}$");
        }

        public static bool ValidateClinicTimings(string timings)
        {
            return !string.IsNullOrWhiteSpace(timings);
        }
    }
}
