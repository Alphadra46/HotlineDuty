using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //UI VARIABLES
    [SerializeField] private TextMeshProUGUI ammoText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    //OBJECTS VARIABLES
    private AmmoManager ammoManager;
    private PlayerStats playerStats;
    
    // Start is called before the first frame update
    void Start()
    {
        playerStats = GameObject.FindWithTag("Player").GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoManager = GameObject.Find("Player").GetComponentInChildren<AmmoManager>();
        
        if (ammoManager != null)
        {
            ammoText.SetText(ammoManager.actualAmmo.ToString() + " / " + ammoManager.maxAmmo.ToString());
        }
        else
        {
            ammoText.text = "0";
        }
        lifeText.SetText(playerStats.life.ToString());
        scoreText.SetText(playerStats.score.ToString());
        
    }
}
