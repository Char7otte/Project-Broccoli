using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CodePlacer : MonoBehaviour
{
    private GameObject[] codeSpawnPoints;
    [SerializeField]private CodeGenerator codeGenerator = default;

    private void Start() {
        codeSpawnPoints = GameObject.FindGameObjectsWithTag("Code Point");

        foreach (var codeSpawnPoint in codeSpawnPoints) {
            codeSpawnPoint.GetComponent<TextMeshProUGUI>().text = "";
        }

        Invoke("method", 1);
    }

    private void method() {
        PlaceCode(codeGenerator.firstNumber);
        PlaceCode(codeGenerator.secondNumber);
        PlaceCode(codeGenerator.thirdNumber);
    }

    private void PlaceCode(string codeNumber) {
        var randomElement = Random.Range(0, codeSpawnPoints.Length);
        codeSpawnPoints[randomElement].GetComponent<TextMeshProUGUI>().SetText(codeNumber);
        codeSpawnPoints = RemoveElementFromArray(codeSpawnPoints[randomElement]);
    }

    private GameObject[] RemoveElementFromArray(GameObject elementToRemove) {
        GameObject[] newArray = new GameObject[codeSpawnPoints.Length - 1];

        int newArrayIndex = 0;
        for (int i = 0; i < codeSpawnPoints.Length; i++) {
            if (codeSpawnPoints[i] != elementToRemove) {
                newArray[newArrayIndex] = codeSpawnPoints[i];
                newArrayIndex++;
            }
        }

        return newArray;
    }
}
