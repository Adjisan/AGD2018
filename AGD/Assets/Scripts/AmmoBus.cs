using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBus : MonoBehaviour
{
    public bool open = true;
    public int force = 10;
    public int forceRight = 10;
    public int forceDiagonal = 10;
    public int forceThirdPhase = 20;
    public float targetTime = 5.0f;
    public float firstTimer = 5.0f, secondTimer = 5.0f, thirdTimer = 5.0f;
    public int phase = 0;

    public Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        targetTime = firstTimer;
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
            phase += 1;
            switch (phase)
            {
                case 0:
                    Debug.Log("first phase");
                    targetTime = firstTimer;
                    break;
                case 1:
                    Debug.Log("second phase");
                    targetTime = secondTimer;
                    break;
                case 2:
                    Debug.Log("third phase");
                    targetTime = thirdTimer;
                    break;
            }
            
            if (phase == 0 || phase == 2)
            {
                forceRight = 0;
            }
            if (phase == 1)
            {
                forceRight = forceDiagonal;
            }
            if(phase == 2)
            {
                force = forceThirdPhase;
            }
            if (phase > 2)
            {
                Debug.Log("Destroy the AmmoBus");
                phase = 0;
            }
        }
    }
}
