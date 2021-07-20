using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject Cube;
    public Transform Player;
    public int Speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            GameObject Sphere = Instantiate(Cube, Player.position, Quaternion.identity);
            Sphere.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * Speed;
        }
    }
}
