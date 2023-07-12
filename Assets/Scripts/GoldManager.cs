using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GoldManager : MonoBehaviour
{
    //connect gold to student account
    public int gold;
    public TMP_Text goldCounter;

    public void EditGold(int changeInGold)
    {
        gold -= changeInGold;
        goldCounter.text = gold.ToString() + " Gold";
    }
}
