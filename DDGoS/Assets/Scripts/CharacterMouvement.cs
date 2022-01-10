using UnityEngine;

public class CharacterMouvement : MonoBehaviour
{
    private float JumpForce = 3f;
    public float MoveSpeed = 2f;
    private GameObject ObjectCharacter;
    private GameObject ObjectCharacterImage;
    private Rigidbody2D ObjectRigidbody;
    public bool isGrounded = true;

    // Start is called before the first frame update
    private void Start()
    {
        ObjectRigidbody = GetComponent<Rigidbody2D>();
        ObjectCharacter = GameObject.Find("Character");
        ObjectCharacterImage = ObjectCharacter.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.right;
            ObjectCharacterImage.GetComponent<SpriteRenderer>().flipX = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Time.deltaTime * MoveSpeed * Vector3.left;
            ObjectCharacterImage.GetComponent<SpriteRenderer>().flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void Jump()
    {
        if (isGrounded)
            ObjectRigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            Debug.Log("Trigger Enter");
            isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Square")
        {
            Debug.Log("Trigger Exit");
            isGrounded = false;
        }
    }
}
