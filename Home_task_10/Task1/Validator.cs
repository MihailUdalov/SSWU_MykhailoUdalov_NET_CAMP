using System.Text.RegularExpressions;

namespace Task1
{
    internal static class Validator
    {
        public static CardTypes TypeCreditCard(string cardNumber)
        {
            if (Regex.IsMatch(cardNumber, @"^4\d{12}(\d{3})?$"))
                return CardTypes.Visa;

            if (Regex.IsMatch(cardNumber, @"^3[47]\d{13}$"))
                return CardTypes.AmericanExpress;

            if (Regex.IsMatch(cardNumber, @"^5[1-5]\d{14}$"))
                return CardTypes.MasterCard;

            return CardTypes.None;
        }

        public static string LuhnAlgorithm(string cardNumber)
        {
            int sum = 0;
            bool doubleDigit = false;

            for (int i = cardNumber.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(cardNumber[i].ToString());

                if (doubleDigit)
                {
                    digit *= 2;

                    if (digit > 9)
                        digit = digit % 10 + digit / 10;
                }

                sum += digit;
                doubleDigit = !doubleDigit;
            }

            if (sum % 10 == 0)
                return cardNumber;

            return "0";
        }
    }
}
