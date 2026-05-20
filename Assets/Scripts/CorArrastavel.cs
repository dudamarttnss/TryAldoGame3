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
            // Remove do slot antigo
            if (slotAtual != null)
            {
                slotAtual.imagemAtual = null;
            }

            // Define novo slot
            slotAtual = slot;
            slot.imagemAtual = this;

            // Encaixa no centro
            transform.position = slot.transform.position;

            // Verifica
            slot.VerificarCor();
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