using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    
    public Transform firePoint;
    public GameObject ammoType;
    public float shotSpeed;
    private float angle;
    public float shotCounter, fireRate;
    public PlayerAimWeapon paw;

    // Start is called before the first frame update
    void Start()
    {
        paw = FindObjectOfType<PlayerAimWeapon>();
        angle = paw.angle;


    }

    // Update is called once per frame
    void Update()
    {
        firePoint = GameObject.Find("Shooting Point").transform;
        if(Input.GetMouseButtonDown(0))
        {
            shotCounter -= Time.deltaTime;
            if(shotCounter <= 0){
                shotCounter = fireRate;
                Shoot();
            }
            else{
                shotCounter = 0;
            }
        }
    } 
    private void Shoot()
    {
            GameObject shot = Instantiate(ammoType, firePoint.position, firePoint.rotation);
            shot.transform.position = firePoint.position;
            shot.transform.rotation = Quaternion.Euler(0, 0, angle);

            shot.GetComponent<Rigidbody2D>().velocity = firePoint.right * shotSpeed;
            Destroy(shot.gameObject, 1f);
        
    }
}
