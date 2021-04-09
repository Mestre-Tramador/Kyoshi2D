/// <summary>
/// Represents a Bender Character.
/// </summary>
public abstract class Bender : Character
{
    /// <summary>
    /// Controls if the <see cref="Bender"/> can bend Air.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanAirBend { get; private set; }

    /// <summary>
    /// Controls if the <see cref="Bender"/> can bend Earth.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanEarthBend { get; private set; }

    /// <summary>
    /// Controls if the <see cref="Bender"/> can bend Fire.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanFireBend { get; private set; }

    /// <summary>
    /// Controls if the <see cref="Bender"/> can bend Water.
    /// </summary>
    /// <value><see langword="true"/> if it can.</value>
    public bool CanWaterBend { get; private set; }

    /// <summary>
    /// Activate the Air Bending event listener.
    /// </summary>
    public void BendAir() => ListenToAirBending();

    /// <summary>
    /// Activate the Earth Bending event listener.
    /// </summary>
    public void BendEarth() => ListenToEarthBending();

    /// <summary>
    /// Activate the Fire Bending event listener.
    /// </summary>
    public void BendFire() => ListenToFireBending();

    /// <summary>
    /// Activate the Water Bending event listener.
    /// </summary>
    public void BendWater() => ListenToWaterBending();

    /// <summary>
    /// The Air Bending event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Bender"/>.
    /// </summary>
    protected abstract void OnAirBending();

    /// <summary>
    /// The Earth Bending event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Bender"/>.
    /// </summary>
    protected abstract void OnEarthBending();

    /// <summary>
    /// The Fire Bending event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Bender"/>.
    /// </summary>
    protected abstract void OnFireBending();

    /// <summary>
    /// The Water Bending event. <br/>
    ///
    /// As <see langword="abstract"/>,
    /// it depends on each <see cref="Bender"/>.
    /// </summary>
    protected abstract void OnWaterBending();

    /// <summary>
    /// All in one, enable respectively:
    /// <list type="bullet">
    /// <item>Air Bend;</item>
    /// <item>Earth Bend;</item>
    /// <item>Fire Bend;</item>
    /// <item>Water Bend.</item>
    /// </list>
    /// </summary>
    protected void BecomeAvatar()
    {
        EnableAirBending();
        EnableEarthBending();
        EnableFireBending();
        EnableWaterBending();
    }

    /// <summary>
    /// All in one, disable respectively:
    /// <list type="bullet">
    /// <item>Air Bend;</item>
    /// <item>Earth Bend;</item>
    /// <item>Fire Bend;</item>
    /// <item>Water Bend.</item>
    /// </list>
    /// </summary>
    protected void BecomeOzai()
    {
        DisableAirBending();
        DisableEarthBending();
        DisableFireBending();
        DisableWaterBending();
    }

    /// <summary>
    /// Disable the Air Bend control.
    /// </summary>
    protected void DisableAirBending() => CanAirBend = false;

    /// <summary>
    /// Enable the Air Bend control.
    /// </summary>
    protected void EnableAirBending() => CanAirBend = true;

    /// <summary>
    /// Disable the Earth Bend control.
    /// </summary>
    protected void DisableEarthBending() => CanEarthBend = false;

    /// <summary>
    /// Enable the Earth Bend control.
    /// </summary>
    protected void EnableEarthBending() => CanEarthBend = true;

    /// <summary>
    /// Disable the Fire Bend control.
    /// </summary>
    protected void DisableFireBending() => CanFireBend = false;

    /// <summary>
    /// Enable the Fire Bend control.
    /// </summary>
    protected void EnableFireBending() => CanFireBend = true;

    /// <summary>
    /// Disable the Water Bend control.
    /// </summary>
    protected void DisableWaterBending() => CanWaterBend = false;

    /// <summary>
    /// Enable the Water Bend control.
    /// </summary>
    protected void EnableWaterBending() => CanWaterBend = true;

    /// <summary>
    /// The Air Bend event listener.
    /// </summary>
    private void ListenToAirBending()
    {
        if(!CanAirBend)
        {
            return;
        }

        OnAirBending();
    }

    /// <summary>
    /// The Earth Bend event listener.
    /// </summary>
    private void ListenToEarthBending()
    {
        if(!CanEarthBend)
        {
            return;
        }

        OnEarthBending();
    }

    /// <summary>
    /// The Fire Bend event listener.
    /// </summary>
    private void ListenToFireBending()
    {
        if(!CanFireBend)
        {
            return;
        }

        OnFireBending();
    }

    /// <summary>
    /// The Water Bend event listener.
    /// </summary>
    private void ListenToWaterBending()
    {
        if(!CanWaterBend)
        {
            return;
        }

        OnWaterBending();
    }
}