using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] private SaveManager saveManager;   // Accesses the Save Manager

    private SpriteRenderer sRend;

    private void Awake()
    {
        sRend = GetComponent<SpriteRenderer>(); // gotta get the sprite renderer
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check to see if the player entered into the checkpoint trigger
        if(other.CompareTag("Player")) // to be improved later
        {
            // visual indicator/feedback that player triggered the checkpoint
            sRend.color = Color.green;

            // Save the player's progress at checkpoint
            saveManager.SaveGame(other.transform.position); // other = other thing, saves the position to save manager

            Debug.Log("Checkpoint Reached!");
        }
    }
}
