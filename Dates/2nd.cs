using System.Xml.XPath;

public class Day2
{
    public int SafeReports(string filePath)
    {
        int safeReports = 0;
        var reports = File.ReadLines(filePath);
        foreach(string report in reports)
        {
            Console.WriteLine(report);
        }
        return safeReports;
    }
}