using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldHud : MonoBehaviour
{
    [SerializeField]private CodeGenerator codeGenerator = default;

    private void OnEnable() {
        
    }

    private void OnDisable() {

    } 

    public void ReadStringInput() {

    }

    public void OnExit() {
        this.gameObject.SetActive(false);
    }
}
