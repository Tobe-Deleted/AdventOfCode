public class Day8
{
    public int AntiNodes(string filePath)
    {
        string antiNodes = "";
        string allChars = new String(File.ReadAllText(filePath).Distinct().ToArray());
        
        return antiNodes.Count(x => x == '#');
    }
}