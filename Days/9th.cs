using System.Data.Common;
using System.Globalization;

public class Day9()
{
    public long DiskFragmenter(string filePath)
    {
        long result = 0;
        string rawData = File.ReadAllText(filePath);
        int[] filePointers = new int[rawData.Length];
        int fp = 0;

        for (int i = 0; i < rawData.Length; i++)
        {
                filePointers[fp] = Convert.ToInt32(rawData[i] -48);
                fp++;
        }

        List<int> blockExpander= new List<int>{};

        for(int i = 0; i < filePointers.Length; i++)
        {
            // Console.WriteLine($"{i}, {filePointers[i]}");
            if(i % 2 == 0)
            {
                for(int j = 0; j <= filePointers[i]; j++)
                {
                    blockExpander.Add(i);
                }
            }
            else
            {
                for(int j = 0; j <= filePointers[i]; j++)
                {
                    blockExpander.Add(-1);
                }
            }

        }
                    foreach(int i in blockExpander)Console.WriteLine(i);

        
        for(int i = 0; i < blockExpander.Count(); i++)
        {
            if(blockExpander[blockExpander.Count()-1 -i] != -1)
            {
                for(int j = 0; i < blockExpander.Count(); j++)
                {
                    if(blockExpander[j] == -1)
                    {
                        blockExpander[j], blockExpander[blockExpander.Count()-1 -i]
                    }
                }
            }
        }


        // for(int i = 0; i < dataCompacter.Length; i++)
        // {
        //     // Console.WriteLine(result);
        //     result += i * (dataCompacter[i]-48);
        // }

        return result;
    }
}