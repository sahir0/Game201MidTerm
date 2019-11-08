using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseShoot : MonoBehaviour
{
    public GameObject crosshair;
    private Vector3 target;
    public GameObject player;
    public float bulletSpeed = 60f;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);

        Vector3 difference = target = player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if (Input.GetMouseButtonDown(0))
        {
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            fireBullet(direction, rotationZ);
        }
    }
    void fireBullet(Vector2 direction,float rotationZ)
    {
        GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject(0);
        bullet.SetActive(true);
        bullet.transform.position = player.transform.position;
        bullet.transform.rotation = Quaternion.Euler(0.0f,0.0f,rotationZ);
        bullet.GetComponent<Rigidbody2D>().velocity = direction *bulletSpeed;
    }
}
