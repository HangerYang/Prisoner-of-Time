using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Judge : MonoBehaviour
{

    public static int EnemyNumber = 1;
    public static bool PlayerWin = false;
    public static bool Onetime = true;
    private float Timer = 0f;
    private int TimeShown;
    [SerializeField]private Text TimeYouHave;
    [SerializeField] private Text GoBackToYourBody;

    void Start()
    {
       EnemyNumber = GameObject.FindGameObjectsWithTag("Guard").Length;
    }

    void Update()
    {

        if (Global_Variables.Moves > 0)
        {
            TimeYouHave.enabled = true;
            GoBackToYourBody.enabled = true;
            Timer += Time.deltaTime;
            TimeShown = Mathf.RoundToInt(15 - Timer);
            TimeYouHave.text = TimeShown.ToString() + "S";
        }
        else
        {
            GoBackToYourBody.enabled = false;
            TimeYouHave.enabled = false;
        }

        Win();

    }

    

    private void Win()
    {
        if (EnemyNumber < 0.1f )
        {
            if (Onetime)
            {
                StartCoroutine(JudgeDecision());
                Onetime = false;
            }
        }
       

    }
    IEnumerator JudgeDecision()
    {
        yield return new WaitForSeconds(7f);

        if (!PlayerScript.Dead)
        {
            PlayerWin = true;
            Debug.Log("Win");
        }
    }
}
