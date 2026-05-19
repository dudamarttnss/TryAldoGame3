using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float tempo = 30f;

    public GameObject telaVitoria;
    public GameObject telaDerrota;

    public int gatosNecessarios = 1;
    private int gatosPegos = 0;

    private bool acabou = false;

    void Update()
    {
        if (acabou) return;

        tempo -= Time.deltaTime;

        if (tempo <= 0)
        {
            Derrota();
        }
    }

    public void PegouGato()
    {
        gatosPegos++;

        if (gatosPegos >= gatosNecessarios)
        {
            Vitoria();
        }
    }

    void Vitoria()
    {
        acabou = true;
        telaVitoria.SetActive(true);
        Time.timeScale = 0f;
    }

    void Derrota()
    {
        acabou = true;
        telaDerrota.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}