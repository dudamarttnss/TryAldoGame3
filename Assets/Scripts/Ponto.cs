using UnityEngine;

public class Ponto : MonoBehaviour
{
    public string cor;

    void OnMouseOver()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (Fio.fioAtual != null)
            {
                Fio.fioAtual.Conectar(cor);
                Fio.fioAtual = null;
            }
        }
    }
}