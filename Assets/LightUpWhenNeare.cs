using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightUpWhenNeare : MonoBehaviour
{
    public Light Light;
    public Transform Player;
    public float MinimumLightDistance;
    private Transform _door;
    private float _startLightIndensity;

	// Use this for initialization
	void Start ()
	{
	    _door = gameObject.GetComponent<Transform>();
	    _startLightIndensity = Light.intensity;
	}
	
	// Update is called once per frame
	void Update ()
    {
        float distance = Vector3.Distance(Player.position, _door.position);
        if (distance < MinimumLightDistance)
        {
            float percentDistance =  distance / MinimumLightDistance;
            Light.intensity = (1f - percentDistance) * _startLightIndensity;
        }
        else
        {
            Light.intensity = 0;
        }
	}
}
