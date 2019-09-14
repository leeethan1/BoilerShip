using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public float moveSpeed = 3f;
    public Vector2 jumpHeight;
    float velX;
    float velY;
    bool facingRight = true;
    Rigidbody2D rigBody;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rigBody.velocity.y;
        rigBody.velocity = new Vector2(velX * moveSpeed, velY);
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))  //makes player jump
        {
            GetComponent<Rigidbody2D>().AddForce(jumpHeight, ForceMode2D.Impulse);
        }
    }

    void LateUpdate() {
        Vector3 localScale = transform.localScale;
        if (velX > 0) {
            facingRight = true;
        } else if(velX < 0 ){
            facingRight = false;
        }
        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0))){
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }
}
