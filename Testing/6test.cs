using System.Security.Principal;

public class test6
{
    public bool ConfirmLoop(int x, int y, int dx, int dy, char[,] map)
    {
        List<string> coordinates = new List<string>{};
        while(true)
        {
            
            if(coordinates.Contains($"{y}{x}{dx}{dy}")) return true;
            if(x+dx < 0 || x+dx >= 129 ||
               y+dy < 0 || y+dy >= 129) // end logic
            {
                // markedMap[x,y] = 'X'.ToString();

                // foreach(string line in markedMap)
                // {
                //     path += line;
                // }

                //return path.Count(c => c == 'X');

                break;
            }

            if(map[x+dx,y+dy] == '#') //change direction
            {
                coordinates.Add($"{y}{x}{dx}{dy}");
                // Console.WriteLine(coordinates.Count());
                (dx, dy) = (dy, -dx);
            }
            else                        //straight path
            {
                // markedMap[x,y] = 'X'.ToString();
                coordinates.Add($"{y}{x}{dx}{dy}");
                // Console.WriteLine(coordinates.Count());
                y += dy; x += dx;
            }
        }
        return false;
    }
}