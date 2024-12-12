namespace Domain.Generator
{
    public static class GeneratorNumberAccount
    {
        private static HashSet<int> existingAccountNumbers = new HashSet<int>();
        private static Random random = new Random();

        public static int GenerateUniqueAccountNumber()
        {
            int accountNumber;

            do
            {
                accountNumber = GenerateRandomAccountNumber();
            } while (existingAccountNumbers.Contains(accountNumber));

            existingAccountNumbers.Add(accountNumber);

            return accountNumber;
        }

        private static int GenerateRandomAccountNumber()
        {
            return random.Next(100000000, 1000000000);
        }
    }
}
