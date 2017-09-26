using System;
using System.Text.RegularExpressions;

namespace HBSIS.SpaUserControl.Application.Validations
{
    public class EmailAssertionConcern
    {
        public static void AssertIsValid(string email, string errorMessage)
        {
            if (
                !Regex.IsMatch(email,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase))
                throw new Exception(errorMessage);
        }
    }
}
