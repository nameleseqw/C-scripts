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



public class Collision : MonoBehaviour
{
    private Collider[] hitColliders;

    public float Radius;
    public float explosionForce;
    public LayerMask ExplosionObj;

    private void OnCollisionEnter(UnityEngine.Collision col)
    {
        if(col.gameObject.transform.root.CompareTag("box"))
        {
            destroy(col.contacts[0].point);
        }
    }
    public void destroy(Vector3 target)
    {
        hitColliders = Physics.OverlapSphere(target, Radius, ExplosionObj);

        foreach(Collider hitcol in hitColliders)
        {
            if(hitcol.GetComponent<Rigidbody>() == null)
            {
                hitcol.GetComponent<MeshRenderer>().enabled = true;
                hitcol.gameObject.AddComponent<Rigidbody>();

                hitcol.GetComponent<Rigidbody>().mass = 500;
                hitcol.GetComponent<Rigidbody>().isKinematic = false;
                hitcol.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, target, Radius, 1, ForceMode.Impulse);
                hitcol.GetComponent<Destroy>().enabled = true;
                
            }
        }
    }
    
}




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





public class Destroy : MonoBehaviour
{
    public int Count;

    void Start()
    {
        Destroy((GameObject)this.gameObject, Count);
    }
}




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
