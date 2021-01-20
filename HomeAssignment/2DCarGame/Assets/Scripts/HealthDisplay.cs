using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    Text healthText;
    Player p;

    void Start()
    {
        healthText = GetComponent<Text>();
        p = FindObjectOfType<Player>();
    }

    void Update()
    {
        healthText.text = p.GetHealth().ToString();
    }
}
