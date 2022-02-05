using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyPlacements : Button
{
    public Button buttonAttack;
    public override Selectable FindSelectableOnDown()
    {
        if(base.FindSelectableOnDown() == GameObject.Find("Attack").GetComponent<Button>())
            return null;

        else
            return base.FindSelectableOnDown();
    }
}
