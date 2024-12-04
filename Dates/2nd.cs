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
            int negative = 0;
            bool safe = true;
            for(int i = 0; i < strArr.Length; i++)
            {
                currentReport[i] = Convert.ToInt32(strArr[i]);
            }
            for (int i = 0; i < currentReport.Length -1; i++)
            {
                if(Math.Abs(currentReport[i] - currentReport[i+1]) > 3 ||
                   Math.Abs(currentReport[i] - currentReport[i+1]) < 1)
                {
                    safe = false;
                }
                else if(currentReport[i] - currentReport[i+1] < 0)
                {
                    negative++;
                }
            }
            if(safe && negative == 0 || safe && negative == currentReport.Length -1)
                safeReports++;

        }
        return safeReports;
    }
}