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

    /// <summary>
    /// Manages the deduction of calories from food upon eating
    /// </summary>
    /// <param name="amount"> is the amount of calories eaten </param>
    public float Feed(float amount)
    {
        float calorieTaken = Mathf.Clamp(amount, 0f, calorieAmount);

        calorieAmount -= amount;

        if(calorieAmount <= 0)
        {
            // No calorie remaining
            calorieAmount = 0f;

            // Disable the food and calorie colliders
            calorieCollider.gameObject.SetActive(false);
            foodCollider.gameObject.SetActive(false);

            // Change food color to indicate that it is empty
            foodMaterial.SetColor("_BaseColor", emptyFoodColor);
        }

        // Return the amount of calories that was taken
        return calorieTaken;
    }

    public void ResetFood()
    {
        // Refill the calories
        calorieAmount = 1f;

        // Enable the food and calorie colliders
        calorieCollider.gameObject.SetActive(true);
        foodCollider.gameObject.SetActive(true);

        // Change food color to indicate that it is empty
        foodMaterial.SetColor("_BaseColor", fullFoodColor);
    }
}
