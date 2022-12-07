using UnityEngine;
public class MovesController : MonoBehaviour
{
   [SerializeField] Vector3 moveDirection;
   [SerializeField] KeyCode keyF;
   [SerializeField] KeyCode keyB;

   private void FixedUpdate() {
    if(Input.GetKey(keyF)){
    GetComponent<Rigidbody>().velocity += moveDirection;}
    if(Input.GetKey(keyB)){
    GetComponent<Rigidbody>().velocity += -moveDirection;}
    }
    
}
