using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public enum BattleState { START, PLAYERTURN=-1,CINDERTURN=0,ARCHIBALDTURN=1,BALTHAZARTURN=2,DANIELLETURN=3, ENEMYTURN, WON, LOST }

public class BattleHandler : MonoBehaviour
{
    public GameObject enemyUnitPrefab;
    public GameObject enemyPlacements;

    public GameObject buttonAttack;
    public GameObject buttonTechnique;
    public GameObject buttonRun;

    public GameObject attackBox;
    public BattleState state;

    public List<Slider> playerActionBar;
    public List<Text> playerCurrentHP;
    public List<GameObject> playerUnitPrefab;

    Unit[] playerUnit;
    Unit[] enemyUnit;
    int enemyNum;
    bool selecting = false;
    GameObject currentAction = null;
    public GameObject firstButtonEnemy;

    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;
       // Cursor.visible = false;
        state = BattleState.START;
        enemyNum = 5;
        StartCoroutine(SetupBattle());
    }
    void Update()
    {
        //load in UI
        if (EventSystem.current.currentSelectedGameObject == null)
        {
            if(state == BattleState.PLAYERTURN)
                EventSystem.current.SetSelectedGameObject(buttonAttack);
            else if (state == (BattleState)0 || state == (BattleState)1 || state == (BattleState)2 || state == (BattleState)3)
                EventSystem.current.SetSelectedGameObject(firstButtonEnemy);
        }

        //TODO: Temporary controls
        switch (Input.inputString.ToUpper())
        {

            case ("Z"):
                if (playerActionBar[0].value == playerActionBar[0].maxValue)
                {
                    if (state == BattleState.CINDERTURN && currentAction != null)
                        StartCoroutine(EnemyPress(0));
                    else if (state == BattleState.PLAYERTURN)
                        StartCoroutine(ActionPress(0));
                }
                break;
            case ("X"):
                if (playerActionBar[1].value == playerActionBar[1].maxValue)
                {
                    if (state == BattleState.ARCHIBALDTURN && currentAction != null)
                        StartCoroutine(EnemyPress(1));
                    else if (state == BattleState.PLAYERTURN)
                        StartCoroutine(ActionPress(1));
                }
                break;
            case ("C"):
                if (playerActionBar[2].value == playerActionBar[2].maxValue)
                {
                    if (state == BattleState.BALTHAZARTURN && currentAction != null)
                        StartCoroutine(EnemyPress(2));
                    else if (state == BattleState.PLAYERTURN)
                        StartCoroutine(ActionPress(2));
                }
                break;
            case ("V"):
                if (playerActionBar[3].value == playerActionBar[3].maxValue)
                {
                    if (state == BattleState.DANIELLETURN && currentAction != null)
                        StartCoroutine(EnemyPress(3));
                    else if (state == BattleState.PLAYERTURN)
                        StartCoroutine(ActionPress(3));
                }
                break;


        }
    }
    void FixedUpdate()
    {
        //fills up player action bars
        int playerID = 0 ;
        foreach (Slider actionSlider in playerActionBar)
        {
            actionSlider.value += .02f;
            playerID++;
        }
    }
    
    //start battle
    IEnumerator SetupBattle()
    {
        enemyUnit = new Unit[enemyNum];
        
       for (int i = 0; i < enemyNum; i++)
        {
            enemyPlacements.transform.Find("Enemy"+(i+1)).gameObject.SetActive(true);
            enemyUnit[i] = Instantiate(enemyUnitPrefab,enemyPlacements.transform.Find("Enemy"+(i+1)).transform).GetComponent<Unit>();

        }
        firstButtonEnemy = enemyPlacements.transform.Find("Enemy1").gameObject;
        playerUnit = new Unit[playerUnitPrefab.Count];
        int count = 0;
        foreach (GameObject i in playerUnitPrefab) {
            playerUnit[count] = Instantiate(i).GetComponent<Unit>();
            count++;
            }

        count = 0;
        foreach (Slider actionSlider in playerActionBar)
        {
            actionSlider.maxValue = 4f - (float)(playerUnit[count].speed / 70f);
            count++;
        }

        count = 0;
        foreach (Text hpText in playerCurrentHP)
        {
            hpText.text = playerUnit[count].hp+"/"+playerUnit[count].constitution;
            count++;
        }

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonAttack);
        state = BattleState.PLAYERTURN;
        yield return null;
    }

    IEnumerator ActionPress(int unit)
    {

        if (EventSystem.current.currentSelectedGameObject == buttonAttack && !selecting)
        {
            state = (BattleState)unit;
            selecting = true;
            currentAction = EventSystem.current.currentSelectedGameObject;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(firstButtonEnemy);

        }
        else if(EventSystem.current.currentSelectedGameObject == buttonTechnique && !selecting)
        {
            //state = (BattleState)unit;
            selecting = true;
            currentAction = EventSystem.current.currentSelectedGameObject;

            GameObject.Find("TechniqueBox" + unit).SetActive(true);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(GameObject.Find("TechniqueBox" + unit).GetComponentInChildren<Button>().gameObject);
        }
        yield return null;
    }
    IEnumerator EnemyPress(int unit)
    {
        if (currentAction == buttonAttack)
        {
            GameObject enemy = EventSystem.current.currentSelectedGameObject;
            AttackEnemy(enemy);
            playerActionBar[unit].value = 0f;
            state = BattleState.PLAYERTURN;
            selecting = false;
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(currentAction);
            currentAction = null;
        }
        yield return null;
    }
    /*IEnumerator PlayerTurn(int playerTurn)
    {
        //state = BattleState.PLAYERTURN;
        // playerActionBar.maxValue = 5f - (float)(playerUnit.speed / 70f);
        state = (BattleState)playerTurn;
        attackBox.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButtonAttack);
        return null;
    }*/
    void EnemyTurn()
    {
        //state = BattleState.ENEMYTURN;
        playerActionBar[(int)state].value = 0f;
        state = BattleState.ENEMYTURN;
        attackBox.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(buttonAttack);
        
        //EnemyAttack();
    }
    public void RunButton()
    {
        Application.Quit();
    }

    public void AttackButton()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(firstButtonEnemy);
    }
    public void AttackEnemy(GameObject enemy)
    {
        Transform enemyT = enemy.transform.GetChild(0);
        
        //do damage
        if (playerUnit[(int)state].dealDamage(enemyT.GetComponent<Unit>()))
        {
            enemy.SetActive(false);
            bool flag = true;
            foreach (Transform child in GameObject.Find("EnemyPlacements").transform)
                if (child.gameObject.activeSelf)
                {
                    if (flag)
                        firstButtonEnemy = child.gameObject;
                    flag = false;
                }
            if(flag)
                state = BattleState.WON;
            //battleEnd();
        }
    }
}
