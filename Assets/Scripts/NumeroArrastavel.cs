using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class NumeroArrastavel : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int valor;
    public TextMeshProUGUI texto;

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private SlotRelogio slotAtual;

    void Start()
    {
        texto.text = valor.ToString();
        canvas = GetComponentInParent<Canvas>();
        canvasGroup = GetComponent<CanvasGroup>();

        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetAsLastSibling();
        transform.localScale = Vector3.one * 1.1f;

        canvasGroup.blocksRaycasts = false;

        // 🔥 Sai do slot
        if (slotAtual != null)
        {
            slotAtual.LimparSlot();
            slotAtual = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        //transform.position += (Vector3)eventData.delta / canvas.scaleFactor;

        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
        canvasGroup.blocksRaycasts = true;
    }

    public void DefinirSlot(SlotRelogio slot)
    {
        slotAtual = slot;
    }
}