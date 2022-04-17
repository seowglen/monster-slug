using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;
    [SerializeField]
    private float jumpForce = 11f;

    private Rigidbody2D myBody;
    private SpriteRenderer sr;
    private Animator anim;

    private float movementX;
    private string WALK_ANIMATION = "Walk";

    private void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("Started");
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        AnimatePlayer();
    }

    void PlayerMoveKeyboard() {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }

    void AnimatePlayer() {
        // Moving Right
        if(movementX > 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        } else if (movementX < 0) {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        } else {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }
}
