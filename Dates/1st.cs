using System.Xml.XPath;

public class Day1
{
    public int TotalDistance(string str)
    {
        int result = 0;
        string[] pairs = str.Replace("   ", "_").Split(" ");
        foreach (string s in pairs) Console.WriteLine(s);
        return result;
    }
}