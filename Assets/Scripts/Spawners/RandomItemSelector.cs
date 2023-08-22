using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemSelector : MonoBehaviour
{
    [Header("Pick ups")]
    [SerializeField]private GameObject[] items = default;

    private void Start() {
        var selectedItem = SelectRandomItem(AddUpWeightOfItems());
        if (!selectedItem) return;

        var spawnItemScript = GetComponent<SpawnItemScript>();
        spawnItemScript.SpawnItem(selectedItem, transform);
    }

    private int AddUpWeightOfItems() {
        var _totalWeight = 0;
        foreach (var item in items) {
            _totalWeight += item.GetComponent<ItemWeightValue>().weightValue;
        }
        return _totalWeight;
    }

    private GameObject SelectRandomItem(int _totalWeight) {
        var chosenWeight = Random.Range(1, _totalWeight);
        var weightSum = 0;

        foreach(var item in items) {
            weightSum += item.GetComponent<ItemWeightValue>().weightValue;
            if (chosenWeight <= weightSum) {
                return item;
            }
        }
        
        print("Selecting random item broke somewhere.");
        return null;
    }
}
