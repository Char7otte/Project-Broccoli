using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideModel : MonoBehaviour
{
    private void Start() {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
