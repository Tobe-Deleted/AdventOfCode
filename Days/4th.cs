public class Day4
{
    public int XMAS(string FilePath)
    {
        string[] xmasArray = new string[10];
        var lines = File.ReadAllLines(FilePath);
        int xmasCounter = 0;
        int n = 0;
        foreach(string line in lines)
        {
            xmasArray[n] = line;
            n++;
        }

        for(int i = 0; i < xmasArray.Length; i++)
        {
            for(int j = 0; j < xmasArray[i].Length; j++)
            {
                //Console.WriteLine(j);
                if(j < xmasArray[i].Length -3)
                {
                    if(xmasArray[i].Substring(j, 4) == "XMAS" || xmasArray[i].Substring(j, 4) == "SAMX") //straight
                        xmasCounter++;

                    if (i < xmasArray[i].Length -3) // down
                    {
                        if(xmasArray[i][j] == 'X' &&
                           xmasArray[i+1][j+1] == 'M' &&
                           xmasArray[i+2][j+2] == 'A' &&
                           xmasArray[i+3][j+3] == 'S') // forward diagonal down
                            xmasCounter++;
                        
                        if(xmasArray[i][j] == 'S' &&
                           xmasArray[i+1][j+1] == 'A' &&
                           xmasArray[i+2][j+2] == 'M' &&
                           xmasArray[i+3][j+3] == 'X') // backward diagonal up
                            xmasCounter++;
                        
                        if(xmasArray[i][j] == 'X' &&
                           xmasArray[i+1][j] == 'M' &&
                           xmasArray[i+2][j] == 'A' &&
                           xmasArray[i+3][j] == 'S') // down
                            xmasCounter++;
                        
                    }
                    if (i > 3) //up
                    {
                        if(xmasArray[i][j] == 'X' &&
                           xmasArray[i-1][j+1] == 'M' &&
                           xmasArray[i-2][j+2] == 'A' &&
                           xmasArray[i-3][j+3] == 'S') // forward diagonal up
                            xmasCounter++;

                        if(xmasArray[i][j] == 'S' &&
                           xmasArray[i-1][j+1] == 'A' &&
                           xmasArray[i-2][j+2] == 'M' &&
                           xmasArray[i-3][j+3] == 'X') // Backward diagonal down
                            xmasCounter++;
                        
                        if(xmasArray[i][j] == 'X' &&
                           xmasArray[i-1][j] == 'M' &&
                           xmasArray[i-2][j] == 'A' &&
                           xmasArray[i-3][j] == 'S') // up
                            xmasCounter++;
                    }
                }
            }
            Console.WriteLine($"{i+1} {xmasCounter}");
        }
        return xmasCounter;
    }
}