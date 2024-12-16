public class Day10
{
    public int TrailHeadScore(string filePath)
    {
        int TrailHeadPaths = 0;
        string[] fullMap = File.ReadAllLines(filePath);

        for(int x = 0; x < fullMap.Length; x++)
        {
            for(int y = 0; y < fullMap.Length; y++)
            {
                // Console.WriteLine($"x:{x} y:{y}");
                if(fullMap[x][y] == '0' || 
                   fullMap[x][y] == '0' ||
                   fullMap[x][y] == '0' ||
                   fullMap[x][y] == '0')
                {
                    TrailHeadPaths += TrailHeadSearch(x, y, 0, fullMap);
                    Console.WriteLine($"x:{x} y: {y}");
                    Console.WriteLine(TrailHeadPaths);
                    Console.ReadKey();
                }
            }
        }

        return TrailHeadPaths;
    }

    public int TrailHeadSearch(int a, int b, int current, string[] fullMap)
    {
        // Console.WriteLine($"a:{a} b:{b}");
        string numbers = "0123456789";
        int paths = 0;
        int next = current +1;
        // Console.WriteLine(next);

            // Console.WriteLine($"a:{a+1} b:{b} map:{fullMap[1][2]}");
            // Console.ReadKey();
            if(a+1 < fullMap.Length)
            {
                // Console.WriteLine($"a:{a} b:{b} fullmap:{fullMap[a+1][b]} next:{next}");
                // Console.WriteLine($"{fullMap[a+1][b] }{ numbers[next]}");
                if(fullMap[a+1][b] == numbers[next])
                {
                    Console.WriteLine($"a:{a+1} b:{b} = {fullMap[a+1][b]} next:{next}");
                    if(fullMap[a+1][b] == numbers[9] && next == 9) 
                    {
                        Console.WriteLine("+1");
                        paths++;
                    }
                    else if(next < 9)
                    {
                        paths += TrailHeadSearch(a+1, b, next, fullMap);
                    }
                }
                // Console.ReadKey();
            }
            // Console.WriteLine($"a:{a-1} b:{b} fullmap:{fullMap[a-1][b]} next:{next}");
            if(a-1 > 0)
            {
                if(fullMap[a-1][b] == numbers[next])
                {
                    Console.WriteLine($"a:{a-1} b:{b} = {fullMap[a-1][b]} next:{next}");
                    if(fullMap[a-1][b] == numbers[9] && next == 9) 
                    {
                        Console.WriteLine("+1");
                        paths++;
                    }
                    else if(next < 9)
                    {
                        paths += TrailHeadSearch(a-1, b, next, fullMap);
                    }
                }
            }
            // Console.WriteLine($"a:{a} b:{b-1} fullmap:{fullMap[a][b-1]} next:{next}");
            if(b-1 > 0)
            {
                if(fullMap[a][b-1] == numbers[next])
                {
                    Console.WriteLine($"a:{a} b:{b-1} = {fullMap[a][b-1]} next:{next}");
                    if(fullMap[a][b-1] == numbers[9] && next == 9) 
                    {
                        Console.WriteLine("+1");
                        paths++;
                    }
                    else if(next < 9)
                    {
                        paths += TrailHeadSearch(a, b-1, next, fullMap);
                    }
                }
            }
            // Console.WriteLine($"a:{a} b:{b+1} fullmap:{fullMap[a][b+1]} next:{next}");
            if(b+1 < fullMap.Length)
            {
                if(fullMap[a][b+1] == numbers[next])
                {
                    Console.WriteLine($"a:{a} b:{b+1} = {fullMap[a][b+1]} next:{next}");
                    if(fullMap[a][b+1] == numbers[9] && next == 9) 
                    {
                        Console.WriteLine("+1");
                        paths++;
                    }
                    else if(next < 9)
                    {
                        paths += TrailHeadSearch(a, b+1, next, fullMap);
                    }
                }
            }
            // Console.ReadKey();
        // Console.WriteLine(paths);
        return paths;
    }
}