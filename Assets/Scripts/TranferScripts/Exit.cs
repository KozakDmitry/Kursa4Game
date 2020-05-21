using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    [SerializeField]
    public GameObject gm;

    // Start is called before the first frame update
    void Start()
    {

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gm.SetActive(true);

    }

    public void goToSurface()
    {
        Application.Quit();
    }

    public void goToDungeon()
    {
        SceneManager.LoadScene("Dungeon");
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
