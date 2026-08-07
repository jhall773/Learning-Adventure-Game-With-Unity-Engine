using System.IO.Compression;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class SimpleMoverBackground3Cave : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 move;

    private bool isMoving;

    public LayerMask interactableLayer;

    private SpriteRenderer spriteRenderer;

    private Rigidbody2D rb2D;

    private Animator animator;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        isMoving = false;

        // move the RigidBody2D instead of moving the Transform
        rb2D.linearVelocity = move * speed;
        //transform.Translate(move * speed * Time.deltaTime);

        Debug.Log("This is move.x" + move.x);
        Debug.Log("This is move.y" + move.y);

        if (move != Vector2.zero)
        {
            animator.SetFloat("moveX", move.x);
            animator.SetFloat("moveY", move.y);
            isMoving = true;
        }

        if (move.x != 0)
        {
            spriteRenderer.flipX = move.x < 0;
        }

        animator.SetBool("isMoving", isMoving);
    }
    
    public void Interact(InputAction.CallbackContext context)
    {
        var facingDir = new Vector2(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = rb2D.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 1f, interactableLayer);
        //Debug.DrawLine(transform.position, interactPos, Color.red, 3f);

        if (collider != null)
        {
            Debug.Log("There is an NPC here!");
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        move.Normalize();
    }
}

/*
public class PlayerControlls1 : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;
    private Vector2 input;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving == false)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        //Note: Mathf.Epsilon is basically if > very small number approx. > 0
        //The moving Process Using Movespeed and Vector3.MoveTowards()
        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;
        isMoving = false;

    }
}
*/
