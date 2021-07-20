using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameObject Player;
    public int Speed;
    public int SpeedRot;
    public GameObject Block;
    void Start()
    {
        Player = (GameObject)this.gameObject;   
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        float mouseX = Input.GetAxis("Mouse X") * SpeedRot * Time.deltaTime;
        Player.transform.Rotate(Vector3.up * mouseX);

        RaycastHit hit;
        Ray ray = new Ray(transform.position + (transform.forward * 3), Vector3.down);
        if(Physics.Raycast(ray, out hit))
        {
            var pos = new Vector3(Mathf.Round(hit.point.x / 2f) * 2f, hit.point.y + 1, Mathf.Round(hit.point.z / 2f) * 2f);
            if(Input.GetMouseButtonDown(1))
            {
                Instantiate(Block, pos, Quaternion.identity);
            }
        }

        if(Input.GetKey(KeyCode.W))
        {
            Player.transform.position += Player.transform.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Player.transform.position -= Player.transform.forward * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Player.transform.position += Player.transform.right * Time.deltaTime * Speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Player.transform.position -= Player.transform.right * Time.deltaTime * Speed;
        }
    }
}
