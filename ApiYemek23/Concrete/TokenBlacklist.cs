namespace ApiYemek23.Concrete
{
    public class TokenBlacklist
    {
        private static readonly List<string> BlacklistedTokens = new List<string>();

        public void AddToBlacklist(string token)
        {
            BlacklistedTokens.Add(token);
        }

        public bool IsTokenBlacklisted(string token)
        {
            return BlacklistedTokens.Contains(token);
        }
    }

}
