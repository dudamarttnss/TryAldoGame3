using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorCanvas : MonoBehaviour
{
    // Referencia do GameObject do painel de Vitória
    public GameObject PainelVitoria;

    // Referencia do GameObject do painel de Derrota
    public GameObject PainelDerrota;


    // Chamado 1 vez ao inicializar a cena
    void Start()
    {
        // Despausa o Jogo
        Time.timeScale = 1;
    }


    // Função para ativar o Painel de Vitória
    public void Ativar_PainelVitoria()
    {
        // Ativa o painel de Vitória
        PainelVitoria.SetActive(true);

        // Pausa o jogo
        Time.timeScale = 0;
    }

    // Função para ativar o Painel de Derrota
    public void Ativar_PainelDerrota()
    {
        // Ativa o painel de Derrota
        PainelDerrota.SetActive(true);

        // Pausa o jogo
        Time.timeScale = 0;
    }

    // Função para desativar os dois painéis
    public void Desativar_Paineis()
    {
        //Desativa Painel Vitória
        PainelVitoria.SetActive(false);
        //Desativa Painel Derrota
        PainelDerrota.SetActive(false);
    }


    // Função para mudar de cena (pede o nome da cena desejada ao invocarmos a função)
    public void Mudar_Cena(string NomeDaCena)
    {
        SceneManager.LoadScene(NomeDaCena);
    }
}
