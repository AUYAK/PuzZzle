using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.R))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
        }
        if (Input.GetKey(KeyCode.N))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);  
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (this.CompareTag("Player") && other.CompareTag("Finish")){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
