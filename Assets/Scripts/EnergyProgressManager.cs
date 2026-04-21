using UnityEngine;
using UnityEngine.UI;

public class EnergyProgressManager : MonoBehaviour
{
    [SerializeField] private int motorTarget = 10;
    [SerializeField] private int naturalTarget = 10;

    [SerializeField] private int motorCurrent = 0;
    [SerializeField] private int naturalCurrent = 0;

    [SerializeField] private Slider motorSlider;
    [SerializeField] private Slider naturalSlider;
    [SerializeField] private GameManager gameManager;

    private bool hasEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        SetupSliders();
        UpdateSliders();
    }

    public void AddEnergy(EnergyType energyType, int amount)
    {
        if (hasEnded)
        {
            return;
        }

        if (energyType == EnergyType.Motor)
        {
            motorCurrent = Mathf.Min(motorCurrent + amount, motorTarget);
        }
        else if (energyType == EnergyType.Natural)
        {
            naturalCurrent = Mathf.Min(naturalCurrent + amount, naturalTarget);
        }

        UpdateSliders();
        CheckWinCondition();
    }

    void SetupSliders()
    {
        if (motorSlider != null)
        {
            motorSlider.minValue = 0;
            motorSlider.maxValue = motorTarget;
        }

        if (naturalSlider != null)
        {
            naturalSlider.minValue = 0;
            naturalSlider.maxValue = naturalTarget;
        }
    }

    void UpdateSliders()
    {
        if (motorSlider != null)
        {
            motorSlider.value = motorCurrent;
        }

        if (naturalSlider != null)
        {
            naturalSlider.value = naturalCurrent;
        }
    }

    void CheckWinCondition()
    {
        if (motorCurrent >= motorTarget)
        {
            hasEnded = true;

            if (gameManager != null)
            {
                gameManager.EndGame(GameResult.Technological);
            }
        }
        else if (naturalCurrent >= naturalTarget)
        {
            hasEnded = true;

            if (gameManager != null)
            {
                gameManager.EndGame(GameResult.Natural);
            }
        }
    }
}