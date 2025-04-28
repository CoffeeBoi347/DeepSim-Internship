using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public float velocity;

    [Header("Prediction Values")]

    public float chaseThreshold = 10f;
    public float attackThreshold = 15f;
}