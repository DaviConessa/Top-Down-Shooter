using UnityEngine;

public class Gun_Controler : MonoBehaviour
{
    Gun equippedGun;
    [SerializeField] Transform weaponHolder;
    [SerializeField] Gun startingGun;


    private void Start()
    {
        if(startingGun != null)
        {
            EquipdGun(startingGun);
        }
    }

    public void EquipdGun ( Gun gunToEquiped)
    {
        if (equippedGun != null)
        {
            Destroy(equippedGun.gameObject);
        }

        equippedGun = Instantiate(gunToEquiped, weaponHolder.position, weaponHolder.rotation);
        equippedGun.transform.parent = weaponHolder;
    }
    
}
