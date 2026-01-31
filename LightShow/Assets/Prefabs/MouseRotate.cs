using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class MouseRotate : MonoBehaviour
{
	private bool isDragging = false;

	void Update()
    {
        if(isDragging)
		{

			Vector2 mousePos = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
			Vector2 unitVector = new Vector2(1, 0);

			var angle = Vector2.SignedAngle(unitVector, mousePos);

			Debug.Log("Rotating " + angle + " degrees");
			Debug.Log("mouse x = " + Input.mousePosition.x + " ?= " + mousePos.x);
			Debug.Log("mouse y = " + Input.mousePosition.y + " ?= " + mousePos.y);

			transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, angle);
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
