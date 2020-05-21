using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageGenerator : MonoBehaviour
{
    public Text nameText;
    public Text dialogText;
    private Queue<string> sentenses;
    [SerializeField]
    private GameObject canvas;
    [SerializeField]
    private GameObject choose1;
    [SerializeField]
    private GameObject choose2;
    private int choose;
    // Start is called before the first frame update
    void Start()
    {
        sentenses = new Queue<string>();
    }

    public void StartDialog(Dialog dialog, int choise = 0)
    {
        if (choise !=0)
            choose = choise;
        Time.timeScale = 0f;
        canvas.SetActive(true);
        nameText.text = dialog.name;

        sentenses.Clear();

        foreach(string sentense in dialog.sentenses)
        {
            sentenses.Enqueue(sentense);
        }
        DisplayNextSentense();
    }


    IEnumerator TypeSentense(string sentense)
        {

            dialogText.text = "";
        foreach(char letter in sentense.ToCharArray())
        {
            dialogText.text += letter;
            yield return null;
        }
    }
    public void DisplayNextSentense()
    {
        StopAllCoroutines();
        if (sentenses.Count == 0)
        {
            EndDialog();
            return;
        }

        string sentense = sentenses.Dequeue();
        StartCoroutine(TypeSentense(sentense));


    }

    public void EndDialog()
    {
        canvas.SetActive(false);
        Time.timeScale = 1f;
        if (choose == 1)
        {
            choose1.SetActive(true);
        }
        else if(choose == 2)
        {
            choose2.SetActive(true);
        }
        choose = 0;
    }

}
