using UnityEngine;

public class Shooting : MonoBehaviour
{
    // use mouse to shoot at middle of the screen, raycasting from camera
    // it has fire rate, and clip size that has to be reloaded
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private int clipSize = 10;
    private float nextTimeToFire = 0f;
    private int currentAmmo;
    [SerializeField] AnimationClip reloadAnimation;
    [SerializeField] Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentAmmo = clipSize;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire && currentAmmo > 0)
        {
            nextTimeToFire = Time.time + fireRate;
            Shoot();
        }
        // reload on R key
        if (Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
        }
    }
    private System.Collections.IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        animator.Play(reloadAnimation.name);
        yield return new WaitForSeconds(2f);
        currentAmmo = clipSize;
        Debug.Log("Reloaded");
    }
    void Shoot()
    {
        currentAmmo--;
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name);
            hit.transform.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }
}
