using System.Data.Common;
using System.Runtime;
using System.Threading.Tasks.Dataflow;

public class Day6
{
    test6 t6 = new test6();
    public int GuardPath(string filePath)
    {
        int dx = -1; int dy = 0;
        int x = 59; int y = 62;
        var map = File.ReadAllLines(filePath);
        string mapString = "";
        foreach(string line in map) mapString += line;
        char[,] obstructionsMap = new char[map.Count(),map.Count()];
        for(int i = 0; i < map.Count(); i++)
        {
            for(int n = 0; n < map.Count(); n++)
            {
                obstructionsMap[i,n] = map[i][n];
            }
        }
        // string[,] markedMap = new string[130,130];
        // string path = "";
        List<int[]> coordinates = new List<int[]>{};
        int counter = 0;
        
        while(true)
        {
            if(x+dx < 0 || x+dx >= map.Count()-1 ||
               y+dy < 0 || y+dy >= map.Count()-1) // end logic
            {
                // markedMap[x,y] = 'X'.ToString();

                // foreach(string line in markedMap)
                // {
                //     path += line;
                // }

                //return path.Count(c => c == 'X');
                int[] temp = {x,y};
                coordinates.Add(temp);
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
        char[,] charArray = obstructionsMap;
        x = 59; y =62; 
        foreach (int[] coord in coordinates)
        {
            foreach(int n in coord) Console.Write($"{n}, ");
            Console.ReadKey();
        }

        while(true)
        {
            if(coordinatesSelector >= coordinates.Count()-1 ) //has tried all coords
                return counter;
            
            if(x+dx < 0 || x+dx >= map.Count() ||
               y+dy < 0 || y+dy >= map.Count()) // is not loop
            {
                if(coordinatesSelector > 0)
                charArray[coordinates[coordinatesSelector-1][0], 
                          coordinates[coordinatesSelector-1][1]] = '.';

                charArray[coordinates[coordinatesSelector][0], 
                          coordinates[coordinatesSelector][1]] = '#';
                          coordinatesSelector++;
                x = 59; y = 62;
                dx = -1; dy = 0;
            }
            else if(t6.ConfirmLoop(x, y, dx, dy, charArray)) //is loop
            {
                Console.WriteLine($"# - x: {coordinates[coordinatesSelector-1][0]} y: {coordinates[coordinatesSelector-1][1]}");
                if(coordinatesSelector > 0)
                charArray[coordinates[coordinatesSelector-1][0], 
                          coordinates[coordinatesSelector-1][1]] = '.';

                charArray[coordinates[coordinatesSelector][0], 
                          coordinates[coordinatesSelector][1]] = '#';
                coordinatesSelector++;
                counter++;  
                Console.WriteLine(counter);
                x = 59; y = 62;
                dx = -1; dy = 0;

            }
            else 
            {
                if(charArray[x+dx, y+dy] == '#') //change direction
                {
                    (dx, dy) = (dy, -dx);
                }
                else                        //straight path
                {
                    y += dy; x += dx;
                }           
            }
        }
    }
}