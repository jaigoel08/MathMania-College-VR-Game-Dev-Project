using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class problem
{
    public float firstNumber;           // first number in the problem
    public float secondNumber;          // second number in the problem
    public MathsOperation operation;    // operator between the two numbers
    public float[] answers;
    public string simplified;// array of all possible answers including the correct one
    //public float choices;

    [Range(0, 3)]
    public int correctcube;             // index of the correct tube
}

public enum MathsOperation
{
    Addition,
    Subtraction,
    Multiplication,
    Division
}

public class Question
{
    public float Answer1;
}

