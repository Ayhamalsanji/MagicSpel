using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScpt : MonoBehaviour
{
    public GameObject FireBallPrefab;
    public float FireBallSpeed = 10f;
    public float fireRate = 0.3f;
    public int currentShots = 0;
    public bool ShootFireBall;
    public float nextFireTime = 0f;
    private bool CanCast = true;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (CanCast == true)
            {

                Instantiate(FireBallPrefab, this.transform.position, transform.rotation);
                CanCast = false;
                StartCoroutine(FireRate());

            }
        }
        
     


    }    
    IEnumerator FireRate()
    {

          yield return new WaitForSeconds(nextFireTime);
       CanCast = true;
        yield return null;
    }


   
}    
