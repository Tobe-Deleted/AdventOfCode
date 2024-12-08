using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Globalization;

public class Day7
{
    public long CorrectOperators(string filePath)
    {
        DataTable dt = new DataTable();
        long finalSum = 0;
        string[] input = File.ReadAllLines(filePath);
        foreach (string line in input)
        {

            bool validNumber = false;
            long Sum = Convert.ToInt64(line.Substring(0, line.IndexOf(':')));
            string staticEquation = line.Remove(0, line.IndexOf(' '))
                                        .Trim();
            string equation = staticEquation;

            string operators = "";
            for(int i = 0; i < staticEquation.Count(x => x == ' '); i++)
            {
                operators += "+";
            }

            for (int n = 0; n < Math.Pow(2, operators.Length); n++)
            {
                equation = staticEquation;
                for(int i = 0; i < operators.Length; i++)
                {
                    equation = equation.Insert(equation.IndexOf(' '), operators[i].ToString())
                                       .Remove(equation.IndexOf(' ')+1, 1);
                }
   
                string[] numbers = equation.Split('+', '*', '|');
                long tempSum = 0;

                // Console.WriteLine(equation + " | " + Sum);
                for(int i = 0; i < operators.Length; i++)
                {
                    if(i == 0)
                        tempSum += Convert.ToInt64(dt.Compute($"{numbers[i]}{operators[i]}{numbers[i+1]}", ""));
                    else
                    {
                        switch (operators[i])
                        {
                            case '*':
                                tempSum = tempSum * Convert.ToInt64(numbers[i+1]);
                                break;
                            case '+':
                                tempSum = tempSum + Convert.ToInt64(numbers[i+1]);
                                break;
                            case '|':
                                tempSum = Convert.ToInt64(tempSum.ToString() + numbers[i+1]);
                                break;
                        }
                    }
                }

                if(tempSum == Sum)
                {
                    validNumber = true;
                    break;
                }
                else
                {
                    operators = BinaryOperators(operators);
                    if (Math.Pow(operators.Length, 2) == 1)
                    {
                        equation = equation.Replace('+', operators[0]).Replace('*', operators[0]);
                        Console.WriteLine(equation + " | " + Sum);
                        if(Convert.ToInt64(dt.Compute(equation, "")) == Sum)
                        {
                            validNumber = true;
                            break;
                        }
                    }
                }
            }
            Console.WriteLine($"{validNumber} | {Sum}");
            if(validNumber) finalSum += Sum;
        }
        return finalSum;
    }

    public string BinaryOperators(string operators)
    {
        if(operators.Length == 1) return operators == "+" ? "*" : "+";
        operators = operators.Replace('+', '0').Replace('*', '1'); // to binary
        string newOperators = "";
        long stringValue = 0;
        long digitValue = 1;

        for(int i = operators.Length-1; i > -1; i--) // to decimal
        {
            stringValue += digitValue * (Convert.ToInt32(operators[i]) -48);
            digitValue *= 2;
        }

        stringValue += 1;
        for(int i = 0; i < operators.Length; i++) // back to binary
        {
            digitValue /= 2;
            if(stringValue >= digitValue)
            {
                newOperators += '1';
                stringValue -= digitValue;
            }
            else
            {
                newOperators += '0';
            }
        }

        newOperators = newOperators.Replace('0', '+').Replace('1', '*'); // to operators
        return newOperators;
    }
}