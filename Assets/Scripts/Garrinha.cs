using UnityEngine;

public class Garrinha : MonoBehaviour
{
    public float velocidade = 5f;
    public float velocidadeBaixa = 5f;
    public float velocidadeAlta = 5f;

    private bool isDropping = false;
    private bool isReturning = false;

        void Update()
    {
      if (!isDropping && !isReturning)
        {
            float move = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * move * velocidade *Time.deltaTime);
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isDropping = true;
            }

        }       

        if(isDropping)
        {
            transform.Translate(Vector3.down * velocidadeBaixa * Time.deltaTime);
            
            if(transform.position.y < -3f)
            {
                isDropping = false;
                isReturning = true;
            }
        }    
        
        if(isReturning)
        {
            transform.Translate(Vector3.up * velocidadeAlta * Time.deltaTime);

            if(transform.position.y >= 3f)
            {
                isReturning = false;
            }
        }
    }

      void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.CompareTag("gatinho"))
        {
            Destroy(other.gameObject);
           
           
        }
    
    }

}