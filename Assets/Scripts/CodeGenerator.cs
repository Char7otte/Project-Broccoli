using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodeGenerator : MonoBehaviour
{
    [SerializeField]private string code = default; 

    private void Start() {
        var firstNumber = GenerateNumber(10, 19);
        var secondNumber = GenerateNumber(20, 29);
        var thirdNumber = GenerateNumber(30, 39);

        firstNumber = RemoveFirstDigit(firstNumber);
        secondNumber = RemoveFirstDigit(secondNumber);
        thirdNumber = RemoveFirstDigit(thirdNumber);

        code = firstNumber + secondNumber + thirdNumber;
        print(code);
    }

    public void ReadStringInput(string stringInput) {
        if (stringInput == code.ToString()) {
            print("Code is correct.");
        }
        else {
            print("Code is incorrect.");
        }
    }

    private string GenerateNumber(int minimumInt, int maximumInt) {
        var number = Random.Range(minimumInt, maximumInt + 1);
        print(number);
        return number.ToString();
    }

    private string RemoveFirstDigit(string s) {
        char[] charArray = s.ToCharArray();
        List<char> charList = new List<char>(charArray);
        charList.RemoveAt(0);
        charArray = charList.ToArray();
        return charArray[0].ToString();
    }
}
