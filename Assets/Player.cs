using UnityEngine;

namespace Asteroids
{
    internal sealed class Player : MonoBehaviour
    {
        public PlayerModel playerModel;
        public Rigidbody2D bullet;
        public Transform barrel;

        public PlayerController playerController;

        private void Update()
        {
            playerController.Update();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            playerController.OnCollisionEnter2D(other);
        }

        private void FixedUpdate()
        {
            playerController.FixedUpdate();
        }
    }
}