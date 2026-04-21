using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f; //variable para guardar la velocidad
    [SerializeField] private Rigidbody2D rb;

    private Vector2 moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //leer las teclas WASD o las flechas
        moveInput.x = Input.GetAxis("Horizontal");
        moveInput.y = Input.GetAxis("Vertical");
    }

    //movimiento físico del personaje
    private void FixedUpdate()
    {
        Vector2 movement = moveInput.normalized * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}