using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

    public Transform followed;
    private Vector3 offset;
    

    // Use this for initialization
    void Start () {
        offset = transform.position - followed.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void LateUpdate()
    {
        transform.position = followed.transform.position + offset;
    }
}
