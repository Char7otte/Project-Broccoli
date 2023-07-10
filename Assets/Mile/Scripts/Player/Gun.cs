using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunType { machine_gun, shotgun}
    public GunType gunType;

    public string gunName;
    public GameObject gun;
}
