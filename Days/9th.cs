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
        int index = 0;

        for(int i = 0; i < filePointers.Length; i++)
        {
            // Console.WriteLine($"{i}, {filePointers[i]}");
            if(i % 2 == 0)
            {
                for(int j = 0; j < filePointers[i]; j++)
                {
                    blockExpander.Add(index);
                }
                    index++;
                    
            }
            else
            {
                for(int j = 0; j < filePointers[i]; j++)
                {
                    // Console.WriteLine($"{j}, {filePointers[i]}");
                    blockExpander.Add(-1);
                    // Console.ReadKey();
                }
            }

        }
                    // foreach(int i in blockExpander)Console.WriteLine(i);

        
        for(int i = 0; i < blockExpander.Count(nodes => nodes == -1); i++)
        {
            if(blockExpander[blockExpander.Count()-1 -i] != -1)
            {
                // Console.WriteLine(blockExpander[blockExpander.Count()-1 -i]);
                for(int j = 0; j < blockExpander.Count(); j++)
                {
                    if(blockExpander[j] == -1)
                    {
                        // Console.WriteLine(i);
                        // Console.WriteLine($"{blockExpander[blockExpander.Count()-1 -i]}, {blockExpander[j]}");
                        int b = blockExpander.Count()-1 -i;
                        (blockExpander[j], blockExpander[b]) = (blockExpander[b], blockExpander[j]);
                        // foreach(int  integ in blockExpander)Console.Write($"{integ}, ");
                        // Console.WriteLine();
                        // Console.ReadKey();
                        break;
                    }
                }
            }
        }
        // foreach(int i in blockExpander)Console.WriteLine(i);
        // Console.WriteLine("ending");
        for(int i = 0; i < blockExpander.Count(); i++)
        {
            // Console.WriteLine($"{i}, {blockExpander[i]}");
            if(blockExpander[i] > -1)
            result += i * blockExpander[i];
        }

        return result;
    }
}