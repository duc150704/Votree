using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy : MonoBehaviour
{
    public Player player;
    [SerializeField] float moveSpeed;
    Vector2 dirctionToPlayer;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
        dirctionToPlayer = (-transform.position + player.transform.position).normalized;
        rb.velocity = dirctionToPlayer * moveSpeed * Time.fixedDeltaTime;

        if(dirctionToPlayer.x < 0 ){
            transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
        }
        else
        {
            transform.localScale = new Vector3(0.1f, 0.1f,0.1f);
        }
    }

}
