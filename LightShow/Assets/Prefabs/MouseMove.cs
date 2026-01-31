// Source - https://stackoverflow.com/a/38407823
// Posted by Ghasem, modified by community. See post 'Timeline' for change history
// Retrieved 2026-01-31, License - CC BY-SA 4.0

using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]

public class MouseMove : MonoBehaviour {
    [SerializeField] private bool isDragging = false;
    [SerializeField] private float maxUp, maxDown = 0.0f;
    private float maxY, minY;
    private Vector3 spawnPos;

    void Start()
    {
        spawnPos = transform.position;
        maxY = spawnPos.y + maxUp;
        minY = spawnPos.y - maxDown;
    }

    void Update()
    {
        if(isDragging)
        {
            float mouseY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y;
            float newY = transform.position.y;
            if (mouseY <= maxY && mouseY >= minY)
            {
                newY = mouseY;
            }
            else if (mouseY > maxY)
            {
                newY = maxY;
            }
            else if (mouseY < minY)
            {
                newY = minY;
            }
            Vector3 newPos = new Vector3(transform.position.x, newY, transform.position.z);
            transform.position = newPos;
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseUp()
    {   
		isDragging = false;
    }
}
