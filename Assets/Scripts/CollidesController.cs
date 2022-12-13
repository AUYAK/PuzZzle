using UnityEngine;

public class CollidesController : MonoBehaviour
{
[SerializeField] float _thrust = 25f;

public AndroidSwipesController swipesController;
    private void Start() {
        swipesController = GetComponent<AndroidSwipesController>(); 
    }
    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if (other.gameObject.tag == "Board")//Just to not put any force on board(isKinematic = true).
        {
            rb = this.GetComponent<Rigidbody>();
            rb.AddForce(swipesController.velocity * -1 * _thrust);
            // other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        if (other.gameObject.tag == "Block")
        {
            Rigidbody otherRb = other.gameObject.GetComponent<Rigidbody>();
            Debug.Log(rb.name + rb.velocity + "/" + otherRb.name + other.impulse);
            rb.AddForce(swipesController.velocity * -1 * _thrust);
            otherRb.AddForce(swipesController.velocity * _thrust * (rb.mass / otherRb.mass)); //collision by Newton
        }
    }
}
