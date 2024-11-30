using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour
{
    public Vector2 direction = Vector2.right;
    private List<Transform> segments = new List<Transform>();
    public Transform segmentPrefab;
    [SerializeField] private Food food;
    private AudioSource audioSource;
    public ScoreManager ScoreManager;
    public GenerateObstacles GenerateObstacles;

    [System.Obsolete]
    private void Start()
    {
        ResetGame();
        audioSource = GetComponent<AudioSource>();
        ScoreManager = FindObjectOfType<ScoreManager>();
        if (ScoreManager == null)
        {
            Debug.LogError("ScoreManager nem található a scene-ben!");
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && direction != Vector2.down) direction = Vector2.up;
        else if (Input.GetKeyDown(KeyCode.S) && direction != Vector2.up) direction = Vector2.down;
        else if (Input.GetKeyDown(KeyCode.D) && direction != Vector2.left) direction = Vector2.right;
        else if (Input.GetKeyDown(KeyCode.A) && direction != Vector2.right) direction = Vector2.left;
    }

    private void FixedUpdate()
    {
        for (int i = segments.Count - 1; i > 0; i--)
        {
            segments[i].position = segments[i - 1].position;
        }

        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x) + direction.x,
            Mathf.Round(this.transform.position.y) + direction.y,
            0.0f
        );
    }

    private void Grow()
    {
        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = segments[segments.Count - 1].position; 
        segments.Add(segment);
    }

    private void ResetGame()
    {
        for (int i = 1; i < segments.Count; i++)
        {
            Destroy(segments[i].gameObject);
        }

        segments.Clear();
        segments.Add(this.transform);

        this.transform.position = Vector3.zero;

        direction = Vector2.right;
        food.RandomizePosition();

        if (ScoreManager != null)
        {
            ScoreManager.ResetScore();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            Grow();
            ScoreManager.IncreaseScore();
            GenerateObstacles.Obstacle();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            audioSource.Play();
            ResetGame();
            GenerateObstacles.Obstacle();
        }
    }
}
