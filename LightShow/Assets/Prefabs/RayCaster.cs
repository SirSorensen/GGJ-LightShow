using System;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;

public class RayCaster : MonoBehaviour
{

	LayerMask layerMask;

    void Start()
	{
		layerMask = 1 << LayerMask.NameToLayer("Blocker");
	}

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1000, layerMask);
        // Does the ray intersect any objects excluding the player layer
		var beamLength = transform.TransformDirection(Vector2.right);
        if (hit)
        {
			beamLength *= hit.distance;
			transform.GetChild(0).transform.localScale = new Vector2(1, hit.distance);
        }
        else
        {
            beamLength *= 100;
			transform.GetChild(0).transform.localScale = new Vector2(1, 20);
        }
		Debug.DrawRay(transform.position, beamLength, Color.yellow);
    }
}
