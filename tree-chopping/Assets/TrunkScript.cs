using UnityEngine;

public class TrunkScript : MonoBehaviour
{
    public float heightMultiplier = 1.0f;
    public Rigidbody2D body;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        float prevHeightScale = transform.localScale.y;

        float newHeightScale = prevHeightScale * heightMultiplier;

        transform.localScale = new Vector3(transform.localScale.x, newHeightScale, transform.localScale.z);

        transform.position = new Vector3(transform.position.x, (newHeightScale) / 2, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 5)
        {
            body.linearVelocity = Vector2.zero;
            return;
        }
        if (collision.gameObject.layer == 0)
        {
            body.linearVelocity = Vector2.up * -10;
        }
    }
}
