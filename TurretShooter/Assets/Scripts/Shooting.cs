using UnityEngine;

public class Shooting : MonoBehaviour
{
    // use mouse to shoot at middle of the screen, raycasting from camera
    // it has fire rate, and clip size that has to be reloaded
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float fireRate = 0.2f;
    [SerializeField] private int clipSize = 10;
    [SerializeField] private float aimSpread = 0.01f; // viewport-space radius for random spread
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

        // raycast from random point in the middle of the screen
        if (currentAmmo < 0)
            return;
        // get random point in circle
        Vector2 randomOffset = Random.insideUnitCircle * aimSpread;
        Vector3 viewportPoint = new Vector3(0.5f + randomOffset.x, 0.5f + randomOffset.y, 0f);

        Ray ray = playerCamera.ViewportPointToRay(viewportPoint);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit: " + hit.transform.name);
            Instantiate(Resources.Load("ImpactEffect"), hit.point, Quaternion.LookRotation(hit.normal));
            hit.transform.SendMessage("TakeDamage", 1, SendMessageOptions.DontRequireReceiver);
        }
    }
}
