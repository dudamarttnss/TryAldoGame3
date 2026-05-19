using UnityEngine;

public class RelogioPuzzle : MonoBehaviour
{
    public SlotRelogio[] slots;

    public GameObject uiErro;

    public Transform ponteiro;
    public float velocidade = 100f;

    public ControladorCanvas canvasController;

    private bool ativo = false;

    void Start()
    {
        // 🔥 Segurança: pega automaticamente se não tiver ligado no Inspector
        if (canvasController == null)
        {
            canvasController = FindObjectOfType<ControladorCanvas>();
        }
    }

    void Update()
    {
        if (ativo)
        {
            ponteiro.Rotate(Vector3.forward * velocidade * Time.deltaTime);
        }
    }

    public void VerificarTudo()
    {
        bool todosPreenchidos = true;
        bool tudoCorreto = true;

        foreach (var slot in slots)
        {
            if (slot.numeroAtual == null)
            {
                todosPreenchidos = false;
            }
            else if (slot.numeroAtual.valor != slot.valorCorreto)
            {
                tudoCorreto = false;
            }
        }

        // 🔥 Só verifica resultado quando todos estiverem preenchidos
        if (todosPreenchidos)
        {
            if (tudoCorreto)
            {
                AtivarRelogio();
            }
            else
            {
                MostrarErro();
            }
        }
    }

    void AtivarRelogio()
    {
        Debug.Log("Relógio ativado!");
        ativo = true;

        if (uiErro != null)
            uiErro.SetActive(false);

        if (canvasController != null)
            canvasController.Ativar_PainelVitoria();
    }

    void MostrarErro()
    {
        Debug.Log("Sequência errada!");

        if (uiErro != null)
        {
            uiErro.SetActive(true);

            CancelInvoke(nameof(EsconderErro));
            Invoke(nameof(EsconderErro), 2f);
        }

        if (canvasController != null)
            canvasController.Ativar_PainelDerrota();
    }

    void EsconderErro()
    {
        if (uiErro != null)
            uiErro.SetActive(false);
    }
}