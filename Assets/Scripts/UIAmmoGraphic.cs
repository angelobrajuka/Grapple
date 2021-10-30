using UnityEngine;
using UnityEngine.UI;

public class UIAmmoGraphic : MonoBehaviour
{
    // hierarchy
    public GameObject prefab_ammoTick;
    public bool mag; // uses magSize when true, playerAmmo when false
    public float spacing;
    public Color color;

    int ammo=0;
    string ammoType;

    void Update()
    {
        string pAmmoType = PlayerInventory.CurrentGun.ammoType;
        if(pAmmoType != ammoType)
        {
            ammoType = pAmmoType;
            for(int i=0; i<transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<RawImage>().texture = PlayerHUD.ammoImages[ammoType];
            }
        }

        int pAmmo = mag ? PlayerInventory.CurrentGun.magSize : PlayerInventory.Ammo;
        if(pAmmo != ammo)
        {
            ammo = pAmmo;
            for(int i=transform.childCount; i>ammo; i--)
            {
                Destroy(transform.GetChild(i-1).gameObject);
            }
            for(int i=transform.childCount; i<ammo; i++)
            {
                var go = Instantiate(prefab_ammoTick, transform.position+Vector3.right*(transform.childCount)*spacing, Quaternion.identity, transform);
                go.GetComponent<RawImage>().color = color;
                go.GetComponent<RawImage>().texture = PlayerHUD.ammoImages[ammoType];
            }
        }
    }
}