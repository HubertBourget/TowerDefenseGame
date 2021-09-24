using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int goldReward = 50;
    [SerializeField] int goldPenalty = 200;
    [SerializeField] GameObject enemyDestroyedSound;
    [SerializeField] GameObject alarmSound;

    BankScript bank;
    GameObject parentGameObject;

    void Start()
    {
        bank = FindObjectOfType<BankScript>();
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }

    public void RewardGold()
    {
        if(bank == null) {return;}
        bank.Deposit(goldReward);
        GameObject vfx = Instantiate(enemyDestroyedSound, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
    
    public void StealGold()
    {
        if(bank == null) {return;}
        bank.Withdraw(goldPenalty);
        GameObject vfx = Instantiate(alarmSound, transform.position, Quaternion.identity);
        vfx.transform.parent = parentGameObject.transform;
    }
}
