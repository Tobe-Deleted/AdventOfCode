using System.Formats.Tar;

public class Day5
{
    public int PagePrinting(string printOrderFilePath, string rulesFilePath)
    {
        List<int> middlePages = new List<int>{};
        var printOrders = File.ReadLines(printOrderFilePath);
        string[] rules = File.ReadAllLines(rulesFilePath);

        foreach(string printOrder in printOrders)
        {
            string[] strArr = printOrder.Split(',');
            int missingRule = 0;
            for(int i = 0; i < strArr.Length; i++)
            {
                if (i < strArr.Length -1)
                {
                    foreach(string page in strArr)
                    {
                        if(!rules.Contains($"{strArr[i]}|{strArr[i+1]}"))
                        {       
                            missingRule++;
                        }
                    }
                }
            }

            if(missingRule > 0)
            {
                string[] currentPages = new string[strArr.Length];

                foreach(string page in strArr)
                {
                    int placement = -1;

                    for(int i = 0; i < strArr.Length; i++)
                    {
                        if(!rules.Contains($"{page}|{strArr[i]}"))
                        {
                            placement++;
                        }
                    }

                    currentPages[placement] = page;
                }

                middlePages.Add(Convert.ToInt32(currentPages[currentPages.Length / 2]));

            }
            
        }
        return middlePages.Sum();
    }
}