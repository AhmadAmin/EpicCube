using UnityEngine;
using System.Collections;
using System;

public class RayCast : MonoBehaviour {

    public GameObject impactPrefab;
    GameObject[] impacts;
    int currentImpact = 0;
    int maxImpacts = 5;
    bool shooting = false;
    // Use this for initialization
    void Start()
    {
        impacts = new GameObject[maxImpacts];
        for (int i = 0; i < maxImpacts; i++)
        {
            impacts[i] = Instantiate(impactPrefab);
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if (Input.GetButtonDown("Fire1"))
        {
            shooting = true;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            shooting = false;
        }
    }


    void FixedUpdate()
    {
        if (shooting)
        {
            StartCoroutine(CheckShot());
        }
    }

    
    IEnumerator CheckShot()
    {
        for (int i = 0; i < maxImpacts; i++)
        {
            impacts[i] = Instantiate(impactPrefab);
        }

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 50f))
        {
            if (hit.transform.tag == "Enemy")
            {
                hit.transform.gameObject.GetComponent<Animator>().SetTrigger("Shot");
                yield return new WaitForSeconds(0.5f);
                Destroy(hit.transform.gameObject);
            }
            impacts[currentImpact].transform.position = hit.point;
            impacts[currentImpact].GetComponent<ParticleSystem>().Play();
        }

        if (++currentImpact >= maxImpacts)
            currentImpact = 0;
    }
}
