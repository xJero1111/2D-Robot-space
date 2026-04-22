using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //buscamos automáticamente el GameManager en la escena
        if (gameManager == null)
        {
            gameManager = FindObjectOfType<GameManager>();
        }

        if (gameManager == null)
        {
            Debug.LogWarning("Hazard: No se encontró GameManager en la escena.");
        }
    }

    //función especial que se ejecuta cuando se toca a otro objeto que tiene un collider en modo trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        //verificamos que el objeto que entra sea el jugador
        if (other.CompareTag("Player"))
        {
            if (gameManager != null)
            {
                gameManager.EndGrayEnding();
            }
        }
    }
}