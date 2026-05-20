using UnityEngine;

public class DragMouse : MonoBehaviour
{
    private Camera cam;
    private Vector3 offset;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        offset = transform.position - MouseWorldPosition();
    }

    void OnMouseDrag()
    {
        transform.position = MouseWorldPosition() + offset;
    }

    Vector3 MouseWorldPosition()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;

        return cam.ScreenToWorldPoint(mousePos);
    }
}