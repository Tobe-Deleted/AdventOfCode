using System.Data.Common;

public class Day6
{
    public int GuardPath(string filePath)
    {
        int dx = -1; int dy = 0;
        int x = 59; int y = 62;
        var map = File.ReadAllLines(filePath);
        string mapString = "";
        foreach(string line in map) mapString += line;
        char[,] obstructionsMap = new char[130,130];
        for(int i = 0; i < 130; i++)
        {
            for(int n = 0; n < 130; n++)
            {
                obstructionsMap[i,n] = map[i][n];
            }
        }
        // string[,] markedMap = new string[130,130];
        // string path = "";
        List<int[]> coordinates = new List<int[]>{};
        
        while(true)
        {
            if(x+dx < 0 || x+dx > 129 ||
               y+dy < 0 || y+dy > 129) // end logic
            {
                // markedMap[x,y] = 'X'.ToString();

                // foreach(string line in markedMap)
                // {
                //     path += line;
                // }

                //return path.Count(c => c == 'X');
                break;
            }

            if(map[x+dx][y+dy] == '#') //change direction
            {
                (dx, dy) = (dy, -dx);
            }
            else                        //straight path
            {
                // markedMap[x,y] = 'X'.ToString();
                y += dy; x += dx;
                int[] temp = {x,y};
                coordinates.Add(temp);
            }
        }

        int coordinatesSelector = 0;
        int counter = 0;
        char[,] charArray = obstructionsMap;
        charArray[x,y] = '#';
        int iterations = 0;
        x = 59; y =62;

        while(true)
        {
            if(coordinatesSelector >= coordinates.Count()-1)
                return counter;
            if(x+dx < 0 || x+dx > 129 ||
               y+dy < 0 || y+dy > 129)
            {
                charArray = obstructionsMap;
                charArray[coordinates[coordinatesSelector][0], 
                          coordinates[coordinatesSelector][1]] = '#';
                          coordinatesSelector++;
                x = 59; y = 62;
                iterations = 0;
            }
            else if(iterations > mapString.Count(c => c == '#') * 4)
            {
                charArray = obstructionsMap;
                charArray[coordinates[coordinatesSelector][0], 
                          coordinates[coordinatesSelector][1]] = '#';
                coordinatesSelector++;
                counter++;  
                x = 59; y = 62;
                iterations = 0; 
            }
            else 
            {
                if(map[x+dx][y+dy] == '#') //change direction
                {
                    (dx, dy) = (dy, -dx);
                    Console.WriteLine(iterations);
                    Console.WriteLine(coordinatesSelector);
                    iterations++;
                }
                else                        //straight path
                {
                    y += dy; x += dx;
                }
            }
        }
    }
}