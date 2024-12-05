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
            if(str[i] == 'd' &&
               str[i+1] == 'o' &&
               str[i+2] == 'n' &&
               str[i+3] == '\'' &&
               str[i+4] == 't' &&
               str[i+5] == '(' &&
               str[i+6] == ')')
                activate = false;

            if(str[i] == 'd' &&
               str[i+1] == 'o' &&
               str[i+2] == '(' &&
               str[i+3] == ')')
                activate = true;

            if (str[i] == 'm' && 
                str[i+1] == 'u' &&
                str[i+2] == 'l' &&
                str[i+3] == '(' &&
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