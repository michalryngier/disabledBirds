﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{
    public class SetScore : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            Score.score += 1;
        }
    }
}
