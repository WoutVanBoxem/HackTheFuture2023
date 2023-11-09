using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class MayanNumeralsConverter
{
    public int MayanToDecimal(string mayanNumber)
    {
        int decimalValue = 0;
        int placeValueMultiplier = 1;
        string[] mayanDigits = mayanNumber.Trim().Split(' ').Reverse().ToArray();

        foreach (string digit in mayanDigits)
        {
            int digitValue = 0;
            foreach (char symbol in digit)
            {
                if (symbol == '·') digitValue += 1;
                else if (symbol == '|') digitValue += 5;
            }
            decimalValue += digitValue * placeValueMultiplier;
            placeValueMultiplier *= 20;
        }

        return decimalValue;
    }

    public string DecimalToMayan(int decimalNumber)
    {
        if (decimalNumber == 0) return "2"; 

        var mayanNumberBuilder = new StringBuilder();
        while (decimalNumber > 0)
        {
            int remainder = decimalNumber % 20;
            decimalNumber /= 20;
            mayanNumberBuilder.Insert(0, " " + ConvertDigitToMayan(remainder));
        }

        return mayanNumberBuilder.ToString().Trim();
    }

    private string ConvertDigitToMayan(int digit)
    {
        if (digit == 0) return "2";

        string mayanDigit = new string('·', digit % 5) + new string('|', digit / 5);
        return string.Concat(mayanDigit.Reverse()).Trim();
    }
    public string SumMayanNumbers(IEnumerable<string> mayanNumbers)
    {
        int sum = mayanNumbers.Select(MayanToDecimal).Sum();
        return DecimalToMayan(sum);
    }
}
