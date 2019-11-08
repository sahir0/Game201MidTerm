using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    int speed = 10;

	
	private void OnEnable()
    {
        this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
    }
    void OnBecomeInvisible()
    {
        this.gameObject.SetActive(false);
    }
	
}
