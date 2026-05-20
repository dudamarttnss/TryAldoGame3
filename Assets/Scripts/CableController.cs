using UnityEngine;

public class CableController : MonoBehaviour
{
    public Transform pontaFixa;
    public Transform pontaCobre;

    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 2;
    }

    void Update()
    {
        lr.SetPosition(0, pontaFixa.position);
        lr.SetPosition(1, pontaCobre.position);
    }
}