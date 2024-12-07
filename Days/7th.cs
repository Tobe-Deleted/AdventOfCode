using System.Security.Cryptography.X509Certificates;
using System.Data;

public class Day7
{
    public int CorrectOperators(string filePath)
    {
        DataTable dt = new DataTable();
        int finalSum = 0;
        string[] input = File.ReadAllLines(filePath);
        foreach (string line in input)
        {
            int Sum = Convert.ToInt32(line.Substring(0, line.IndexOf(':')));
            string staticEquation = line.Remove(0, line.IndexOf(' '))
                                       .Trim();
            string equation = staticEquation;
            bool validNumber = false; string o1 = "*"; string o2 = "+";
            for(int i = 0; i < staticEquation.Count(x => x == ' '); i++)
            {
                (o1, o2) = (o2, o1);
                for (int n = 0; n < staticEquation.Count(x => x == ' '); n++)
                {
                    if(equation.Contains(' '))
                    {
                        equation = equation.Replace(' ', '+');
                    }
                    else
                    {
                        equation = equation.Remove(equation.IndexOf(o2), 1)
                                           .Insert(equation.IndexOf(o2), o1);
                        
                    }
                    
                    if(Convert.ToInt32(dt.Compute(equation, "")) == Sum)
                    {    
                        validNumber = true;
                        break;
                    }
                }
            }

            

        }
        return finalSum;
    }
}