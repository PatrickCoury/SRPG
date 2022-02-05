using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Techniques : MonoBehaviour
{
    BattleHandler handler;
    void setEnemy()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(handler.firstButtonEnemy);
    }

    void Taunt()
    {
        handler.playerUnitPrefab[0].GetComponent<Unit>().targetPriority = 100;
    }

    void Parry()
    {
        
    }
}
