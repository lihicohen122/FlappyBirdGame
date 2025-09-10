using UnityEngine;

public class MovePipes : MonoBehaviour
{
    public float movingSpeed = 5f;

    private float leftEdgeOfScreen;

    private void Start()
    {
        leftEdgeOfScreen = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; //calculate the left edge of the screen for smooth pipe movement
    }

    private void Update() //handels input. Is called every single frame
    {
        transform.position += Vector3.left * movingSpeed * Time.deltaTime;

        if(transform.position.x < leftEdgeOfScreen)
        {
            Destroy(gameObject);
        }
    }
}
