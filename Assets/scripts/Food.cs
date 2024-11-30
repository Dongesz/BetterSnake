using UnityEngine;
using UnityEngine.Audio;

public class Food : MonoBehaviour
{
    public BoxCollider2D Gridarea;
    private AudioSource audioSource;
    public GenerateObstacles obstacleGenerator;

    private void Start()
    {
        RandomizePosition();
        audioSource = GetComponent<AudioSource>();
    }
    public void RandomizePosition()
    {
        bool isValidPosition = false;

        while (!isValidPosition)
        {
            Vector2 randomPosition = obstacleGenerator.RandomizePosition(); 

            if (!obstacleGenerator.IsPositionOccupied(randomPosition))
            {
                isValidPosition = true;
                this.transform.position = randomPosition; 
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            audioSource.Play();
            RandomizePosition();
        } 
            
    }
}
 