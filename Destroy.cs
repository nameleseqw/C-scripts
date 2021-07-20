using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public int Count;

    void Start()
    {
        Destroy((GameObject)this.gameObject, Count);
    }
}
