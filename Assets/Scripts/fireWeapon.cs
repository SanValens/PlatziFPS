using UnityEngine;

public class fireWeapon : MonoBehaviour 
{   
    public float damage = 1f;
    public float range = 150;
    public Camera cam;

    // Update is called once per frame
    void Update() 
    {
        //detectar presión del mouse:
        if(Input.GetButtonDown("Fire1")) {
            Shoot();
        }    
    }
    void Shoot() 
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            target tar = hit.transform.GetComponent<target>();
            //It wouldn't make an error, so we just check if it exist
            if(tar != null)
            {
                tar.DamageReceived(damage);
            }
        }
    }
}
