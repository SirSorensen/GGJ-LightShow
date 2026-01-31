// Source - https://stackoverflow.com/a/38407823
// Posted by Ghasem, modified by community. See post 'Timeline' for change history
// Retrieved 2026-01-31, License - CC BY-SA 4.0

using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class MouseDrag : MonoBehaviour {
    [SerializeField] private bool isDragging = false;

    void Update()
    {
        if(isDragging)
        {
            transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void OnMouseDown()
    {
        isDragging = true;
    }

    void OnMouseDrag()
    {   
		Debug.Log("Mouse Drag");
    }

    void OnMouseUp()
    {   
		isDragging = false;
    }
}
