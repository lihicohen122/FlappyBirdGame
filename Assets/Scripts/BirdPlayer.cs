using UnityEngine;

public class BirdPlayer : MonoBehaviour
{
    private Vector3 playerDirection;
    private SpriteRenderer spriteRenderer;
    private int spriteArrayIndex;
    private float timeCycled = 0.15f; 

    public float gravity = -9.8f;
    public float strength = 5f;
    public Sprite[] spriteArray; 

    private void Awake() //will only be called once- when we start the script
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    private void Start() //gets called the very first frame this object is enabled 
    {
        InvokeRepeating(nameof(spriteAnimate), timeCycled, timeCycled);
    }

    private void spriteAnimate()
    {
        spriteArrayIndex++;

        if (spriteArrayIndex >= spriteArray.Length)
        {
            spriteArrayIndex = 0;
        }

        spriteRenderer.sprite = spriteArray[spriteArrayIndex];
    }

    private void Update() //handels input. Is called every single frame
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            playerDirection = Vector3.up * strength;
        }

        playerDirection.y += gravity * Time.deltaTime;
        transform.position += playerDirection * Time.deltaTime; //to make it frame rate independent

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }
        else if (other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().AddScore();
        }
    }

    private void OnEnable()
    {
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        playerDirection = Vector3.zero;
    }

}
