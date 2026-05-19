using UnityEngine;

public class Gatinho : MonoBehaviour
{
    public Transform garra;

    public float velocidadeMin = 2f;
    public float velocidadeMax = 8f;
    public float aceleracao = 6f;

    private float velocidadeAtual;
    private float velocidadeAlvo;
    private float direcaoX;

    private float minX;
    private float maxX;

    void Start()
    {
        Camera cam = Camera.main;

        Vector3 min = cam.ViewportToWorldPoint(new Vector3(0, 0, cam.nearClipPlane));
        Vector3 max = cam.ViewportToWorldPoint(new Vector3(1, 1, cam.nearClipPlane));

        minX = min.x;
        maxX = max.x;

        NovaDecisao();

        InvokeRepeating("NovaDecisao", 0.8f, 1.2f);
    }

    void Update()
    {
        // suaviza velocidade
        velocidadeAtual = Mathf.Lerp(velocidadeAtual, velocidadeAlvo, Time.deltaTime * aceleracao);

        // movimento
        transform.Translate(Vector2.right * direcaoX * velocidadeAtual * Time.deltaTime);

        float margem = 0.6f;
        Vector3 pos = transform.position;

        // parede direita
        if (pos.x >= maxX - margem)
        {
            pos.x = maxX - margem;
            direcaoX = -1f;
            velocidadeAlvo *= 0.7f; // desacelera na batida (efeito mais natural)
        }

        // parede esquerda
        if (pos.x <= minX + margem)
        {
            pos.x = minX + margem;
            direcaoX = 1f;
            velocidadeAlvo *= 0.7f;
        }

        transform.position = pos;
    }

    void NovaDecisao()
    {
        if (garra != null)
        {
            float distancia = Mathf.Abs(garra.position.x - transform.position.x);

            // 🧠 se a garra estiver perto → foge rápido
            if (distancia < 3f)
            {
                direcaoX = (garra.position.x > transform.position.x) ? -1f : 1f;
                velocidadeAlvo = velocidadeMax;
                return;
            }
        }

        // 🎲 comportamento normal
        direcaoX = Random.value < 0.5f ? -1f : 1f;
        velocidadeAlvo = Random.Range(velocidadeMin, velocidadeMax);

        // 😈 chance de enganar
        if (Random.value < 0.25f)
        {
            direcaoX *= -1;
        }
    }
}