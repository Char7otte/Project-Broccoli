using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour
{
    [Tooltip("Reference to the player game object")]
    public GameObject player;

    [Tooltip("Offset distance between the player and camera")]
    public Vector3 offset;        

    // Use this for initialization
    void Start()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        if (player == null)
            return;

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;
    }
}
