namespace backend.Helpers
{
    public class PasswordModifier
    {
        private const string Prefix = "GD@"; // Added at the beginning
        private const string Suffix = "#AK"; // Added at the end
        private const string Middle = "2025"; // Inserted in the middle

        public static string ModifyPassword(string password)
        {
            int mid = password.Length / 2;
            return Prefix + password.Substring(0, mid) + Middle + password.Substring(mid) + Suffix;
        }

        public static string ReconstructPassword(string modifiedPassword)
        {
            if (!modifiedPassword.StartsWith(Prefix) || !modifiedPassword.EndsWith(Suffix))
            {
                return null; // Invalid password format
            }

            string trimmed = modifiedPassword.Substring(Prefix.Length, modifiedPassword.Length - (Prefix.Length + Suffix.Length));
            return trimmed.Replace(Middle, ""); // Remove the middle part
        }

        public static bool VerifyPassword(string enteredPassword, string storedModifiedPassword)
        {
            string expectedModifiedPassword = ModifyPassword(enteredPassword);
            return expectedModifiedPassword == storedModifiedPassword;
        }
    }
}
