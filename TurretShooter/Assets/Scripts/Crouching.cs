using UnityEngine;

public class Crouching:MonoBehaviour
{
    [SerializeField] private GameObject crouchingGo;
    [SerializeField] private GameObject standingGo;
    internal bool crouching;
    private Transform target;
    [SerializeField] private float lerpSpeed = 0.7f;

    private void Start()
    {
        target = standingGo.transform;
    }

    private void Update()
    {
        // crouch with left ctrl
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            crouching = !crouching;
            if (!crouching)
                target = standingGo.transform;
            else
            target = crouchingGo.transform;
        }

        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);

    }
}
