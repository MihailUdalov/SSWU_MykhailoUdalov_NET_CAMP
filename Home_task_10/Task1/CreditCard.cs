namespace Task1
{
    internal class CreditCard
    {
        public string CardNumber { get; private set; }
        public CardTypes Type { get; private set; }

        public CreditCard()
        {
            
        }

        public CreditCard(string cardNumber, CardTypes type)
        {
            CardNumber = cardNumber;
            Type = type;
        }

        public static CreditCard Parse(string cardNumber)
        {                     
            return new CreditCard(Validator.LuhnAlgorithm(cardNumber), Validator.TypeCreditCard(cardNumber));
        }

        public override string ToString()
        {
            return $"# {Type} # card_number = {CardNumber}";
        }

    }
}
