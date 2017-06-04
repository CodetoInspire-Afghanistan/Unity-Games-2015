using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class Stat
{   [SerializeField]
    private BarScript bar;
   [SerializeField]
    private float maxVal;

    [SerializeField]
    private float currentVal;

    public float CurrentValue
    {
        get
        {
            return currentVal;
        }
        set
        {
            this.currentVal = Mathf.Clamp(value, 0, MaxVal);

            bar.Value = currentVal;
        }
    }
    public float MaxVal
    {
        get
        {
            return maxVal;
        }
        set
        {
            bar.MaxValue = value;

            this.maxVal = value;
        }
    }

    public void Initialize()
    {
        this.MaxVal = maxVal;
        this.CurrentValue = currentVal;
    }
}

