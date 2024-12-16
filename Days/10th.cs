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
                    int TrailHeadPaths = TrailHeadSearch(x, y, 0, fullMap);
                }
            }
        }

        return 0;
    }

    public int TrailHeadSearch(int a, int b, int current, string[] fullMap)
    {
        int paths = 0;
        int next = current +1;
        for(int i = 0; i < 9; i++)
        {
            if(fullMap[a+1][b] == next)
            {
                if(fullMap[a+1][b] == 9) paths++;
                else paths += TrailHeadSearch(a+1, b, next, fullMap);
            }
            if(fullMap[a-1][b] == next)
            {
                if(fullMap[a-1][b] == 9) paths++;
                else paths += TrailHeadSearch(a-1, b, next, fullMap);
            }
            if(fullMap[a][b-1] == next)
            {
                if(fullMap[a][b-1] == 9) paths++;
                else paths += TrailHeadSearch(b-1, b, next, fullMap);
            }
            if(fullMap[a][b+1] == next)
            {
                if(fullMap[a][b+1] == 9) paths++;
                else paths += TrailHeadSearch(b+1, b, next, fullMap);
            }
        }

        return paths;
    }
}