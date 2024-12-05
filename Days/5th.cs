public class Day5
{
    public int PagePrinting(string printOrderFilePath, string rulesFilePath)
    {
        int[] middlePages = new int[194];
        var printOrders = File.ReadLines(printOrderFilePath);
        string rules = File.ReadAllText(rulesFilePath); 
        string[] RulesUnsorted = rules.Split(' ');
        // int[] before = new int[RulesUnsorted.Length];
        // int[] after = new int[RulesUnsorted.Length];
        // int a = 0; int b = 0;
        // for(int i = 0; i < RulesUnsorted.Length; i++)
        // {
        //     if(i % 2 == 1)
        //     {
        //         after[a] = Convert.ToInt32(RulesUnsorted[i]);
        //         a++;
        //     }
        //     else
        //     {
        //         before[b] = Convert.ToInt32(RulesUnsorted[i]);
        //         b++;
        //     }
        // }
        

        foreach(string printOrder in printOrders)
        {
            string[] strArr = printOrder.Split(',');
            int[] currentOrder = new int[strArr.Length];

            for(int i = 0; i < strArr.Length; i++)
            {
                currentOrder[i] = Convert.ToInt32(strArr[i]);
            }
            
        }
        return middlePages.Sum();
    }
}