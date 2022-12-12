using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class UpdateScene : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        if (this.gameObject.name == "Refresh")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
         if (this.gameObject.name == "Next")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}
