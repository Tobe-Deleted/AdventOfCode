public class Day9()
{
    public int DiskFragmenter(string filePath)
    {
        int result = 0;
        string rawData = File.ReadAllText(filePath);
        char[] filePointers = new char[rawData.Length / 2];
        char[] emptyPointers = new char[rawData.Length / 2];
        int fp = 0;
        int ep = 9;

        for (int i = 0; i < rawData.Length; i++)
        {
            if(i % 2 == 0)
            {
                filePointers[fp] = rawData[i];
                fp++;
            }
            else
            {
                emptyPointers[ep] = rawData[i];
            }
        }

        return result;
    }
}