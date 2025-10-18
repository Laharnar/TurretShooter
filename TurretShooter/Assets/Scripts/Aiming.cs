using UnityEngine;

public class Aiming : MonoBehaviour
{
    [SerializeField] private Transform verticalAim;
    [SerializeField] Vector2 aimSensitivity = Vector2.one;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // lock cursor to center of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.Rotate(Vector3.up * mouseX * aimSensitivity.x);
        verticalAim.Rotate(Vector3.left * mouseY * aimSensitivity.y);

    }
}
