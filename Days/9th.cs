public class Day9()
{
    public long DiskFragmenter(string filePath)
    {
        long result = 0;
        string rawData = File.ReadAllText(filePath);
        char[] filePointers = new char[rawData.Length /2 +1];
        char[] emptyPointers = new char[rawData.Length /2];
        int fp = 0;
        int ep = 0;

        for (int i = 0; i < rawData.Length; i++)
        {
            if(i % 2 == 0)
            {
                // Console.WriteLine($"{fp}, {filePointers.Length}");
                filePointers[fp] = rawData[i];
                fp++;
            }
            else
            {
                // Console.WriteLine(rawData[i]);
                emptyPointers[ep] = rawData[i];
                ep++;
            }
        }
        // foreach(char ch in emptyPointers)Console.WriteLine(ch);
        string blockExpander = "";
        int[] IDtracker = new int[filePointers.Length];

        for(int i = 0; i < filePointers.Length; i++)
        {
            Console.WriteLine(i);
            for(int n = 0; n < Convert.ToInt32(filePointers[i])-48; n++)
            {
                blockExpander += $"{i}";
                IDtracker[i] = $"{i}".Length;
            }
            // Console.WriteLine($"{i}, {emptyPointers.Length}");
            if(i != emptyPointers.Length)
            {
                // Console.WriteLine($"{Convert.ToInt32(emptyPointers[i]-48)}");
                for(int j = 0; j < Convert.ToInt32(emptyPointers[i] -48); j++)
                {
                    blockExpander += ".";
                }
            }
        }
                    Console.WriteLine(blockExpander);

        string dataCompacter = blockExpander;

        for(int i = 0; i < blockExpander.Count(c => c == '.'); i++)
        {
            for(int j = 1; j < IDtracker[IDtracker.Length -i]; j++)
            {
                Console.WriteLine(j);
            dataCompacter = dataCompacter.Insert(dataCompacter.IndexOf('.'), dataCompacter[dataCompacter.Length -1].ToString())
                                         .Remove(dataCompacter.Length -1, 1);
            }
            dataCompacter = dataCompacter.Remove(dataCompacter.IndexOf('.'), 1);
        }

        Console.WriteLine(dataCompacter);

        for(int i = 0; i < dataCompacter.Length; i++)
        {
            // Console.WriteLine(result);
            result += i * (dataCompacter[i]-48);
        }

        return result;
    }
}