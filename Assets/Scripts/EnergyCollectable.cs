using UnityEngine;

public class EnergyCollectable : MonoBehaviour
{
    [SerializeField] private EnergyType energyType = EnergyType.Motor;
    [SerializeField] private int energyAmount = 1;

    public EnergyType GetEnergyType()
    {
        return energyType;
    }

    public int GetEnergyAmount()
    {
        return energyAmount;
    }
}