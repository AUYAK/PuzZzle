using UnityEngine;
public class MovesController : MonoBehaviour
{
   [SerializeField] Vector3 moveDirection;
   [SerializeField] KeyCode keyF;
   [SerializeField] KeyCode keyB;

   [SerializeField] float _thrust = 50f;

   private void FixedUpdate() {
    if(Input.GetKey(keyF)){
    GetComponent<Rigidbody>().velocity += moveDirection;}
    if(Input.GetKey(keyB)){
    GetComponent<Rigidbody>().velocity += -moveDirection;}
    }
    private void OnCollisionEnter(Collision other) {
        Debug.Log(moveDirection);
        Rigidbody rb=this.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(rb.velocity.x, rb.velocity.y,rb.velocity.z)* -1 * _thrust);
        
    }
}
