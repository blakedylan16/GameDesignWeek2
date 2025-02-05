using UnityEngine;

public class branchScript : MonoBehaviour
{
    public int direction = 1;
    public GameObject axe;
    public TrunkScript trunk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        trunk = GameObject.FindGameObjectWithTag("Trunk").GetComponent<TrunkScript>();
        axe = GameObject.FindGameObjectWithTag("Axe");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 1)
        {
            if(axe.GetComponent<AxeController>().direction == direction)
            {
                trunk.StopTree();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.layer == 2)
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 3)
        {
            Destroy(gameObject);
        }
    }
}
