using UnityEngine;

public class LimiteTela : MonoBehaviour
{
    private Vector2 minLimite;
    private Vector2 maxLimite;

    void Start()
    {
        Camera cam = Camera.main;

        // canto inferior esquerdo
        minLimite = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));

        // canto superior direito
        maxLimite = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));
    }

    void LateUpdate()
    {
        Vector3 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, minLimite.x, maxLimite.x);
        pos.y = Mathf.Clamp(pos.y, minLimite.y, maxLimite.y);

        transform.position = pos;
    }
}