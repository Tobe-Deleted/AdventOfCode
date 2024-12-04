using System.Xml.XPath;

public class Day2
{
    public int SafeReports(string filePath)
    {
        int safeReports = 0;
        var reports = File.ReadLines(filePath);
        foreach(string report in reports)
        {
            string[] strArr = report.Split(' ');
            int[] currentReport = new int[strArr.Length];
            for(int i = 0; i < strArr.Length; i++)
            {
                currentReport[i] = Convert.ToInt32(strArr[i]);
            }
            
        }
        return safeReports;
    }
}