using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public int lifePoints = 200;
    public ParticleSystem psDestroy;
    public bool destroyed = false;

    // Use this for initialization
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool IsDestroyed()
    {
        return destroyed;
    }
    public void Hit(int damage)
    {
        lifePoints -= damage;
        if (lifePoints <= 0)
        {
            SetDestroyed();
        }
    }
    void SetDestroyed()
    {
        FollowPath fp = GetComponent<FollowPath>();
        if (fp)
            fp.speed = 0;
       // ParticleSystem ps = (ParticleSystem)GameObject.Instantiate(psDestroy, transform);
        psDestroy.Play();
        
        destroyed = true;
        Destroy(gameObject,1);
    }
}
