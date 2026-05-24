using UnityEngine;

public class CorArrastavel : MonoBehaviour
{
    [Header("Cor do Objeto")]
    public string cor;

    private Vector3 offset;
    private Camera cam;

    private SlotCor slotAtual;

    void Start()
    {
        cam = Camera.main;
    }

    void OnMouseDown()
    {
        offset = transform.position - PegarMouseWorld();
    }

    void OnMouseDrag()
    {
        transform.position = PegarMouseWorld() + offset;
    }

    void OnMouseUp()
    {
        // Quando soltar, encaixa no centro
        if (slotAtual != null)
        {
            transform.position = slotAtual.transform.position;

            slotAtual.VerificarCor();
        }
    }

    Vector3 PegarMouseWorld()
    {
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = 10f;

        return cam.ScreenToWorldPoint(mousePos);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        SlotCor slot = collision.GetComponent<SlotCor>();

        if (slot != null)
        {
            slotAtual = slot;
            slot.imagemAtual = this;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        SlotCor slot = collision.GetComponent<SlotCor>();

        if (slot != null && slotAtual == slot)
        {
            slot.imagemAtual = null;
            slotAtual = null;
        }
    }
}