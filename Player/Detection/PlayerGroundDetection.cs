using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundDetection : MonoBehaviour
{
    [SerializeField] private float detectionRadius;
    [SerializeField] private LayerMask groundLayerMask;
    public bool isGround =>Physics2D.OverlapCircle(transform.position,detectionRadius,groundLayerMask);
}
