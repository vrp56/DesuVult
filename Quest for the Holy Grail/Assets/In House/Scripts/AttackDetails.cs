﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDetails : MonoBehaviour
{
    public static float[,] NatsukiTimings = new float[3, 4]
    {
        {.5f, .5f, /* NOT USED */0000f, 0000f},
        {.5f, .625f, .75f, /* NOT USED */0000f},
        {.5f, .625f, .75f, 1f}
    };

    public static float[,] SatomiTimings = new float[3, 4]
    {
        {.75f, .75f, /* NOT USED */0000f, 0000f},
        {.75f, .875f, 1f, /* NOT USED */0000f},
        {.75f, .875f, 1f, 1.125f}
    };

    public static float[,] HarunoTimings = new float[3, 4]
    {
        {1f, 1f, /* NOT USED */0000f, 0000f},
        {1f, 1.25f, 1.5f, /* NOT USED */0000f},
        {1f, 1.25f, 1.5f, 2f}
    };
}
