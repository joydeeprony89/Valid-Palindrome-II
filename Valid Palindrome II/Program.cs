using System;

namespace Valid_Palindrome_II
{
  class Program
  {
    public int previousi, previousj;
    static void Main(string[] args)
    {
      Program p = new Program();
      string s = "aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga"; // abc
      Console.WriteLine(p.ValidPalindromeRecursion(s));
    }

    public bool ValidPalindrome(string s)
    {
      if (string.IsNullOrWhiteSpace(s)) return true;
      var arr = s.ToCharArray();
      return ValidPalindromeHelper(arr, 0, s.Length - 1, 0);
    }

    public bool ValidPalindromeHelper(char[] arr, int i, int j, int missmatchCount)
    {
      while (i < j)
      {
        if (arr[i] != arr[j])
        {
          if (missmatchCount == 2) return false;
          if (missmatchCount == 1)
          {
            i = previousi;
            j = previousj;
            j--;
            missmatchCount++;
            return ValidPalindromeHelper(arr, i, j, missmatchCount);
          }
          previousi = i;
          previousj = j;
          missmatchCount++;
          i++;
          return ValidPalindromeHelper(arr, i, j, missmatchCount);
        }
        i++;
        j--;
      }

      return true;
    }

    public bool ValidPalindromeRecursion(string s)
    {
      int i = 0, j = s.Length - 1;
      while (i < j)
      {
        if (s[i] == s[j])
        {
          i++;
          j--;
        }
        else
        {
          // delete ith position character, range is i+1 till j.
          i++;
          if (!IsPalindrome(s, i, j))
          {
            // move i back to previous char.
            i--;
            // delete jth char.
            j--;
            // range is i to j-1.
            return IsPalindrome(s, i, j);
          }
          else
          {
            return true;
          }
        }
      }

      return true;
    }

    bool IsPalindrome(string s, int i, int j)
    {
      while(i < j)
      {
        if (s[i] != s[j]) return false;
        i++;j--;
      }

      return true;
    }
  }
}
