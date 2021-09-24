using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    [SerializeField] int cost = 75;
    [SerializeField] float buildDelay = 1f;
    [SerializeField] GameObject craftingSound;
    GameObject parentGameObject;
    void Awake() 
    {
        parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
    }
    void Start() 
    {
        StartCoroutine(Build());
    }
    public bool CreateTower(Tower tower, Vector3 position)
    {
        BankScript bank = FindObjectOfType<BankScript>();
        if(bank == null){return false;}


        if(bank.CurrentBalance >= cost)
        {
        Instantiate(tower.gameObject, position, Quaternion.identity);
        bank.Withdraw(cost);
        return true;
        }
        return false;
    }
    IEnumerator Build()
    {
        GameObject sfx = Instantiate(craftingSound, transform.position, Quaternion.identity);
        sfx.transform.parent = parentGameObject.transform;
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(false);
            }
        }

        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSeconds(buildDelay);
            foreach(Transform grandchild in child)
            {
                grandchild.gameObject.SetActive(true);
            }
        }
    }
}
