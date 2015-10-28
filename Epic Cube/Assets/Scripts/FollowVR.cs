using UnityEngine;
using System.Collections;

public class FollowVR : MonoBehaviour {

    public Transform vrTransform;
	// Use this for initialization
	void Start () {
        transform.rotation = vrTransform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
        transform.rotation = vrTransform.rotation;
    }
}
