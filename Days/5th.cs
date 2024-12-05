using System.Formats.Tar;

public class Day5
{
    public int PagePrinting(string printOrderFilePath, string rulesFilePath)
    {
        List<int> middlePages = new List<int>{};
        var printOrders = File.ReadLines(printOrderFilePath);
        string rulesUnsorted = File.ReadAllText(rulesFilePath); 
        string[] rules = rulesUnsorted.Split(' '); //does not split. Array has 1 length
        Console.WriteLine(rules.Length);
        
        foreach(string printOrder in printOrders)
        {
            string[] strArr = printOrder.Split(',');
            int missingRule = 0;
            for(int i = 0; i < strArr.Length; i++)
            {
                foreach(string page in strArr)
                {

                    if(rules.Contains($"{strArr[i]}|{page}")) 
                    {        
                        missingRule++;
                    }
                }
            }
            if(missingRule == strArr.Length)
            {
                middlePages.Add(Convert.ToInt32(strArr[strArr.Length /2]));
            }
            
        }
        return middlePages.Sum();
    }
}