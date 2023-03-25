namespace PatternRepository.Core.Options
{
    public class PasswordOptions
    {
        public int Iteration { get; set; }
        public int SaltSize { get; set; }
        public int KeySize { get; set; }

    }
}
