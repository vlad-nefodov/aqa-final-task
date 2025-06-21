namespace Tests
{
    public static class DataProvider
    {
        public static IEnumerable<string[]> LoginForm_UC1_Data
        {
            get
            {
                yield return new string[] { "standard_user", "secret_sauce" };
                yield return new string[] { "     ", "123456" };
                yield return new string[] { "!@#$%^", "<script>alert(1)</script>" };
            }
        }

        public static IEnumerable<string[]> LoginForm_UC2_Data
        {
            get
            {
                yield return new string[] { " s ", "123456" };
                yield return new string[] { "locked_out_user", "doesntmatter" };
                yield return new string[] { "secret_sauce", "standard_user" };
            }
        }

        public static IEnumerable<string[]> LoginForm_UC3_Data
        {
            get
            {
                yield return new string[] { "standard_user", "secret_sauce" };
                yield return new string[] { "problem_user", "secret_sauce" };
                yield return new string[] { "error_user", "secret_sauce" };
                yield return new string[] { "visual_user", "secret_sauce" };
            }
        }
    }
}
