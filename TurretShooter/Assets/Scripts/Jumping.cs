using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Jumping : MonoBehaviour
{
    Rigidbody rig;
    [SerializeField] private float jumpForce = 5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public void Jump()
    {
        rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
