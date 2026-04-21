using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] private int requiredKeyId = 0;
    [SerializeField] private bool consumeKeyOnOpen = true;

    [SerializeField] private Collider2D blockingCollider;
    [SerializeField] private GameObject closedVisual;
    [SerializeField] private GameObject openedVisual;
    [SerializeField] private Animator gateAnimator;

    private bool isOpen = false;

    //función especial que se ejecuta cuando se toca a otro objeto que tiene un collider en modo trigger
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOpen)
        {
            return;
        }

        PlayerInventory playerInventory = other.GetComponentInParent<PlayerInventory>();

        if (playerInventory == null)
        {
            return;
        }

        if (playerInventory.HasKey(requiredKeyId))
        {
            if (consumeKeyOnOpen)
            {
                playerInventory.UseKey(requiredKeyId);
            }

            OpenGate();
        }
    }

    void OpenGate()
    {
        isOpen = true;

        if (blockingCollider != null)
        {
            blockingCollider.enabled = false;
        }

        if (closedVisual != null)
        {
            closedVisual.SetActive(false);
        }

        if (openedVisual != null)
        {
            openedVisual.SetActive(true);
        }

        if (gateAnimator != null)
        {
            gateAnimator.SetTrigger("Open");
        }
    }
}