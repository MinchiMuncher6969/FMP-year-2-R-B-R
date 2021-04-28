﻿using UnityEngine;

public class GunScript : MonoBehaviour {

    public float damage = 10f;
    public float range = 100f;

    public GameObject Gun;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            Debug.Log("Shooting");
        }
    }

    void Shoot ()
    {
        RaycastHit hit;
        if (Physics.Raycast(Gun.transform.position, Gun.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Debug.Log("Hit");
        }
    }
}
