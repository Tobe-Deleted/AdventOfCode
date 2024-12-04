using System.ComponentModel.DataAnnotations;
using System.Data;
public class Day3
{
    public int Mul(string str)
    {
        DataTable dt = new DataTable();
        List<int> mul = new List<int>();
        bool test = true;
        string temp;
        // Console.WriteLine(str.Substring(8964, 50));
        // Console.ReadKey();
        for(int i = 0; i < str.Length -11; i++)
        {
            if (str[i] == 'm' && 
                str[i+1] == 'u' &&
                str[i+2] == 'l' &&
                str[i+3] == '(')
            {
                // Console.WriteLine($"{i}, {str.Length}, {mul.Count()}");
                temp = str.Substring(i+4, 8);
                if (temp.Contains(')') && temp.Contains(','))
                {
                    temp = temp.Remove(temp.IndexOf(')')).Replace(',', '*');
                    foreach (char c in temp)
                    {
                        if (!"1234567890*".Contains(c))
                        {
                            test = false;
                            break;
                        }
                    }

                    if (test)
                    {
                        mul.Add(Convert.ToInt32(dt.Compute(temp, "")));
                        Console.WriteLine(temp);
                    }
                    test = true;
                }
            }
        }
        // foreach (int i in mul) Console.WriteLine(i);
        return mul.Sum();
    }
}