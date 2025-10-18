using UnityEngine;
public class Crouching:MonoBehaviour
{
    [SerializeField] private GameObject crouchingGo;
    [SerializeField] private GameObject standingGo;
    internal bool crouching;
    private Transform target;
    [SerializeField] private float lerpSpeed = 0.7f;
    [SerializeField] private Shooting shooting;

    private void Start()
    {
        target = standingGo.transform;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, lerpSpeed);
    }

    public void Crouch()
    {
        crouching = !crouching;
        shooting.crouching = crouching;
        if (!crouching)
            target = standingGo.transform;
        else
            target = crouchingGo.transform;
    }
}
