using System.Globalization;
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
            else
            {
                for (int j = 0; j < currentReport.Length; j++)
                {
                    negative = 0;
                    safe = true;
                    List<int> list = currentReport.ToList();
                    list.RemoveAt(j);
                    
                    for (int i = 0; i < list.Count() -1; i++)
                    {
                        if(Math.Abs(list[i] - list[i+1]) > 3 ||
                        Math.Abs(list[i] - list[i+1]) < 1)
                        {
                            safe = false;
                        }
                        else if(list[i] - list[i+1] < 0)
                        {
                            negative++;
                        }
                    }
                    if(safe && negative == 0 || safe && negative == list.Count() -1)
                    {
                        safeReports++;
                        break;
                    }
                    else
                    {
                        // Console.WriteLine($"Neg: {negative} list: {list.Count()}");
                        // foreach (int n in list) Console.Write($" {n}");
                        // Console.ReadLine();
                    }
                    
                }
                  
            }

        }
        return safeReports;
    }
}