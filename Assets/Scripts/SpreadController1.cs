using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpreadController : MonoBehaviour
{
    public Transform[] firePoints;
    public GameObject ammoType;
    public float shotSpeed;
    private float angle;
    public float shotCounter, fireRate;
    public PlayerAimWeapon paw;
    public string weaponTag;


    // Start is called before the first frame update
    void Start()
    {
        paw = FindObjectOfType<PlayerAimWeapon>();
        angle = paw.angle;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("shotgunPoint");
        for (int i = 0; i < gameObjects.Length; i++)
        {
            firePoints[i] = gameObjects[i].transform;
        }
        if (Input.GetMouseButtonDown(0))
        {
            shotCounter -= Time.deltaTime;
            if (shotCounter <= 0)
            {
                shotCounter = fireRate;
                Shoot();
            }
            else
            {
                shotCounter = 0;
            }
        }
    }
    private void Shoot()
    {

        foreach (Transform firePoint in firePoints)
        {

            GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            shot.transform.position = firePoint.position;
            shot.transform.rotation = Quaternion.Euler(0, 0, angle);

            shot.GetComponent<Rigidbody2D>().velocity = firePoint.right * shotSpeed;
            Destroy(shot.gameObject, 1f);
        }
    }
}
