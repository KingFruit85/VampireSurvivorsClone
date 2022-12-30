using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerController;

public class Knife : MonoBehaviour
{
    Rigidbody2D RigidBody2D;
    Vector3 Left = new Vector3(-1, 0, 0);
    Vector3 Right = new Vector3(1, 0, 0);
    Vector3 Up = new Vector3(0, 1, 0);
    Vector3 Down = new Vector3(0, -1, 0);
    public float Speed = 0.05f;
    float TimeOfBirth;
    public int Damage;
    PlayerController PlayerController;

    // Start is called before the first frame update
    void Start()
    {
        PlayerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        RigidBody2D = GetComponent<Rigidbody2D>();
        Damage = 2;
        TimeOfBirth = Time.time;
        Fire();
    }

    void Fire()
    {
        switch (PlayerController.GetCurrentPlayerDirection())
        {
            case Direction.RIGHT:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, -90));
                RigidBody2D.AddForce(Right * Speed, ForceMode2D.Force);
                break;

            case Direction.LEFT:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
                RigidBody2D.AddForce(Left * Speed, ForceMode2D.Force);
                break;

            case Direction.UP:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                RigidBody2D.AddForce(Up * Speed, ForceMode2D.Force);
                break;

            case Direction.DOWN:
                transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
                RigidBody2D.AddForce(Down * Speed, ForceMode2D.Force);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == 6)
        {
            other.transform.GetComponent<Health>().TakeDamage(Damage);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > TimeOfBirth + 2f)
        {
            Destroy(gameObject);
        }
    }
}
