using System.Xml.XPath;

public class Day1
{
    public int TotalDistance(string str)
    {
        string[] pairs = str.Replace("   ", " ").Split(" ");
        int[] numbersLeft = new int[pairs.Length / 2];
        int[] numbersRight = new int[pairs.Length / 2];
        int[] differences = new int[pairs.Length / 2];
        int l = 0; int r = 0;
        for(int i = 0; i < pairs.Length; i++)
        {
            if (i % 2 == 0)
            {
                numbersLeft[l] = Convert.ToInt32(pairs[i]); 
                l++;
            }
            else
            {
                numbersRight[r] = Convert.ToInt32(pairs[i]);
                r++; 
            }

        }
        // Array.Sort(numbersLeft);
        // Array.Sort(numbersRight);
        for(int i = 0; i < numbersLeft.Length; i++)
            differences[i] = numbersLeft[i] * numbersRight.Count(n => n == numbersLeft[i]);
            //differences[i] = Math.Abs(numbersLeft[i] - numbersRight[i]);

        return differences.Sum();
    }
}