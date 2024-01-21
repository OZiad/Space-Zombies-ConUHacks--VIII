using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerContrller : MonoBehaviour
{

    [SerializeField]
    private GameObject particles;
    public Transform firePoint;
    private float angle;
    public PlayerAimWeapon paw;

    // Start is called before the first frame update
    void Start()
    {
        particles.SetActive(false);
        paw = FindObjectOfType<PlayerAimWeapon>();
        angle = paw.angle;


    }

    // Update is called once per frame
    void Update()
    {
        firePoint = GameObject.Find("Shooting Point").transform;

        if(Input.GetMouseButtonDown(0))
        {
             particles.SetActive(true);
             particles.transform.position = firePoint.transform.position;
        }
    } 
}
