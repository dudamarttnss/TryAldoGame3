using UnityEngine;

public class SlotCor : MonoBehaviour
{
    [Header("Cor do Slot")]
    public string cor;

    [Header("Objeto Atual")]
    public CorArrastavel imagemAtual;

    public bool VerificarCor()
    {
        if (imagemAtual == null)
            return false;

        bool correto = imagemAtual.cor == cor;

        Debug.Log("Cor correta? " + correto);

        return correto;
    }
}