using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSaving : MonoBehaviour
{
    [SerializeField]
    private SavingManager savingManager;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)){
            savingManager.SaveGame();
        }
        if (Input.GetKeyDown(KeyCode.L)){
            savingManager.LoadGame();
        }
        if (Input.GetKeyDown(KeyCode.R)){
            savingManager.ResetGame();
        }
    }
}
