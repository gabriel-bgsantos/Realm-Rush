using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;
    
    public int CurrentBalance {get { return currentBalance; }}

    private void Awake() {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount) {
        currentBalance += Mathf.Abs(amount);
    }

    public void Withdraw(int amount) {
        currentBalance -= Mathf.Abs(amount);
        if(currentBalance < 0) {
            // should call method or sceneManager to handle the end of the level if it was not a prototype
            ReloadScene();
        }
    }

    private void ReloadScene() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
