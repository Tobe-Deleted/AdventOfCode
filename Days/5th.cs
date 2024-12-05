public class Day5
{
    public int PagePrinting(string printOrderFilePath, string rulesFilePath)
    {
        List<int> middlePages = new List<int>{};
        var printOrders = File.ReadLines(printOrderFilePath);
        string rules = File.ReadAllText(rulesFilePath); 
        string[] RulesUnsorted = rules.Split(' ');
        
        foreach(string printOrder in printOrders)
        {
            string[] strArr = printOrder.Split(',');
            for(int i = 0; i < strArr.Length; i++)
            {
                int missingRule = -1;
                foreach(string page in strArr)
                {
                    if(!RulesUnsorted.Contains($"{strArr[i]}|{page}"))
                    {
                        missingRule++;
                    }
                }

                if(missingRule < 1)
                {
                    middlePages.Add(Convert.ToInt32(strArr[strArr.Length /2]));
                }
            }
            
        }
        return middlePages.Sum();
    }
}