using System;
using UnityEngine;

namespace Asteroids
{
    internal class MoveTransform : IMove
    {
        private readonly Transform _transform;
        private Vector3 _move;
        private Rigidbody2D rigidbody2D;

        public float Speed { get; protected set; }

        public MoveTransform(Transform transform, float speed)
        {
            _transform = transform;
            Speed = speed;
            rigidbody2D = transform.GetComponent<Rigidbody2D>();
            if (rigidbody2D == null) throw new Exception("Prefab must have a RigitBody2D component");
        }

        public void NormalMove(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            _transform.localPosition += _move;
        }

        public void PhysicMove(float horizontal, float vertical, float deltaTime)
        {
            var speed = deltaTime * Speed;
            _move.Set(horizontal * speed, vertical * speed, 0.0f);
            rigidbody2D.AddForce(_move);
        }

        public void Move(float horizontal, float vertical, float deltaTime)
        {
            PhysicMove(horizontal, vertical, deltaTime);
        }
    }
}