using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AGENT/AgentData")]
public class AgentData : ScriptableObject
{
    public float speed = 4f;
    public float acceleration = 50f;
    public float deAcceleration = 50f;
    [Tooltip("움직이는 속도")][Range(0, 1f)] public float turnSpeed = 1f;
    [Tooltip("뒤를 보는 각도(최소)")][Range(0, 90f)] public float turnBackwardMinDeg = 45f;
    [Tooltip("뒤를 보는 각도(최대)")][Range(90f, 180f)] public float turnBackwardMaxDeg = 135f;
}
