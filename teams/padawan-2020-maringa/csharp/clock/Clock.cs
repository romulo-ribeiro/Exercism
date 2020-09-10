using System;
using System.Diagnostics.CodeAnalysis;

public class Clock : IEquatable<Clock>
{
    int Hours;
    int Minutes;
    public Clock(int minutes)
    {
        Hours = ((minutes / 60)) % 24;
        Minutes = minutes % 60;
        if (Minutes < 0)
        {
            Hours -= 1;
            Minutes += 60;
        }
        if (Hours < 0) { Hours += 24; }
    }
    public Clock(int hours, int minutes)
    {
        Hours = (hours + (minutes / 60)) % 24;
        Minutes = minutes % 60;
        if (Minutes < 0)
        {
            Hours -= 1;
            Minutes += 60;
        }
        if (Hours < 0) { Hours += 24; }
    }

    public Clock Add(int minutesToAdd)
    {
        return new Clock(Hours, Minutes + minutesToAdd);
    }

    public Clock Subtract(int minutesToSubtract)
    {
        return new Clock(Hours, Minutes - minutesToSubtract); ;
    }
    public int ToMinutes() => Hours * 60 + Minutes;
    public override bool Equals(object obj)
    {
        if (ReferenceEquals(this, obj)) { return true; }
        return obj is Clock clock && Equals(clock);
    }
    public override int GetHashCode() => HashCode.Combine(Hours, Minutes);
    public bool Equals([AllowNull] Clock other)
    {
        if (other is null) { return false; }
        if (ReferenceEquals(this, other)) { return true; }
        return Hours == other.Hours && Minutes == other.Minutes;
    }

    public override string ToString()
    {
        return $"{Hours:D2}:{Minutes:D2}";
    }

    public static Clock operator +(Clock clock, int value)
    {
        return clock.Add(value);
    }
    public static Clock operator -(Clock clock, int value)
    {
        return clock.Subtract(value);
    }
    public static Clock operator +(Clock clock)
    {
        return new Clock(clock.Hours, clock.Minutes);
    }
    public static Clock operator -(Clock clock)
    {
        return new Clock(-clock.Hours, -clock.Minutes);
    }
    public static Clock operator ++(Clock clock)
    {
        return clock.Add(1);
    }
    public static Clock operator --(Clock clock)
    {
        return clock.Subtract(1);
    }
    public static Clock operator +(Clock clock, Clock other)
    {
        return new Clock(clock.Hours + other.Hours, clock.Minutes + other.Minutes);
    }
    public static Clock operator -(Clock clock, Clock other)
    {
        return new Clock(clock.Hours - other.Hours, clock.Minutes - other.Minutes);
    }
    public static Clock operator *(Clock clock, int value)
    {
        return new Clock(clock.ToMinutes() * value);
    }
    public static Clock operator /(Clock clock, int value)
    {
        return new Clock(clock.ToMinutes() / value);
    }
    public static bool operator >(Clock clock, Clock other)
    {
        return clock.ToMinutes() > other.ToMinutes();
    }
    public static bool operator <(Clock clock, Clock other)
    {
        return clock.ToMinutes() < other.ToMinutes();
    }
    public static bool operator ==(Clock clock, Clock other)
    {
        return clock.ToMinutes() == other.ToMinutes();
    }
    public static bool operator !=(Clock clock, Clock other)
    {
        return clock.ToMinutes() != other.ToMinutes();
    }
    public static bool operator <=(Clock clock, Clock other)
    {
        return clock < other || clock == other;
    }
    public static bool operator >=(Clock clock, Clock other)
    {
        return clock > other || clock == other;
    }
}
