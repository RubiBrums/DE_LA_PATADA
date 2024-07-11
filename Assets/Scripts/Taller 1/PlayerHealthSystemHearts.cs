using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealthSystemHearts : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] int currentHealth;
    [SerializeField] UnityEvent onPlayerDeath;
    [SerializeField] Transform hearthContainer;
    [SerializeField] SingleHearthControl singleHearth;

    [SerializeField] List<SingleHearthControl> currentHealthVisual;

    public void Start()
    {
        currentHealth = health;
        UpdateCurrentHeath();
    }

    public void Hurt(int damage)
    {
        currentHealth -= damage;
        UpdateCurrentHeath();
        if (currentHealth <= 0)
        {
            onPlayerDeath.Invoke();
        }
    }

    public void Heal(int damage)
    {
        currentHealth += damage;
        UpdateCurrentHeath();
        
    }

    void UpdateCurrentHeath()
    {
        if(currentHealthVisual.Count == 0)
        {
            for (int i = 0; i < health/2; i++)
            {
                SingleHearthControl sh = Instantiate(singleHearth);
                sh.transform.SetParent(hearthContainer);
                sh.gameObject.SetActive(true);
                sh.transform.localScale = Vector3.one;
                currentHealthVisual.Add(sh);
            }
        }
        int current = currentHealth;
        for (int i = 0; i < health / 2; i++)
        {
            if (current <= 1)
            {
                if(current <= 0)
                {
                    current = 0;
                }
                currentHealthVisual[i].UpdateCurrentPiece(current);
                
            }
            current -= 2;
        }
    }
}
