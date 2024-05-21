using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPickup : MonoBehaviour
{
    private int keysCollected = 0; // Counter to track the number of keys collected

    // Called when the player collides with another collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the player collides with a key
        if (other.CompareTag("Key"))
        {
            // Destroy the key GameObject
            Destroy(other.gameObject);

            // Increment the keys collected counter
            keysCollected++;

            Debug.Log("Key collected! Total keys collected: " + keysCollected);
        }
        // Check if the player collides with the door
        else if (other.CompareTag("door"))
        {
            // Load the LevelTwo scene
            LoadLevelTwo();
        }
    }

    // Load the LevelTwo scene
    private void LoadLevelTwo()
    {
        SceneManager.LoadScene("LevelTwo");
    }
}
