using UnityEngine;

public class StartScript : MonoBehaviour
{
    public GameObject branch;
    public GameObject trunk;
    public GameObject axe;
    public int branchRange = 4;
    public int moveCount = 1;
    private int currentDirection = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float height = trunk.transform.localScale.y;
        float currentHeight; 
        if(height > 1)
        {
            currentHeight = height; // Track decreasing height
        }
        else
        {
            currentHeight = height/2;
        }
        float bottom = currentHeight - height;
        while (currentHeight > bottom)
        {
            float branchHeight = Random.Range(1, branchRange);
            currentHeight -= branchHeight;
            if (currentHeight <= bottom) break; // Prevent overshooting negative values

            int branchDirection = Random.Range(0, 2) == 0 ? -1 : 1;

            if (currentDirection != branchDirection)
            {
                currentDirection = branchDirection;
                moveCount++;
            }

            // Ensure the branch is positioned relative to the trunk
            Vector3 branchPosition = new Vector3(trunk.transform.position.x + branchDirection * (1+branch.transform.localScale.x/2), currentHeight, 0);
            GameObject newBranch = Instantiate(branch, branchPosition, Quaternion.identity);
            newBranch.GetComponent<branchScript>().direction = branchDirection;
            newBranch.transform.parent = trunk.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
