using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    [SerializeField]
    private GameObject character;
    public Slider slider;
    private BattleMember pb;
    public void SetMaxHealth()
    {
        slider.maxValue = pb.maxHealth; 
    }
    // Start is called before the first frame update
    void Start()
    {
        pb = character.GetComponent<BattleMember>();
        SetMaxHealth();
    }

    public void SetHeatlh()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        slider.value = pb.health;
    }
}
