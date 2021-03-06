﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialog dialog;
    public Dialog secondDialog;
    private int times = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {

            if (times == 0)
            {
                times = 1;
                TriggerDialog(dialog);
            }
            else if (times == 1)
                TriggerDialog(secondDialog);
        }
    }
    public void TriggerDialog(Dialog dialog)
    {
        FindObjectOfType<MessageGenerator>().StartDialog(dialog);
    }   

}
