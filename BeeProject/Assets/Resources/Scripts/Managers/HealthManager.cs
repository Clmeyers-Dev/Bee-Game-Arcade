using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private GameObject[] healthBars = new GameObject[3];

    public void LoseHealth()
    {
        for (int i = 0; i < healthBars.Length; i++)
        {
            if (healthBars[i].activeSelf)
            {
                healthBars[i].SetActive(false);
                return;
            }
        }
    }

    public void GainHealth()
    {
        for (int i = healthBars.Length - 1; i >= 0; i--)
        {
            if (!healthBars[i].activeSelf)
            {
                healthBars[i].SetActive(true);
                return;
            }
        }
    }

    public int GetNumberOfHealth()
    {
        int count = 0;

        for (int i = 0; i < healthBars.Length; i++)
        {
            if (healthBars[i].activeSelf)
            {
                count++;
            }
        }

        return count;
    }
}
