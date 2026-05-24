using UnityEngine;

public class SlotCor : MonoBehaviour
{
    [Header("Cor do Slot")]
    public string cor;

    [Header("Objeto Atual")]
    public CorArrastavel imagemAtual;

    [Header("Indicador")]
    public SpriteRenderer indicador;

    public bool VerificarCor()
    {
        if (imagemAtual == null)
            return false;

        bool correto = imagemAtual.cor == cor;

        Debug.Log("Cor correta? " + correto);

        // Se estiver correto fica amarelo
        if (correto)
        {
            indicador.color = Color.yellow;
        }
        else
        {
            indicador.color = Color.white;
        }

        return correto;
    }
}