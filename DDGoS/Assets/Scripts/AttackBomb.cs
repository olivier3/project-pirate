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

            bombIgnited.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            var position = bombIgnited.transform.position;
            position.y += 0.3f;

            if (ObjectCharacterImage.GetComponent<SpriteRenderer>().flipX)
            {
                position.x -= 0.6f;
                bombIgnited.GetComponent<Rigidbody2D>().AddForce(new Vector2(-3f, 4f), ForceMode2D.Impulse);
            }
            else
            {
                position.x += 0.6f;
                bombIgnited.GetComponent<Rigidbody2D>().AddForce(new Vector2(3f, 4f), ForceMode2D.Impulse);
            }

            bombIgnited.GetComponent<BombExplosion>().Ignited = true;

            bombIgnited.transform.position = position;
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            GameObject bombIgnited = Instantiate(Bomb, transform.position, transform.rotation);

            bombIgnited.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

            var position = bombIgnited.transform.position;

            if (ObjectCharacterImage.GetComponent<SpriteRenderer>().flipX)
            {
                position.x += 0.6f;
            }
            else
            {
                position.x -= 0.6f;
            }

            bombIgnited.GetComponent<BombExplosion>().Ignited = true;

            bombIgnited.transform.position = position;
        }
    }
}

