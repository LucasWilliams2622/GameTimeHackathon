using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarnZone : MonoBehaviour
{
    public Transform warnZone;
    public Transform bulletRocKet;
    public Transform player;
    public PlaneMove planeMove;

    float timeDelay;
    void Start()
    {
        planeMove = GetComponent<PlaneMove>();
        timeDelay = 0;
    }

    void Update()
    {
        
        timeDelay -= Time.deltaTime;
        if (Mathf.Abs(transform.position.x - player.transform.position.x) <= 0.5f)
        {
            planeMove.speedRun = 0;
        }
        
        if(timeDelay <= 0 && planeMove.speedRun == 0)
        {
            TaoWarnZone();
            timeDelay = 4f;
        }
    }

    protected virtual void TaoWarnZone()
    {
        Transform warning = Instantiate(warnZone, new Vector3(transform.position.x, warnZone.transform.position.y, warnZone.transform.position.z), Quaternion.Euler(0, 0, 0));
        warning.gameObject.SetActive(true);
        Destroy(warning.gameObject,4f);
        Invoke("BulletAttack", 2f);
    }

    protected virtual void BulletAttack()
    {
        if (Mathf.Abs(transform.position.x - player.transform.position.x) > 0.5f)
        {
            planeMove.speedRun = 5;
        }
        Transform bullet = Instantiate(bulletRocKet, transform.position, Quaternion.Euler(0, 0, 0));
        bullet.gameObject.SetActive(true);
    }
}
