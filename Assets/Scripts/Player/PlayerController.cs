using UnityEngine;

public class PlayerController : MonoBehaviour
{

    float MoveX;
    float MoveY;
    [SerializeField]
    float MoveSpeed = 3f;
    Vector2 Movement;
    Rigidbody2D Rigidbody2D;
    [SerializeField]
    private int XP;

    public Direction PlayerIsFacing;

    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN
    };


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

        // This sucks
        if (Input.GetKeyDown(KeyCode.A))
        {
            PlayerIsFacing = Direction.LEFT;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            PlayerIsFacing = Direction.UP;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            PlayerIsFacing = Direction.RIGHT;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            PlayerIsFacing = Direction.DOWN;
        }

    }

    public void AddXp(int xp)
    {
        XP += xp;
    }

    public Direction GetCurrentPlayerDirection()
    {
        return PlayerIsFacing;
    }
}
