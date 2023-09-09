
public static class Util
{
    public static bool IsWildcardMatch(string pattern, string input)
    {
        if (pattern.StartsWith("*.", System.StringComparison.Ordinal))
        {
            return input.EndsWith(pattern.Substring(1), System.StringComparison.Ordinal);
        }
        if (!pattern.Contains('*', System.StringComparison.Ordinal) && !pattern.Contains('?', System.StringComparison.Ordinal))
        {
            return pattern == input;
        }
        int i = 0, j = 0;
        while (i < input.Length && j < pattern.Length)
        {
            if (pattern[j] == '*')
            {
                if (j + 1 == pattern.Length)
                {
                    return true;
                }
                while (i < input.Length)
                {
                    if (IsWildcardMatch(pattern.Substring(j + 1), input.Substring(i)))
                    {
                        return true;
                    }
                    i++;
                }
                return false;
            }
            else if (pattern[j] == '?' || pattern[j] == input[i])
            {
                i++;
                j++;
            }
            else
            {
                return false;
            }
        }

        if (i == input.Length)
        {
            while (j < pattern.Length && pattern[j] == '*')
            {
                j++;
            }
        }

        return i == input.Length && j == pattern.Length;
    }
}
