using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalEscolha : MonoBehaviour
{
    public GameObject painelEscolha;
    public string NomeDaCena;

    public void IrParaCena()
    {
        Time.timeScale = 1f;

        SceneManager.LoadScene(NomeDaCena);
    }

    public void FecharPainel()
    {
        painelEscolha.SetActive(false);

        Time.timeScale = 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            painelEscolha.SetActive(true);

            Time.timeScale = 0f;
        }
    }
}