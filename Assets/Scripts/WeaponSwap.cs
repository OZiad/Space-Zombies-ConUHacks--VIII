using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject activeWeapon;
    private GameObject gun;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
        gun = GameObject.FindGameObjectWithTag("Gun");
        spriteRenderer = gun.GetComponent<SpriteRenderer>();

        // Assuming the initial active weapon has the WeaponController or SpreadController script
        UpdateWeapon(activeWeapon);
    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        activeWeapon = newWeapon;
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;

        // Check if the new weapon has SpreadController
        SpreadController spreadController = newWeapon.GetComponent<SpreadController>();
        if (spreadController != null)
        {
            ChangeSprite(shotgun);
        }
        else
        {
            // Assuming other guns have WeaponController
            WeaponController weaponController = newWeapon.GetComponent<WeaponController>();
            if (weaponController != null)
            {
                string tag = weaponController.weaponTag;
                switch (tag)
                {
                    case "Rifle":
                        ChangeSprite(rifle);
                        break;
                    case "SmallPistol":
                        ChangeSprite(smPistol);
                        break;
                    case "LaserPistol":
                        ChangeSprite(lsrPistol);
                        break;
                    case "FlameThrower":
                        ChangeSprite(flameThrower);
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
