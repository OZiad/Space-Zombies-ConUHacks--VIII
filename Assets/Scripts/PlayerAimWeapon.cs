using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    private Transform aimTransform;
    public GameObject bullet;
    public Transform firePoint;
    public float bulletSpeed = 50;
    public float angle;
    private Vector3 lookDirection;
    private Vector3 aimDirection;
    private Animator aimAnimator;
    public GameObject Weapon;

    
    private void Awake()
    {
        aimTransform = transform.Find("Aim");
        aimAnimator = aimTransform.GetComponent<Animator>();
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
    }

    private void Update()
    {
        HandleAiming();

    }

    private void HandleAiming()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 offset = new Vector3(0.0f, 0.75f, 0.0f);

        aimDirection = (lookDirection - transform.position - offset);
        angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;

        aimTransform.eulerAngles = new Vector3(0, 0, angle);
    }

   


}
