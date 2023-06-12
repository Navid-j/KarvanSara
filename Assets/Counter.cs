using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    public Button crewAddBtn;
    public Button cheffAddBtn; 
    public Button playerAddBtn;

    public Button crewRemoveBtn;
    public Button cheffRemoveBtn;
    public Button playerRemoveBtn;

    public int crewTasks = 0;
    public int cheffTasks = 0;
    public int playerTasks = 0;

    public float crewCurrentTime = 0;
    public float cheffCurrentTime = 0;
    public float playerCurrentTime = 0;

    public Text crewItemstxt;
    public Text cheffItemstxt;
    public Text playerItemstxt;

    public Animator AnimPower;
    public Animator cheffAnimPower;
    public Animator playerAnimPower;

    // Start is called before the first frame update
    void Start()
    {
        crewAddBtn.onClick.AddListener(() => listenerAddCrewTasks());
        cheffAddBtn.onClick.AddListener(() => listenerAddCheffTasks());
        playerAddBtn.onClick.AddListener(() => listenerAddPlayerTasks());

        crewRemoveBtn.onClick.AddListener(() => listenerRemoveCrewTasks());
        cheffRemoveBtn.onClick.AddListener(() => listenerRemoveCheffTasks());
        cheffRemoveBtn.onClick.AddListener(() => listenerRemovePlayerTasks());

        checkTasks();
    }

    // Update is called once per frame
    void Update()
    {
        updateTasks();
    }

    //Add Crew Task
    public void listenerAddCrewTasks()
    {
        crewTasks++;
        updateTasks();
        if (!(crewCurrentTime > 0))
            crewCurrentTime = Time.time;
    }

    //Add Cheff Task
    public void listenerAddCheffTasks()
    {
        cheffTasks++;
        updateTasks();
        if (!(cheffCurrentTime > 0))
            cheffCurrentTime = Time.time;
    }

    //Add Player Task
    public void listenerAddPlayerTasks()
    {
        playerTasks++;
        updateTasks();
        if (!(playerCurrentTime > 0))
            playerCurrentTime = Time.time;
    }

    //Remove crew Task
    public void listenerRemoveCrewTasks()
    {
        crewTasks--;
        updateTasks();
    }

    //Remove cheff Task
    public void listenerRemoveCheffTasks()
    {
        cheffTasks--;
        updateTasks();
    }

    //Remove Player Task
    public void listenerRemovePlayerTasks()
    {
        playerTasks--;
        updateTasks();
    }

    //Tasks TextView Update
    public void updateTasks()
    {

        PlayerPrefs.SetInt("CrewTasks", crewTasks);
        PlayerPrefs.SetInt("CheffTasks", cheffTasks);
        PlayerPrefs.SetInt("PlayerTasks", playerTasks);
        PlayerPrefs.Save();

        crewItemstxt.text = crewTasks.ToString();
        cheffItemstxt.text = cheffTasks.ToString();
        playerItemstxt.text = playerTasks.ToString();

        AnimPower.SetInteger("Tasks", crewTasks);
        cheffAnimPower.SetInteger("CheffTasks", cheffTasks);
        playerAnimPower.SetInteger("PlayerTasks", playerTasks);

        checkTasks();
    }

    //Check Tasks and set Timer
    public void checkTasks()
    {
        if (crewTasks > 0)
        {
            while (Time.time - crewCurrentTime > 5f)
            {
                crewTasks--;
                //Debug.Log("Tasks = " + crewTasks);
                crewCurrentTime = Time.time;

                if (crewTasks == 0)
                    break;
            }


        }

        if (cheffTasks > 0)
        {
            while (Time.time - cheffCurrentTime > 5f)
            {
                cheffTasks--;
                //Debug.Log("Tasks = " + crewTasks);
                cheffCurrentTime = Time.time;

                if (cheffTasks == 0)
                    break;
            }


        }

        if (playerTasks > 0)
        {
            while (Time.time - playerCurrentTime > 5f)
            {
                playerTasks--; 
                //Debug.Log("Tasks = " + playerTasks);
                playerCurrentTime = Time.time;

                if (playerTasks == 0)
                    break;
            }


        }
    }

}
