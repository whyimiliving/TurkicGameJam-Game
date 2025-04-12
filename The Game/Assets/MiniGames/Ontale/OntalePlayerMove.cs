using UnityEngine;

public class OntalePlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 movement;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = movement.normalized;

        transform.position += (Vector3)movement * (moveSpeed * Time.fixedDeltaTime);
    }
}
