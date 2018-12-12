using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MailBoxPlaySound : MonoBehaviour {
    bool open = true;
    public AudioSource mailBoxSound;

    private void Start()
    {
        //open = this.gameObject.GetComponent<Target>().open;
        mailBoxSound = this.gameObject.GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "projectile" && open == true)
        {
            mailBoxSound.Play();
        }
    }
}
