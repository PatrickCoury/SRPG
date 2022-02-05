using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    public BattleHandler handler;
    BattleState state;
    // Update is called once per frame
    void Update()
    {
        this.transform.position = EventSystem.current.currentSelectedGameObject.transform.position;
        this.transform.position += new Vector3(-.75f, 0, 0);
        state = handler.state;
        switch ((int)state)
        {
            case 0:
                this.GetComponent<Image>().color = handler.playerUnitPrefab[0].GetComponent<SpriteRenderer>().color;
                break;
            case 1:
                this.GetComponent<Image>().color = handler.playerUnitPrefab[1].GetComponent<SpriteRenderer>().color;
                break;
            case 2:
                this.GetComponent<Image>().color = handler.playerUnitPrefab[2].GetComponent<SpriteRenderer>().color;
                break;
            case 3:
                this.GetComponent<Image>().color = handler.playerUnitPrefab[3].GetComponent<SpriteRenderer>().color;
                break;
            default:
                this.GetComponent<Image>().color = new Color(1,1,1);
                break;
        }
    }
}
