using System.Reflection.Emit;

public class Day8
{
    public int AntiNodes(string filePath)
    {
        string antiNodes = "";
        string allChars = new String(File.ReadAllText(filePath).Replace(".", "").Distinct().ToArray());
        allChars = new string(allChars.ToCharArray()
                                      .Where(c => !Char.IsWhiteSpace(c))
                                      .ToArray());

        string[] fullMap = File.ReadAllLines(filePath);
        char[,] editMap = new char[fullMap.Length, fullMap.Length];

        List<int[]> antiNodeCoords = new List<int[]>{};
        foreach(char ch in allChars)
        {
            Console.WriteLine("------------" + ch + "------------");
            List<int[]> coords = new List<int[]>{}; 

            for(int x = 0; x < fullMap.Length; x++)
            {
                for(int y = 0; y < fullMap.Length; y++)
                {
                    if(fullMap[x][y] == ch)
                    {
                        int[] coord = {x, y};
                        coords.Add(coord);
                    }
                }
            }
            

            for(int i = 0; i  < coords.Count(); i++)
            {
                foreach(int[] coord in coords)
                {
                    // Console.WriteLine("--------------" + coord[0] + " " + coord[1] + "------------------");
                    if(coords[i] != coord)
                    {
                        int[] difference = {Math.Abs(coords[i][0] - coord[0]), Math.Abs(coords[i][1] - coord[1])};
                        int[] antiNodeCoord = new int[2];
                        bool isValid = true;
                        
                        if(coords[i][0] < coord[0])
                            antiNodeCoord[0] = coords[i][0] - difference[0];
                        else
                            antiNodeCoord[0] = coords[i][0] + difference[0];

                        if(coords[i][1] < coord[1])
                            antiNodeCoord[1] = coords[i][1] - difference[1];
                        else
                            antiNodeCoord[1] = coords[i][1] + difference[1];
                        // Console.WriteLine("check: " + antiNodeCoord[0] + "," + antiNodeCoord[1]);
                        foreach(int n in antiNodeCoord)
                        {
                            if (n < 0 || n > 49)
                                isValid = false;
                        }
                            // Console.WriteLine("after check: " + antiNodeCoord[0] + "," + antiNodeCoord[1] + " | " + isValid);    

                        if(isValid)
                        {
                            antiNodeCoords.Add(antiNodeCoord);
                            Console.WriteLine($"1st: {antiNodeCoord[1]}, {antiNodeCoord[0]}");
                            Console.ReadKey();
                        }
                        else
                            isValid = true;

                        if(coords[i][1] > coord[1])
                            antiNodeCoord[1] = coord[1] - difference[1];
                        else
                            antiNodeCoord[1] = coord[1] + difference[1];

                        if(coords[i][0] > coord[0])
                            antiNodeCoord[0] = coord[0] - difference[0];
                        else
                            antiNodeCoord[0] = coord[0] + difference[0];
                        
                    // Console.WriteLine("check: " + antiNodeCoord[0] + "," + antiNodeCoord[1]);
                        foreach(int n in antiNodeCoord)
                        {
                            if (n < 0 || n > 49)
                                isValid = false;
                        }
                    // Console.WriteLine("after check: " + antiNodeCoord[0] + "," + antiNodeCoord[1] + " | " + isValid);      
                        if(isValid)
                        {
                            antiNodeCoords.Add(antiNodeCoord);
                            Console.WriteLine($"2nd: {antiNodeCoord[1]}, {antiNodeCoord[0]}");
                            Console.ReadKey();
                        }
                    }

                }
                    foreach(int[] antiNode in antiNodeCoords)
                    {
                        Console.WriteLine($"{antiNode[0]},{antiNode[1]}");
                        Console.ReadKey();
                        editMap[antiNode[0],antiNode[1]] = '#';
                    }
            }
        }

        foreach(char c in editMap)
            antiNodes += c;

        return antiNodes.Count(x => x == '#');
    }
}