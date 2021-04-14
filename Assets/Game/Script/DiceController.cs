using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DiceController : MonoBehaviour
{
    public event Action OnRoll;
    [SerializeField] Button DicesButton;
    [SerializeField] GameObject[] dices;
    int DiceNo;
    bool canClick =true;

    private void Update()
    {
        DicesButton.onClick.AddListener(roll);
    }

    void roll()
    {
        if(canClick == true)
        {
            StartCoroutine(RollTheDice());
        }
    }

    IEnumerator RollTheDice()
    {
        canClick = false;
        DiceNo = UnityEngine.Random.Range(0, 5);
        dices[DiceNo].SetActive(true);
        yield return new WaitForSeconds(2.5f);
        dices[DiceNo].SetActive(false);
        OnRoll?.Invoke();
        canClick = true;
    }

    public int GetDiceNo()
    {
        return (DiceNo+1);
    }

}
