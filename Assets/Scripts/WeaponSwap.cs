using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject activeWeapon;

    // Start is called before the first frame update
    void Start()
    {
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
    }

    public void UpdateWeapon(GameObject newWeapon){
        activeWeapon = newWeapon;
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
    }
}
