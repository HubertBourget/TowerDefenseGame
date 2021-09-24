using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class BankScript : MonoBehaviour
{
    [SerializeField] int startingBalance = 450;
    int currentBalance;
    [SerializeField] GameObject objectPool;
    [SerializeField] GameObject environment;
    [SerializeField] GameObject loseSound;
    [SerializeField] GameObject defeatImage;
    public int CurrentBalance {get {return currentBalance;}}
    [SerializeField] TextMeshProUGUI displayBalance;
    GameObject parentGameObject;

void Awake() 
{
    currentBalance = startingBalance;
    UpdateDisplay();
    parentGameObject = GameObject.FindWithTag("SpawnAtRuntime");
}

public void Deposit(int amount)
{
    currentBalance += Mathf.Abs(amount);
    UpdateDisplay();
}
public void Withdraw(int amount)
{
    currentBalance -= Mathf.Abs(amount);
    UpdateDisplay();

    if(currentBalance <0)
    {
    DisplayEndGameScreen();
    }
}
void UpdateDisplay()
{
    displayBalance.text = "Gold: " + currentBalance;
}
void DisplayEndGameScreen()
{
    GameObject sfx = Instantiate(loseSound, transform.position, Quaternion.identity);
    sfx.transform.parent = parentGameObject.transform;
    objectPool.SetActive(false);
    environment.SetActive(false);
    displayBalance.gameObject.SetActive(false);
    Tower[] towerArray = FindObjectsOfType<Tower>();
    foreach(Tower tower in towerArray)
    {
        tower.gameObject.SetActive(false);
    }
    defeatImage.SetActive(true);    
}
}
