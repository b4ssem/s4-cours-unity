using UnityEngine;

public class PlayerMovement : MonoBehaviour // Correction de l'orthographe (Mouvement -> Movement)
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 10f; // Utilisation d'un float pour la précision
    
    private float moveDirectionX;
    private bool isFacingRight = true;
    void Update()
    {
        // On récupère l'input dans le Update pour plus de réactivité
        moveDirectionX = Input.GetAxisRaw("Horizontal");
        flip();
    }

    private void FixedUpdate()
    {
        // Les calculs physiques se font toujours dans FixedUpdate
        Move();
    }
    private void flip()
    {
        if (moveDirectionX > 0 && !isFacingRight || moveDirectionX < 0 && isFacingRight){
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *=-1;
            transform.localScale = localScale;
        }
    }
    private void Move()
    {
        // Correction de la faute de frappe "lenearVelocity" -> "linearVelocity"
        rb.linearVelocity = new Vector2(moveDirectionX * moveSpeed, rb.linearVelocity.y);
    }
}