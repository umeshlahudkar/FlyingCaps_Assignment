using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    private Vector2 mousePosition;

    private void Update()
    {
        mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        ClampPosition();
        transform.position = mousePosition;
    }

    private void ClampPosition()
    {
        mousePosition.x = Mathf.Clamp(mousePosition.x, -8.5f, 8.5f);
        mousePosition.y = Mathf.Clamp(mousePosition.y, -4.5f, 4.5f);
    }
}
