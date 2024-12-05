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
        bool activate = true;
        for(int i = 0; i < str.Length -11; i++)
        {
            if(str.Substring(i, 7) == "don't()")
                activate = false;

            if(str.Substring(i, 4) == "do()")
                activate = true;

            if (str.Substring(i, 4) == "mul(" &&
                activate)
            {
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
                    }
                    test = true;
                }
            }
        }
        return mul.Sum();
    }
}