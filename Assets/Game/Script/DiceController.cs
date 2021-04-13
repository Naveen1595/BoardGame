using System;
using System.Collections;
using UnityEngine;

public class DiceController : MonoBehaviour
{
    public event Action OnRoll;

    [SerializeField] GameObject[] dices;
    int DiceNo;
    private void OnMouseDown()
    {
        StartCoroutine(RollTheDice());
    }

    IEnumerator RollTheDice()
    {
        DiceNo = UnityEngine.Random.Range(1, 6);
        dices[DiceNo].SetActive(true);
        yield return new WaitForSeconds(0.5f);
        dices[DiceNo].SetActive(false);
        OnRoll?.Invoke();
    }

    public int GetDiceNo()
    {
        return DiceNo;
    }

}
