
using UnityEngine;

public class Fio : MonoBehaviour
{    
    public string corFio;
    public bool conectado = false;
    public static Fio fioAtual;

    private Vector3 posInicial;
    private bool arrastando = false;

    void Start()
    {
        posInicial = transform.position;
    }

    void OnMouseDown()
    {
        fioAtual = this;
        arrastando = true; 
    }

    void OnMouseUp()
    {
        arrastando = false;

        if(!conectado)
        {
            transform.position = posInicial;
        }
    }

    void Update()
    {
        if(arrastando && !conectado)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
    }

    public void Conectar(string pontoCor)
    {
        if(pontoCor == corFio)
        {
            conectado = true;
            Debug.Log("Conectado corretamente");

            arrastando = false;
        }

        else
        {
            Debug.Log("Errado");
            transform.position = posInicial;
        }
    }
}
