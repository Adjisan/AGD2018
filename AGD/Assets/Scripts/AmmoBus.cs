using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBus : MonoBehaviour
{
    public bool open = true;
    public int force = 10;
    public int forceRight = 10;
    public float targetTime = 5.0f;
    public Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "projectile" && open)
        {
            Debug.Log("Gained Ammo");
            open = false;
            Destroy(collision.gameObject);
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(transform.position + (forceRight * transform.right + force * transform.forward) * Time.deltaTime);
    }

    void Update()
    {

        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            // do stuff
			if(forceRight == 0)
			{
				forceRight = force;
			} else
			{
				forceRight = 0;
			}
            	
			targetTime = 5.0f;
        }

    }
}
