using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    public sealed class PlayerController
    {
        private Player player;
        private Camera camera;
        private Ship ship;
        private PlayerModel playerModel;
        private Transform transform;
        private InputController inputController;
        private InputData inputData;

        public PlayerController(PlayerModel playerModel)
        {
            this.playerModel = playerModel;

            player = GameObject.FindObjectOfType<Player>();
            player.playerModel = playerModel;
            player.playerController = this;
            playerModel.gameObject = player.gameObject;
            transform = playerModel.gameObject.transform;

            camera = Camera.main;

            var moveTransform = new AccelerationMove(transform, playerModel.speed, playerModel.acceleration);
            var rotation = new RotationShip(transform);
            ship = new Ship(moveTransform, rotation);

            inputData = new InputData();
            inputController = new InputController(inputData);
        }

        public void Update()
        {
            inputController.Update();

            var direction = Input.mousePosition - camera.WorldToScreenPoint(transform.position);
            ship.Rotation(direction);

            if (inputData.keyLeftShiftDown)
            {
                ship.AddAcceleration();
            }

            if (inputData.keyLeftShiftUp)
            {
                ship.RemoveAcceleration();
            }

            if (inputData.fireButtonDown)
            {
                var temAmmunition = GameObject.Instantiate(player.bullet, player.barrel.position, player.barrel.rotation);
                temAmmunition.AddForce(player.barrel.up * playerModel.force);
            }
        }

        public void FixedUpdate()
        {
            ship.Move(inputData.horizontal, inputData.vertical, Time.fixedDeltaTime);
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (playerModel.hp <= 0)
            {
                GameObject.Destroy(transform.gameObject);
                playerModel.gameObject = null;
            }
            else
            {
                playerModel.hp--;
            }
        }
    }
}
