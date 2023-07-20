using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Highlighter : MonoBehaviour
{
    private Transform highlight;
    private Transform selection;
    private RaycastHit raycastHit;
    private int interactableLayerInt;

    [SerializeField]private GameObject interactPopUp;

    private void Start() {
        interactableLayerInt = LayerMask.NameToLayer("Interactable");
    }

    private void Update()
    {
        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
            DisableInteractPopUp();
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out raycastHit)) //Make sure you have EventSystem in the hierarchy before using EventSystem
        {
            highlight = raycastHit.transform;
            if (highlight.transform.gameObject.layer == interactableLayerInt && highlight != selection)
            {
                if (highlight.gameObject.GetComponent<Outline>() == null) {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                } 
                highlight.gameObject.GetComponent<Outline>().enabled = true;

                EnableInteractPopUp();
            }
            else
            {
                highlight = null;
            }
        }
    }

    private void EnableInteractPopUp() {
        interactPopUp.SetActive(true);
    }

    private void DisableInteractPopUp() {
        interactPopUp.SetActive(false);
    }
}
