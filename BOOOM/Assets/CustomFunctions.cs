using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFunctions : MonoBehaviour
{
    // Start is called before the first frame update
    public static CustomFunctions Instance;
    void Awake()
    {
        Instance = this;
    }


}
