using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruct : MonoBehaviour
{
    public GameObject mesh;
    private float Widght;
    private float Height;
    private float Depth;
    public float cubeSize;
    public Transform Target;
    public bool LetDelete = false;

    void Start()
    {
        Widght = transform.localScale.z;
        Height = transform.localScale.y;
        Depth = transform.localScale.x;

        
        mesh.GetComponent<Transform>().localScale = new Vector3(cubeSize, cubeSize, cubeSize);
    }
    void OnCollisionEnter(UnityEngine.Collision col)
    {
        if(col.gameObject.CompareTag("Projecttile"))
        {
            CreateCube();
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    public void CreateCube()
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        for(float x = 0; x < Widght; x += cubeSize)
        {
            for(float y = 0; y < Height; y += cubeSize)
            {
                for(float z = 0; z < Depth; z += cubeSize)
                {
                    Vector3 vec = Target.position;

                    Instantiate(mesh, vec + new Vector3(x, y, z), Quaternion.identity);
                }
            }
        }
    }
}
