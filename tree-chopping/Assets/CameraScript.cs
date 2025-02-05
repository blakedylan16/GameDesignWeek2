using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + 10 * Time.deltaTime, transform.position.z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - 10 * Time.deltaTime, transform.position.z);
        }    
            
    }
}
