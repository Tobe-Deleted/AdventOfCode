using System.Data.Common;

public class Day6
{
    public int GuardPath(string filePath)
    {
        int dx = -1; int dy = 0;
        int x = 59; int y = 62;
        var map = File.ReadAllLines(filePath);
        string[,] markedMap = new string[130,130];
        string path = "";
        
        while(true)
        {
            if(x+dx < 0 || x+dx > 129 ||
               y+dy < 0 || y+dy > 129) // end logic
            {
                markedMap[x,y] = 'X'.ToString();

                foreach(string line in markedMap)
                {
                    path += line;
                }

                return path.Count(c => c == 'X');
            }

            if(map[x+dx][y+dy] == '#') //change direction
            {
                (dx, dy) = (dy, -dx);
            }
            else                        //straight path
            {
                markedMap[x,y] = 'X'.ToString();
                y += dy; x += dx;
            }
        }
    }
}