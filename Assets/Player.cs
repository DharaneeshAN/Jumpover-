using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Make sure you're using TextMeshPro

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    public TextMeshProUGUI scoreText; // Drag your TMP UI Text here in Inspector
    private int score = 0;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        canJump = true;
        UpdateScoreUI(); // Initialize score
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canJump)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); // Reset Y velocity
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            score++;
            UpdateScoreUI();
            Debug.Log("ScoreZone Triggered: " + score);
            canJump = false; // prevent double jumping
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            canJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            SceneManager.LoadScene("Game"); // Restart the scene
        }

        if (other.CompareTag("ScoreZone"))
        {
            score++;
            UpdateScoreUI();
            Debug.Log("ScoreZone Triggered: " + score);
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
