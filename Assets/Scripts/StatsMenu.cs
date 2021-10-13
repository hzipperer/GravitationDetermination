using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class StatsMenu : MonoBehaviour
{

    public TextMeshProUGUI[] stats;
    private Player player;

    public void updateStats()
    {
        player = GameObject.Find("PlayerInfo").GetComponent<Player>();
        stats[0].text = player.levelsBeaten.ToString();
        stats[1].text = player.timesPlayed.ToString();
        stats[2].text = player.numberOfDeaths.ToString();
        stats[3].text = player.numberOfFlips.ToString();
    }
}
