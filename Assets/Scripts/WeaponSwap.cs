using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    public Transform weaponSlot;
    public GameObject activeWeapon;
    private GameObject gun;
    private SpriteRenderer spriteRenderer;
    public Sprite rifle;
    public Sprite shotgun;
    public Sprite smPistol;
    public Sprite lsrPistol;
    public Sprite flameThrower;

    // Start is called before the first frame update
    void Start()
    {
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
        gun = GameObject.FindGameObjectWithTag("Gun");
        spriteRenderer = gun.GetComponent<SpriteRenderer>();

    }

    public void UpdateWeapon(GameObject newWeapon)
    {
        activeWeapon = newWeapon;
        var weapon = Instantiate(activeWeapon, weaponSlot.transform.position, weaponSlot.transform.rotation);
        weapon.transform.parent = weaponSlot.transform;
        string tag = newWeapon.tag;
        switch (tag)
        {
            case "Rifle":
                ChangeSprite(rifle);
                break;
            case "Shotgun":
                ChangeSprite(shotgun);
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


    void ChangeSprite(Sprite sprite)
    {
        spriteRenderer.sprite = sprite;
    }
}
