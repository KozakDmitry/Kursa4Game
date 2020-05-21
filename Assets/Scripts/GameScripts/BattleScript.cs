using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Linq;
using UnityEngine.Animations;
using System.Runtime.InteropServices;
using System.Threading;

public class BattleScript : MonoBehaviour
{

    //[SerializeField]
    //public List<BattleMember> enemies;
    //[SerializeField]
    //public List<BattleMember> players;
    [SerializeField]
    private List<GameObject> enemiesG;
    [SerializeField]
    private List<GameObject> playersG;
    int i = 0, k = 0;

    public GameObject playCam;
    public GameObject battleCam;
    public GameObject battleImage;
    public GameObject spells;
    private SpellHud hud;
    public Spell spell;

    [SerializeField]
    private Player player;

    BattleMember att;
    BattleMember def;
    Animator anim1;
    Animator anim2;
    public int action=1;
    private bool turnPlayer = true;
    private bool turnEnemy = false;

    [SerializeField]
    private GameObject victoryWindow;
    [SerializeField]
    private GameObject positionBattle;
    private GameObject movingPerson;
    private bool doingSetup = true;
    private bool wait = false;
    public void Battle()
    {
       
    }
    public void StartBattle(List<GameObject> players, List<GameObject> enemies)
    {
        playCam.SetActive(false);
        battleCam.SetActive(true);  
        battleImage.SetActive(true);
        spells.SetActive(true);
        //playersG = players;
        //Debug.Log(players.Count + " players count");
            
        //enemiesG = enemies;
        //Debug.Log(enemies.Count + " enemies count");

        doingSetup = false;
        ////SpawnPlayers();
    }
    // Start is called before the first frame update
    void Start()
    {
        hud = GetComponent<SpellHud>();
        
        
    }
    void CheckDeath(BattleMember def,GameObject defender)
    {
        if (def.health <= 0)
        {
            if (turnPlayer)
            {
                enemiesG.Remove(defender);
                k--;
            }
            else    
            {
                if (turnEnemy)
                {
                    playersG.Remove(defender);
                    i--;
                }
            }
        }
    }

    void Strike(BattleMember att, Animator anim1, GameObject defender)
    {
        def = defender.GetComponent<BattleMember>();
        anim2 = defender.GetComponent<Animator>();
        anim1.SetTrigger("Attack");
        if (((att.accuracy - def.agility / 2) - Random.Range(0, 10)) > 0)
        {
            def.health -= att.damage - def.defence / 2;
            CheckDeath(def,defender);
        }
   
    }
    

    //void SpawnPlayers()
    //{
    //    int dist = 1;
    //    foreach (GameObject player in playersG)
    //    {
    //        GameObject a = Instantiate(player) as GameObject;
    //        att = a.GetComponent<BattleMember>();
    //        att.CountStats();
    //        a.transform.position = new Vector2(positionBattle.transform.position.x + dist, positionBattle.transform.position.y + 1);
    //        dist++;
    //    }
    //    foreach(GameObject enemy in enemiesG)
    //    {
    //        GameObject a = Instantiate(enemy) as GameObject;
    //        att = a.GetComponent<BattleMember>();
    //        att.CountStats();
    //        a.transform.position = new Vector2(positionBattle.transform.position.x + dist, positionBattle.transform.position.y + 1);
    //        dist++;
    //    }

    //}

    IEnumerator WaitMore()
    {
        yield return new WaitForSecondsRealtime(2f);
    }   
 
    void ChangePosition(GameObject attacker, GameObject defender)
    {
        def = defender.GetComponent<BattleMember>();
        if (def.mood == 1)
        {
            Vector3 x;
            x = attacker.transform.position;
            attacker.transform.position = defender.transform.position;
            defender.transform.position = x;
        }
    }

    public void SetAction(int i)
    {
        action = i;
    }
    
    GameObject FindObj()
    {
        int layer = 1 << LayerMask.NameToLayer("Clickable");
        var mousePosition3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var origin = new Vector2(mousePosition3D.x, mousePosition3D.y);
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f, layer);
        if (hit.collider != null)
        {
            GameObject get = hit.collider.gameObject;
            return get;
        }
        else
            return null;
    }

    void CastSpell(BattleMember att, Animator anim1)
    {
        anim1.SetTrigger("Spell");
        att.Spell(enemiesG);
        
    }

    void Victory()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!doingSetup)
        {

            if (turnPlayer)
            {
                if (i == playersG.Count || i < 0)
                    i = 0;
                movingPerson = playersG[i];
                att = movingPerson.GetComponent<BattleMember>();;
                anim1 = movingPerson.GetComponent<Animator>();
                spell = movingPerson.GetComponent<Spell>();
                for (int r = 0; r < spell.A_Attribute.sprites.Count(); r++)
                    hud.icons[r].sprite = spell.A_Attribute.sprites[r];
                if (Input.GetMouseButtonDown(0) && FindObj()!=null)
                {


                    if (action == 1 && Input.GetMouseButtonDown(0))
                    {
                        Strike(att, anim1, FindObj());
                    }

                    if (action == 2 && Input.GetMouseButtonDown(0) && att.couldown == 0)
                    {
                        CastSpell(att, anim1);
                    }

                    if (action == 3 && Input.GetMouseButtonDown(0))
                    {

                    }

                    if (action == 4 && Input.GetMouseButtonDown(0))
                    {
                        ChangePosition(movingPerson, FindObj());
                    }
                    turnPlayer = false;
                    turnEnemy = true;
                    i++;
                    StartCoroutine(WaitMore());
                    wait = true;
                }

            }
            if (enemiesG.Count == 0 || playersG.Count == 0)
            {
                battleCam.SetActive(false);
                playCam.SetActive(true);
                spells.SetActive(false);
                if (playersG.Count == 0)
                    Application.Quit();
                if (enemiesG.Count == 0)
                {
                    victoryWindow.SetActive(true);
                    Invoke("Victory", 3f);
                    player.squad = playersG;
                }
            }
            if (turnEnemy && wait)
                {
                if (k == enemiesG.Count)
                    k = 0;
                movingPerson = enemiesG[k];
                att = movingPerson.GetComponent<BattleMember>();
                anim1 = movingPerson.GetComponent<Animator>();
                if (att.couldown == 0)
                {
                    CastSpell(att,anim1);
                    att.couldown = 5;
                }
                else
                    Strike(att, anim1, playersG[Random.Range(0, playersG.Count-1)]);
                turnPlayer = true;
                turnEnemy = false;
                        k++;
                wait = false;
                }
            Debug.Log(enemiesG.Count);
           
        }
    }
}
