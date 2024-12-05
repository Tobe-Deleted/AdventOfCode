public class Day4
{
    public int XMAS(string FilePath)
    {
        string[] xmasArray = new string[140];
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
                if(xmasArray[i][j] == 'A' && j > 0 && j < xmasArray.Length -1 && i > 0 && i < xmasArray.Length -1)
                {
                    string xCheck1 = $"{xmasArray[i+1][j+1]}{xmasArray[i-1][j-1]}" ;
                    string xCheck2 = $"{xmasArray[i-1][j+1]}{xmasArray[i+1][j-1]}" ;

                    if (xCheck1 == "SM" || xCheck1 == "MS")
                        if (xCheck2 == "SM" || xCheck2 == "MS")
                        {
                            Console.WriteLine($"{i}|{j}");
                            xmasCounter++;
                        }

                }
                // if(j < xmasArray[i].Length -3) //Part 1
                // {
                //     if(xmasArray[i].Substring(j, 4) == "XMAS" || xmasArray[i].Substring(j, 4) == "SAMX") //straight
                //         xmasCounter++;

                //     if (i < xmasArray[i].Length -3) // top right to bottom left
                //     {
                //         if(xmasArray[i][j] == 'X' &&
                //            xmasArray[i+1][j+1] == 'M' &&
                //            xmasArray[i+2][j+2] == 'A' &&
                //            xmasArray[i+3][j+3] == 'S') // bottom right
                //             xmasCounter++;
                        
                //         if(xmasArray[i][j] == 'S' &&
                //            xmasArray[i+1][j+1] == 'A' &&
                //            xmasArray[i+2][j+2] == 'M' &&
                //            xmasArray[i+3][j+3] == 'X')  //top left
                //             xmasCounter++;
                //     }

                //     if (i > 2) //bottom left to upper right
                //     {
                //         if(xmasArray[i][j] == 'X' &&
                //            xmasArray[i-1][j+1] == 'M' &&
                //            xmasArray[i-2][j+2] == 'A' &&
                //            xmasArray[i-3][j+3] == 'S') //top right
                //             xmasCounter++;

                //         if(xmasArray[i][j] == 'S' &&
                //            xmasArray[i-1][j+1] == 'A' &&
                //            xmasArray[i-2][j+2] == 'M' &&
                //            xmasArray[i-3][j+3] == 'X') //bottom left
                //             xmasCounter++;
                        
                //     }
                // }
                // if(i < xmasArray.Length - 3)
                // {
                //     if(xmasArray[i][j] == 'X' &&
                //        xmasArray[i+1][j] == 'M' &&
                //        xmasArray[i+2][j] == 'A' &&
                //        xmasArray[i+3][j] == 'S')
                //         xmasCounter++;

                //     if(xmasArray[i][j] == 'S' &&
                //        xmasArray[i+1][j] == 'A' &&
                //        xmasArray[i+2][j] == 'M' &&
                //        xmasArray[i+3][j] == 'X')
                //         xmasCounter++;
                // }
            }
        }
        return xmasCounter;
    }
}