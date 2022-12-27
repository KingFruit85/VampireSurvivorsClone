using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float MoveX;
    private float MoveY;
    private float MoveSpeed = 2f;
    private Vector2 Movement;
    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Movement.x = Input.GetAxisRaw("Horizontal");
        Movement.y = Input.GetAxisRaw("Vertical");

        MoveX = Movement.x * MoveSpeed;
        MoveY = Movement.y * MoveSpeed;

        Rigidbody2D.velocity = new Vector2(MoveX, MoveY);
    }
}
