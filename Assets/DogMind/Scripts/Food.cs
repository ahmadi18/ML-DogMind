using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Manages a food with Calories
/// </summary>
public class Food : MonoBehaviour
{
    [Tooltip("The color when the food is full")]
    public Color fullFoodColor = new Color(1f, 0f, .3f);

    [Tooltip("The color when the food is empty")]
    public Color emptyFoodColor = new Color(.5f, 0f, 1f);

    /// <summary>
    /// The trigger collider representing the calories 
    /// </summary>
    [HideInInspector]
    public Collider calorieCollider;

    // The solid collider representing the food
    private Collider foodCollider;

    // The food's material
    private Material foodMaterial;

    /// <summary>
    /// A vector pointing out straight out of the food
    /// </summary>
    public Vector3 foodUpVector
    {
        get
        {
            return calorieCollider.transform.up;
        }
    }

    /// <summary>
    /// The center position of the food collider
    /// </summary>
    public Vector3 FoodCenterPosition
    {
        get
        {
            return calorieCollider.transform.position;
        }
    }

    /// <summary>
    /// The amount of calories remaining in the food
    /// </summary>
    public float calorieAmount { get; private set; }

    /// <summary>
    /// Whether the food has calories remaining
    /// </summary>
    public bool HasCalories
    {
        get
        {
            return calorieAmount > 0f;
        }
    }
}
