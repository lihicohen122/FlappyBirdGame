using System.Threading;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    public float movingAnimationSpeed = 1f; 

    private void Awake() //will only be called once- when we start the script
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Update() //handels input. Is called every single frame
    {
        meshRenderer.material.mainTextureOffset += new Vector2(movingAnimationSpeed * Time.deltaTime, 0) ; //only moving backround in the x field
    }
}
