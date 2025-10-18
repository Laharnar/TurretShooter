using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Crouching crouching;
    public Jumping jumping;
    public Shooting shooting;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
            crouching.Crouch();
        if (Input.GetKeyDown(KeyCode.Space))
            jumping.Jump();
        if (Input.GetButton("Fire1"))
            shooting.TryShoot();
        if(Input.GetKeyDown(KeyCode.R))
            StartCoroutine(shooting.Reload());
    }
}
