using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerModel : ScriptableObject
    {
        public float speed;
        public float acceleration;
        public float hp;
        public float force;
        public GameObject gameObject;
    }
}
