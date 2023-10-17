using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class BuildableLocation : Location
{
    public int buildCost;
    public enum CostIncreaseMode{Add2,Times2}

    public CostIncreaseMode costIncreaseMode = CostIncreaseMode.Add2;
    private void OnMouseUpAsButton()
    {
        if (Money.i.spendMoney(buildCost))
        {
            Build();
            if (costIncreaseMode == CostIncreaseMode.Add2) buildCost += 2;
            else if (costIncreaseMode == CostIncreaseMode.Times2) buildCost *= 2;
        }
    }

    protected virtual void Build()
    {
        throw new NotImplementedException();
    }
}
