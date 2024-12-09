public class Day9()
{
    public int DiskFragmenter(string filePath)
    {
        int result = 0;
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
                Console.WriteLine(rawData[i]);
                emptyPointers[ep] = rawData[i];
            }
        }
        // foreach(char ch in emptyPointers)Console.WriteLine(ch);
        string blockExpander = "";
        for(int i = 0; i < filePointers.Length; i++)
        {
            for(int n = 0; n < Convert.ToInt32(filePointers[i])-48; n++)
            {
                blockExpander += $"{i}";
            }
            // Console.WriteLine($"{i}, {emptyPointers.Length}");
            if(i != emptyPointers.Length)
            {
                // Console.WriteLine($"{Convert.ToInt32(emptyPointers[i]-48)}");
                for(int j = 0; j < Convert.ToInt32(emptyPointers[i] -48); j++)
                {
                    blockExpander += ".";
                    Console.WriteLine(blockExpander);
                }
            }
        }

        // Console.WriteLine(blockExpander);
        return result;
    }
}