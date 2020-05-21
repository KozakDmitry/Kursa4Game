using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartingBattle : MonoBehaviour
{
    private AudioSource audio;
    public AudioClip battlesong;
    [SerializeField]
    private GameObject managerBattle;
    private BattleScript bs;
    private Player pl;
    [SerializeField]
    private List<GameObject> enemies;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        bs = managerBattle.GetComponent<BattleScript>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            pl = collision.gameObject.GetComponent<Player>();
            audio.clip = battlesong;
            audio.Play();
            bs.StartBattle(pl.squad, enemies);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
