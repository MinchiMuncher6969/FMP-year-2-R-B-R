using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public ParticleSystem muzzleFlash;

    public GameObject Gun;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Shoot();
           
            Debug.DrawRay(transform.position, transform.forward * range, Color.yellow, 1, true);
        }
    }

    void Shoot ()
    {
        muzzleFlash.Play();

        RaycastHit hit;
        if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("Hit");

            Target target = hit.transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
        }
    }
}
