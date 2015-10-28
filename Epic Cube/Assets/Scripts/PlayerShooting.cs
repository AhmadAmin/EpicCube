using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public ParticleSystem muzzleFlash;
    Animator anim;
    bool shooting = false;
	// Use this for initialization
	void Start () {
        anim = GetComponentInChildren<Animator>();
        //for (int i = 0; i < 100; i++)
        //    Instantiate(GameObject.Find("DefaultAvatar"));
    }
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetButtonDown("Fire1"))
        {
            anim.SetBool("Fire", true);
            anim.SetTrigger("Fire Trigger");
            shooting = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            shooting = false;
            anim.SetBool("Fire", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Run", true);
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Run", false);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            anim.SetTrigger("Reload");
        }
    }

    void FixedUpdate()
    {
        if(shooting)
        {
            muzzleFlash.Play();           
        }
    }
}
