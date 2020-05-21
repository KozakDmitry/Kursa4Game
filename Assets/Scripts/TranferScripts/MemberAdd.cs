using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemberAdd : MonoBehaviour
{
    [SerializeField]
    private GameObject Member;
    private Player player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("player entered");
            player = collision.collider.gameObject.GetComponent<Player>();
            player.squad.Add(Member);
            Debug.Log("Member added");
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
