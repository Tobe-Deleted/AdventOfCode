public class Day10
{
    public int TrailHeadScore(string filePath)
    {
        string[] fullMap = File.ReadAllLines(filePath);

        for(int x = 0; x < fullMap.Length; x++)
        {
            for(int y = 0; y < fullMap.Length; x++)
            {
                if(fullMap[x][y] == '0' && y == 0 || 
                   fullMap[x][y] == '0' && x == 0 ||
                   fullMap[x][y] == '0' && y == fullMap.Length -1 ||
                   fullMap[x][y] == '0' && x == fullMap.Length -1)
                {
                    
                }
            }
        }

        return 0;
    }
}