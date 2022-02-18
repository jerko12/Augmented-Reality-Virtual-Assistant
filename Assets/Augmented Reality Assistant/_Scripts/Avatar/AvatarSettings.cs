using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Avatar Settings", menuName = "Avatar/Settings", order = 1)]
public class AvatarSettings : ScriptableObject
{
    public string avatarName = "";
    public GameObject characterPrefab;
    
    [Header("Movement")]// NOT YET IMPLEMENTED
    public bool canMove = true;
    public bool lookAtCamera = true;
}
