using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    Vector3 playerBulletPos = Vector3.zero;
    public GameObject playerBullet;
    private bool canShoot = true;
    private Coroutine shootDelay;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canShoot)
        {
            canShoot = false;
            if (shootDelay == null)
            {
                shootDelay = StartCoroutine(setCanShoot());
            }
            shootBullet();
        }
    }

    IEnumerator setCanShoot()
    {
        yield return new WaitForSeconds(1f);

        canShoot = true;
        shootDelay = null;
    }

    public void shootBullet()
    {
        GameObject newPlayerBullet = Instantiate(playerBullet, new Vector3(transform.position.x, transform.position.y + 0.5f, transform.position.z), Quaternion.identity);
        MoveBullet moveBullet = newPlayerBullet.GetComponent<MoveBullet>();
        moveBullet.Initialize(Vector2.up, new PlayerBulletEffect());
    }
}
