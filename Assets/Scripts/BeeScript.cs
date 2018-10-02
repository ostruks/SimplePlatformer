using UnityEngine;

public class BeeScript : MonoBehaviour {

    public float speed = 1.0f;
    bool facialRight = false; //направление взгляда Пчёл
                              // Use this for initialization
    bool temp = false;
    void Start()
    {
    }

    private void Flip()
    {
        facialRight = !facialRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; //Вокруг оси
        transform.localScale = theScale;
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (temp)
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "rightSide") //collision.gameObject.name.Equals("Saw")
        {
            Flip();
            temp = true;
        }
        if (collision.gameObject.name == "leftSide") //collision.gameObject.name.Equals("Saw")
        {
            Flip();
            temp = false;
        }
    }
}
