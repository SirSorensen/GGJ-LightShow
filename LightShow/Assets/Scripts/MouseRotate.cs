using UnityEngine;

[RequireComponent(typeof(Collider2D))]

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
