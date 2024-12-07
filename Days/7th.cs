public class Day7
{
    public int CorrectOperators(string filePath)
    {
        int finalSum = 0;
        string[] input = File.ReadAllLines(filePath);
        foreach (string equationString in input)
        {
            int Sum = Convert.ToInt32(equationString.Substring(0, equationString.IndexOf(':')));
            string[] temp = equationString.Remove(0, equationString.IndexOf(' '))
                                          .Trim()
                                          .Split(' ');
            int[] numbers = new int[temp.Length];
            for(int i = 0; 0 < temp.Length; i++)
            {
                numbers[i] = Convert.ToInt32(temp[i]);
            }
        }
        return finalSum;
    }
}