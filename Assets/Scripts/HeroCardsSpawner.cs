using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCardsSpawner : MonoBehaviour
{
    public GameObject pHeroCard;
    public GameObject panelForSpawn;
    int countOfCards = 14;

    void Start()
    {
        for (int i = 0; i < countOfCards; i++)
        {
            Instantiate(pHeroCard, panelForSpawn.transform);
        }
        
    }
}
