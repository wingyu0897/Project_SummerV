using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SO/AGENT/AgentData")]
public class AgentData : ScriptableObject
{
    public float speed = 4f;
    public float acceleration = 50f;
    public float deAcceleration = 50f;
    [Tooltip("�����̴� �ӵ�")][Range(0, 1f)] public float turnSpeed = 1f;
    [Tooltip("�ڸ� ���� ����(�ּ�)")][Range(0, 90f)] public float turnBackwardMinDeg = 45f;
    [Tooltip("�ڸ� ���� ����(�ִ�)")][Range(90f, 180f)] public float turnBackwardMaxDeg = 135f;
}
