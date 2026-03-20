using System;

public class Fraction
{
    // Private attributes 
    private int _top;
    private int _bottom;

    // Constructor 1: No parameters 
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getters
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    // Setters
    public void SetTop(int top)
    {
        _top = top;
    }

    public void SetBottom(int bottom)
    {
        if (bottom != 0) 
        {
            _bottom = bottom;
        }
    }

    // Method to return fraction string
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to return decimal
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}