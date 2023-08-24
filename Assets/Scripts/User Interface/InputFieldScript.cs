using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFieldScript : MonoBehaviour
{
    [SerializeField]private CodeGenerator codeGenerator = default;

    private void OnEnable() {
        GameManager.Instance.playerCanShoot = false;
        Time.timeScale = 0;
    }

    private void OnDisable() {
        GameManager.Instance.playerCanShoot = true;
        Time.timeScale = 1.0f;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Escape)) {
            var parent = this.transform.parent;
            parent.gameObject.SetActive(false);
        }

        //I don't know why, but it needs to be constantly applied to work.
        Cursor.visible = true;
		Cursor.lockState = CursorLockMode.Confined;
        
    }

    public void ReadStringInput(string stringInput) {
        var code = codeGenerator.code;
        if (stringInput == code.ToString()) {
            print("Code is correct.");
        }
        else {
            print("Code is incorrect.");
        }
    }

    public void OnExit() {
        var parent = this.transform.parent;
        parent.gameObject.SetActive(false);
    }
}
