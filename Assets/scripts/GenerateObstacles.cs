using NUnit.Framework;
using UnityEngine;

public class GenerateObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public BoxCollider2D Gridarea;
    public GameObject[] obstacles = new GameObject[5];
    public Vector2[] obstaclePositions = new Vector2[5]; 

    private void Start()
    {
        GenerateObstaclesInScene();
    }

    public Vector2 RandomizePosition()
    {
        Bounds bounds = this.Gridarea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        return new Vector2(Mathf.Round(x), Mathf.Round(y));
    }
    public bool IsPositionOccupied(Vector2 position)
    {
        foreach (Vector2 obstaclePos in obstaclePositions)
        {
            if (obstaclePos == position)
            {
                return true;
            }
        }
        return false;
    }

    public void GenerateObstaclesInScene()
    {
        for (int i = 0; i < 5; i++)  
        {
            Vector2 randomPosition = RandomizePosition();

             
            obstacles[i] = Instantiate(obstaclePrefab, randomPosition, Quaternion.identity);

           
            obstacles[i].transform.position = randomPosition;
            obstaclePositions[i] = randomPosition;

            obstacles[i].transform.position = randomPosition;
        }
    }

    public void ClearObstacles()
    {
        for(int i = 0;i < obstacles.Length;i++)
        {
            Destroy(obstacles[i]); 
        }   
    }

    public void Obstacle()
    {
        ClearObstacles();
        GenerateObstaclesInScene();
    }
}
