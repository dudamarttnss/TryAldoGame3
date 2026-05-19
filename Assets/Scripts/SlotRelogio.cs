using UnityEngine;
using UnityEngine.EventSystems;

public class SlotRelogio : MonoBehaviour, IDropHandler
{
    public int valorCorreto;
    public NumeroArrastavel numeroAtual;

    public void OnDrop(PointerEventData eventData)
    {
        NumeroArrastavel numero = eventData.pointerDrag.GetComponent<NumeroArrastavel>();

        if (numero != null)
        { 
            if (numeroAtual != null)
            {
                numeroAtual.DefinirSlot(null);
            }

            
            numeroAtual = numero;
            numero.DefinirSlot(this);

            
            numero.transform.position = transform.position;

           
            FindObjectOfType<RelogioPuzzle>().VerificarTudo();
        }
    }

    public void LimparSlot()
    {
        numeroAtual = null;
    }
}