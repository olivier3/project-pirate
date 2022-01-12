using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBomb : MonoBehaviour
{
    private GameObject Bomb;
    private GameObject ObjectCharacter;
    private GameObject ObjectCharacterImage;

    // Start is called before the first frame update
    void Start()
    {
        Bomb = GameObject.Find("BombIgnite");
        ObjectCharacter = GameObject.Find("Character");
        ObjectCharacterImage = ObjectCharacter.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject bombIgnited = Instantiate(Bomb, transform.position, transform.rotation);
            if (ObjectCharacterImage.GetComponent<SpriteRenderer>().flipX)
                bombIgnited.GetComponent<Rigidbody2D>().AddForce(new Vector2(-2f, 5f), ForceMode2D.Impulse);
            else
                bombIgnited.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f, 5f), ForceMode2D.Impulse);
        }
    }
}
