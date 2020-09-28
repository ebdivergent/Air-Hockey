using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

public interface ILocalPosition
{
    Vector3 _localPosition { get; set; }
}
public class PlayerData : MonoBehaviour
{
    public float MovementSpeed;
    public float RotateSpeed;
    public float Hitforce;
}
