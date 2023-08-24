using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGenerator : MonoBehaviour
{
    public string code = default; 

    public string firstNumber;
    public string secondNumber;
    public string thirdNumber;

    public string code1;
    public string code2;
    public string code3;

    private void Start() {
        firstNumber = GenerateNumber(10, 19);
        secondNumber = GenerateNumber(20, 29);
        thirdNumber = GenerateNumber(30, 39);

        code1 = RemoveFirstDigit(firstNumber);
        code2 = RemoveFirstDigit(secondNumber);
        code3 = RemoveFirstDigit(thirdNumber);

        code = code1 + code2 + code3;
        print(code);
    }

    public string GenerateNumber(int minimumInt, int maximumInt) {
        var number = Random.Range(minimumInt, maximumInt + 1);
        return number.ToString();
    }

    public string RemoveFirstDigit(string s) {
        char[] charArray = s.ToCharArray();
        List<char> charList = new List<char>(charArray);
        charList.RemoveAt(0);
        charArray = charList.ToArray();
        return charArray[0].ToString();
    }
}
