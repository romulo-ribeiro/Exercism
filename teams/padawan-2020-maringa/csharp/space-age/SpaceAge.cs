public class SpaceAge
{
    private readonly double spaceAge;
    private readonly double earthSeconds = 31557600;
    private readonly double mercury = 0.2408467;
    private readonly double venus = 0.61519726;
    private readonly double mars = 1.8808158;
    private readonly double jupiter = 11.862615;
    private readonly double saturn = 29.447498;
    private readonly double uranus = 84.016846;
    private readonly double neptune = 164.79132;

    public SpaceAge(int seconds)
    {
        spaceAge = (double)seconds;
    }

    public double OnEarth()
    {
        return spaceAge / earthSeconds;
    }

    public double OnMercury()
    {
        return OnEarth() / mercury;
    }

    public double OnVenus()
    {
        return OnEarth() / venus;
    }

    public double OnMars()
    {
        return OnEarth() / mars;
    }

    public double OnJupiter()
    {
        return OnEarth() / jupiter;
    }

    public double OnSaturn()
    {
        return OnEarth() / saturn;
    }

    public double OnUranus()
    {
        return OnEarth() / uranus;
    }

    public double OnNeptune()
    {
        return OnEarth() / neptune;
    }
}