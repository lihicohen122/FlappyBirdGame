using UnityEngine;

public class SpawnPipes : MonoBehaviour
{
    public GameObject prefab;
    public float spawnRate = 1.0f;
    public float minHeight = -1.0f;
    public float maxHeight = 1.0f;

    private void OnEnable() //if the player looses we will like to stop everything
    {
        InvokeRepeating(nameof(Spawning), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawning));
    }

    private void Spawning()
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
