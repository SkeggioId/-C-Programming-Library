// 1. Basic Character Movement
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}

// 2. Spawning Objects
public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float spawnTime = 2f;

    void Start()
    {
        InvokeRepeating("SpawnObject", spawnTime, spawnTime);
    }

    void SpawnObject()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}

// 3. Simple Camera Follow
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothing = 5f;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}

// 4. Basic Enemy AI
public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody enemyRb;
    private Vector3 movement;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        movement = direction;
    }

    void FixedUpdate()
    {
        moveCharacter(movement);
    }

    void moveCharacter(Vector3 direction)
    {
        enemyRb.MovePosition((Vector3)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
}

// 5. Score and Game Over Management
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score = 0;

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        // Update the score display
    }
}

// Remember to add more detailed comments and clear instructions on how to integrate each piece of code within the Unity editor and game objects.
