using System;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Rendering;

public class RayCaster : MonoBehaviour
{

    LayerMask collisionLayer;
    LayerMask detectorLayer;
    public event Action<string, Color> onGoalDetected;
    public event Action<string> onGoalNotDetected;

    void Start()
    {
        collisionLayer = 1 << LayerMask.NameToLayer("Blocker");
        detectorLayer = 1 << LayerMask.NameToLayer("Detector");
    }

    // See Order of Execution for Event Functions for information on FixedUpdate() and Update() related to physics queries
    void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1000, collisionLayer);
        // Does the ray intersect any objects excluding the player layer
        var beamLength = transform.TransformDirection(Vector2.right);
        if (hit)
        {
            beamLength *= hit.distance;
            transform.GetChild(0).transform.localScale = new Vector2(hit.distance / 4, hit.distance);
        }
        else
        {
            beamLength *= 100;
            transform.GetChild(0).transform.localScale = new Vector2(1, 20);
        }
        Debug.DrawRay(transform.position, beamLength, Color.yellow);

        RaycastHit2D goalHit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.right), 1000, detectorLayer);
        if (goalHit && goalHit.collider.tag == "Detector")
        {
            onGoalDetected?.Invoke(transform.name, transform.GetChild(0).transform.GetChild(0).transform.GetComponent<SpriteRenderer>().color);
        }
        else
        {
            onGoalNotDetected?.Invoke(transform.name);
        }
    }
}
