using UnityEngine;
using TMPro;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private PlayerInventory playerInventory;
    [SerializeField] private EnergyProgressManager energyProgressManager;
    [SerializeField] private TextMeshProUGUI notificationText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (playerInventory == null)
        {
            playerInventory = GetComponent<PlayerInventory>();
        }
    }

    //función especial que se ejecuta cuando se toca a otro objeto que tiene un collider en modo trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        EnergyCollectable energyCollectable = other.GetComponent<EnergyCollectable>();

        if (energyCollectable != null)
        {
            if (energyProgressManager != null)
            {
                energyProgressManager.AddEnergy(energyCollectable.GetEnergyType(), energyCollectable.GetEnergyAmount());
                ShowNotification("Energía recolectada");
            }

            Destroy(other.gameObject);
            return;
        }

        KeyItem keyItem = other.GetComponent<KeyItem>();

        if (keyItem != null)
        {
            if (playerInventory != null)
            {
                playerInventory.AddKey(keyItem.GetKeyId());
                ShowNotification("Llave recogida");
            }

            Destroy(other.gameObject);
        }
    }

    void ShowNotification(string message)
    {
        if (notificationText != null)
        {
            notificationText.text = message;
        }
    }
}