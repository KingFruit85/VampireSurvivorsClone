using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float MoveX;
    float MoveY;
    float MoveSpeed = 2f;
    Vector2 Movement;
    Rigidbody2D Rigidbody2D;
    [SerializeField]
    private int XP;


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

    public void AddXp(int xp)
    {
        XP += xp;
    }
}
