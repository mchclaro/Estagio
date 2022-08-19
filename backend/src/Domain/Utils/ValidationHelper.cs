using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Utils
{
    public static class ValidationHelper
    {
        public static string RemoveDirtCharsForCnpj(string input)
        {
            if (input == null)
            {
                return input;
            }

            return input.Replace(".", "").Replace("/", "").Replace("-", "");
        }

        public static string RemoveDirtCharsForCpf(string input)
        {
            if (input == null)
            {
                return input;
            }

            return input.Replace(".", "").Replace("-", "");
        }

        public static string RemoveDirtCharsForMobile(string input)
        {
            if (input == null)
            {
                return input;
            }

            return input.Replace("(", "").Replace(")", "").Replace(" ", "").Replace("-", "");
        }

        public static string RemoveDirtCharsForCep(string input)
        {
            if (input == null)
            {
                return input;
            }

            return input.Replace("-", "").Replace(" ", "");
        }
    }
}