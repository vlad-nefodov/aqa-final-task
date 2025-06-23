namespace Tests;

public static class DataProvider
{
    public static IEnumerable<string[]> LoginFormUc1Data
    {
        get
        {
            yield return new[] { "standard_user", "secret_sauce" };
            yield return new[] { "     ", "123456" };
            yield return new[] { "!@#$%^", "<script>alert(1)</script>" };
        }
    }

    public static IEnumerable<string[]> LoginFormUc2Data
    {
        get
        {
            yield return new[] { " s ", "123456" };
            yield return new[] { "locked_out_user", "doesntmatter" };
            yield return new[] { "secret_sauce", "standard_user" };
        }
    }

    public static IEnumerable<string[]> LoginFormUc3Data
    {
        get
        {
            yield return new[] { "standard_user", "secret_sauce" };
            yield return new[] { "problem_user", "secret_sauce" };
            yield return new[] { "error_user", "secret_sauce" };
            yield return new[] { "visual_user", "secret_sauce" };
        }
    }
}