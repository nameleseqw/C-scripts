using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
