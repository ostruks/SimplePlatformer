using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour {

    public float maxspeed = 10f;
    public float move = 1f;
    bool facialRight = false; //направление взгляда Винни
    public float jumpForce = 550f;
    private float spawnX, spawnY;
    //
    public Transform groundCheck; //это объект из нижней части нашего персонажа для проверки есть ли земля под ногами
    public float groundRadius = 0.2f; //радиу круга относительно groundRadius внутри которого мы ищем землю
    public LayerMask whatIsGround; //это маска слоя, которая определяет, что такое земля - с чем именно искать столкновение
    public bool grounded; //определяет стоим ли мы сейчас на земле

    //
    void Start() //логика Form.Load();
    {
        spawnX = transform.position.x; //transform - gameObject - это Винни
        spawnY = transform.position.y;
    }

    void FixedUpdate()
    {
        move = Input.GetAxisRaw("Horizontal");
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
        if (MainCameraScript.Live == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Flip()
    {
        facialRight = !facialRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //Вокруг оси
        transform.localScale = theScale;
    }

    void Update () {
        Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.velocity = new Vector2(move * maxspeed, rigidbody2D.velocity.y);
        if (facialRight && move < 0)
        {
            Flip();
        }
        else if(!facialRight && move > 0)
        {
            Flip();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded || Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpForce));
        }
	}

    //
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "endLevel") //collision.gameObject.name.Equals("Saw")
        {
            SceneManager.LoadScene("Scene01");
        }

        if (collision.gameObject.name == "endLevel1") //collision.gameObject.name.Equals("Saw")
        {
            SceneManager.LoadScene("Scene02");
        }

        if (collision.gameObject.name == "endLevel2") //collision.gameObject.name.Equals("Saw")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "saw" || collision.gameObject.name == "dieCollider")
        {
            MainCameraScript.Live--;
            transform.position = new Vector3(spawnX, spawnY, transform.position.z);
        }

        if (collision.gameObject.name == "bee")
        {
            MainCameraScript.Live--;
            transform.position = new Vector3(spawnX, spawnY, transform.position.z);
        }

        if (collision.gameObject.name == "fireball")
        {
            MainCameraScript.Live--;
            transform.position = new Vector3(spawnX, spawnY, transform.position.z);
        }

        if (collision.gameObject.tag == "star")
        {
            MainCameraScript.Score++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "hamburger")
        {
            MainCameraScript.Live++;
            Destroy(collision.gameObject);
        }
    }
    //

    private void OnGUI()
    {
        GUI.Box(new Rect(0, 0, 100, 100), "Vinnie");
        GUI.Label(new Rect(0, 20, 100, 100), "Star: " + MainCameraScript.Score);
        GUI.Label(new Rect(0, 40, 100, 100), "Live: " + MainCameraScript.Live);
    }
}
