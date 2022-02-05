using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy3Logic : MonoBehaviour
{
    //fixes a Navigation issue
    public GameObject enemyPlacements;
    void Start()
    {
        Navigation n = this.GetComponent<Button>().navigation; 
        n.selectOnUp = enemyPlacements.transform.Find("Enemy1").GetComponent<Button>();
        if (enemyPlacements.transform.Find("Enemy6").gameObject.activeSelf)
            n.selectOnRight = enemyPlacements.transform.Find("Enemy6").GetComponent<Button>();
        else if (enemyPlacements.transform.Find("Enemy4").gameObject.activeSelf)
            n.selectOnRight = enemyPlacements.transform.Find("Enemy4").GetComponent<Button>();
        else if (enemyPlacements.transform.Find("Enemy5").gameObject.activeSelf)
            n.selectOnRight = enemyPlacements.transform.Find("Enemy5").GetComponent<Button>();
        else
            n.selectOnRight = null;
        this.GetComponent<Button>().navigation = n;
    }
    void Update()
    {
        if (!this.GetComponent<Button>().navigation.selectOnUp.gameObject.activeSelf)
        {
            Navigation n = this.GetComponent<Button>().navigation;
            if (enemyPlacements.transform.Find("Enemy2").gameObject.activeSelf)
                n.selectOnUp = enemyPlacements.transform.Find("Enemy2").GetComponent<Button>();

            else if (enemyPlacements.transform.Find("Enemy4").gameObject.activeSelf)
                n.selectOnUp = enemyPlacements.transform.Find("Enemy4").GetComponent<Button>();

            else if (enemyPlacements.transform.Find("Enemy5").gameObject.activeSelf)
                n.selectOnUp = enemyPlacements.transform.Find("Enemy5").GetComponent<Button>();
            
            else
                n.selectOnUp = null;

            this.GetComponent<Button>().navigation = n;
        }
        if (!this.GetComponent<Button>().navigation.selectOnRight.gameObject.activeSelf)
        {
            Navigation n = this.GetComponent<Button>().navigation;
            if (enemyPlacements.transform.Find("Enemy4").gameObject.activeSelf)
                n.selectOnUp = enemyPlacements.transform.Find("Enemy4").GetComponent<Button>();

            else if (enemyPlacements.transform.Find("Enemy5").gameObject.activeSelf)
                n.selectOnUp = enemyPlacements.transform.Find("Enemy5").GetComponent<Button>();

            else
                n.selectOnUp = null;

            this.GetComponent<Button>().navigation = n;
        }
        
    }
}
