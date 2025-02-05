using UnityEngine;
using System.Collections;

public class AxeController : MonoBehaviour
{
    private Vector3 rightPosition = new Vector3(2, 1, 0);  // Right side position
    private Vector3 leftPosition = new Vector3(-2, 1, 0);  // Left side position
    private bool isRight = true;  // Track which side the axe is on
    private bool isChopping = false; // Prevent multiple swings
    private Vector3 originalScale; // Store the original scale

    void Start()
    {
        // Store original scale
        originalScale = transform.localScale;

        // Ensure axe starts on the right side, facing center
        transform.position = rightPosition;
        FlipAxe(true); // Make sure it starts off correctly flipped
    }

    void Update()
    {
        if (!isChopping)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow)) // Move axe to the left
            {
                MoveAxe(leftPosition, false);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)) // Move axe to the right
            {
                MoveAxe(rightPosition, true);
            }
            else if (Input.GetKeyDown(KeyCode.Space)) // Perform chop
            {
                StartCoroutine(ChopAnimation());
            }
        }
    }

    private void MoveAxe(Vector3 targetPosition, bool toRight)
    {
        transform.position = targetPosition;
        FlipAxe(toRight);
        isRight = toRight;
    }

    private void FlipAxe(bool toRight)
    {
        // Ensures the axe is always flipped to face center
        float newScaleX = toRight ? -Mathf.Abs(originalScale.x) : Mathf.Abs(originalScale.x);
        transform.localScale = new Vector3(newScaleX, originalScale.y, originalScale.z);
    }

    private IEnumerator ChopAnimation()
    {
        isChopping = true;

        float chopDuration = 0.8f; // Speed of chop
        float elapsedTime = 0f;

        Quaternion originalRotation = Quaternion.Euler(0, 0, 0); // Neutral position
        Quaternion tiltBackRotation = Quaternion.Euler(0, 0, isRight ? -40 : 40); // Tilt back first
        Quaternion chopRotation = Quaternion.Euler(0, 0, isRight ? 50 : -50); // Swing forward into tree
        Vector3 startPosition = new Vector3(isRight ? 1 : -1, 1, 0);
        Vector3 originalPosition = new Vector3(isRight ? 2 : -2, 1, 0);

        transform.position = startPosition;

        // Step 1: Tilt the axe back first
        while (elapsedTime < chopDuration / 6/5)
        {
            transform.rotation = Quaternion.Lerp(originalRotation, tiltBackRotation, elapsedTime / (chopDuration / 6/5));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Step 2: Swing the axe forward into the tree
        elapsedTime = 0f;
        while (elapsedTime < chopDuration / 3)
        {
            transform.rotation = Quaternion.Lerp(tiltBackRotation, chopRotation, elapsedTime / (chopDuration / 3));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Step 3: Reset the axe back to its neutral position
        elapsedTime = 0f;
        while (elapsedTime < chopDuration / 3)
        {
            transform.rotation = Quaternion.Lerp(chopRotation, originalRotation, elapsedTime / (chopDuration / 3));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = originalRotation;
        transform.position = originalPosition;
        isChopping = false;
    }
}
