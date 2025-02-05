using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    public float heightMultiplier = 1.0f;
    public Rigidbody2D body;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>(); // Ensure body is assigned

        // Adjust tree height based on multiplier
        float prevHeightScale = transform.localScale.y;
        float newHeightScale = prevHeightScale * heightMultiplier;
        transform.localScale = new Vector3(transform.localScale.x, newHeightScale, transform.localScale.z);
        transform.position = new Vector3(transform.position.x, newHeightScale / 2, transform.position.z);
    }

    private void Update()
    {
        // You can add other logic for the tree here
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 5)
        {
            ChopTree(); // Stop the tree when it hits the hitbox
        }
    }

    public void StopTree()
    {
        // Stop the tree's movement and freeze it
        body.linearVelocity = Vector2.up * 0;

        // Stop all child branches' movement when the tree stops
        foreach (Transform branch in transform)
        {
            Rigidbody2D branchRb = branch.GetComponent<Rigidbody2D>();
            if (branchRb != null)
            {
                branchRb.linearVelocity = Vector2.up * 0;   // Stop movement
            }
        }
    }

    // This method is called when the tree is chopped and starts falling
    public void ChopTree()
    {
        body.linearVelocity = Vector2.up * -10; // Enable gravity for the falling effect

        // Enable physics for the branches
        foreach (Transform branch in transform)
        {
            Rigidbody2D branchRb = branch.GetComponent<Rigidbody2D>();
            if (branchRb != null)
            {
                branchRb.linearVelocity = Vector2.up * -10; // Ensure gravity is applied to the branch
            }
        }
    }
}
