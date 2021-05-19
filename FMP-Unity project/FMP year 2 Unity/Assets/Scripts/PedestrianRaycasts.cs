using UnityEngine;

public class PedestrianRaycasts : MonoBehaviour
{

    public float damage = 10f;
    public float range = 100f;
    public static int Run = 0;
    public GameObject Scare;
    

    public GameObject Aim;

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetMouseButton(1))
        {
            Shoot();
            Debug.DrawRay(transform.position, transform.forward * range, Color.yellow, 1, true);
        }

    }

    void Shoot()
    {
        

        RaycastHit hit;
        if (Physics.Raycast(Aim.transform.position, Aim.transform.forward, out hit, range) && hit.transform.tag == "Pedestrian")
        {
            Debug.Log(hit.transform.name);
            Debug.Log("Hit"+ damage);
           
            Run += 1;
            Scare.GetComponent<CharacterNavigationController>().enabled = false;
            // Use tags for it instaed of the gameobject use tags
        }
    }
}
