using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bender : Character
{
    public bool CanAirBend { get; private set; }

    public bool CanEarthBend { get; private set; }

    public bool CanFireBend { get; private set; }

    public bool CanWaterBend { get; private set; }

    public void BendAir() => ListenToAirBending();
    public void BendEarth() => ListenToEarthBending();
    public void BendFire() => ListenToFireBending();
    public void BendWater() => ListenToWaterBending();

    protected void enableAirBending() => CanAirBend = true;

    protected void disableAirBending() => CanAirBend = false;

    protected void enableEarthBending() => CanEarthBend = true;

    protected void disableEarthBending() => CanEarthBend = false;

    protected void enableFireBending() => CanFireBend = true;

    protected void disableFireBending() => CanFireBend = false;

    protected void enableWaterBending() => CanWaterBend = true;

    protected void disableWaterBending() => CanWaterBend = false;

    protected void BecomeAvatar()
    {
        enableAirBending();
        enableEarthBending();
        enableFireBending();
        enableWaterBending();
    }

    protected void BecomeOzai()
    {
        disableAirBending();
        disableEarthBending();
        disableFireBending();
        disableWaterBending();
    }

    private void ListenToAirBending()
    {
        if(!CanAirBend)   
        {
            return;
        }

        OnAirBending();
    }

    private void ListenToEarthBending()
    {
        if(!CanAirBend)   
        {
            return;
        }

        OnEarthBending();
    }

    private void ListenToFireBending()
    {
        if(!CanAirBend)   
        {
            return;
        }

        OnFireBending();
    }

    private void ListenToWaterBending()
    {
        if(!CanAirBend)   
        {
            return;
        }

        OnWaterBending();
    }
    
    protected abstract void OnAirBending();

    protected abstract void OnEarthBending();

    protected abstract void OnFireBending();

    protected abstract void OnWaterBending();
}
