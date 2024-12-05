public class Day5
{
    public int PagePrinting(string printOrderFilePath, string rulesFilePath)
    {
        int[] middlePages = new int[194];
        var printOrders = File.ReadLines(printOrderFilePath);
        foreach(string printOrder in printOrders)
        {
            string[] strArr = printOrder.Split(',');
            int[] currentOrder = new int[strArr.Length];
            for(int i = 0; 0 < strArr.Length; i++)
                currentOrder[i] = Convert.ToInt32(strArr[i]);

            
        }
        return middlePages.Sum();
    }
}