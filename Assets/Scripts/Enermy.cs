using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Player player;
    [SerializeField] float moveSpeed;
    Vector2 dirctionToPlayer;
    Rigidbody2D rb;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        Vector2 enermyPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        dirctionToPlayer = (playerPos - enermyPos).normalized;
        float spaceToPlayer = (playerPos - enermyPos).magnitude;
        if (spaceToPlayer < 2)
        {
            rb.velocity = Vector2.zero;
            anim.SetBool("isRunning" ,false);
        } else
        {
            rb.velocity = dirctionToPlayer * moveSpeed * Time.fixedDeltaTime;
            anim.SetBool("isRunning", true);
        }

        if (dirctionToPlayer.x < 0 ){
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        else
        {
            transform.localScale = new Vector3(0.1f, 0.1f,0.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player cham Enermy");
        }
    }
}
