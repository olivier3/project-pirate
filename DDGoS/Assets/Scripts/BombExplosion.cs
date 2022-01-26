using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public bool Ignited = false;

    private float Timer = 3f;

    // Update is called once per frame
    void Update()
    {
        if (Ignited)
        {
            Timer -= Time.deltaTime;

            if (Timer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
