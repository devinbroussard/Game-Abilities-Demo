using System;
using System.Collections.Generic;
using System.Text;
using MathLibrary;
using Raylib_cs;

namespace MathForGamesAssessment
{
    class Camera : Actor
    {
        private Camera3D _camera3D;
        private Actor _targetActor;

        /// <summary>
        /// A variable containing the camera that is used in the engine
        /// </summary>
        public Camera3D Camera3D
        {
            get { return _camera3D; }
            set { _camera3D = value; }
        }

        /// <param name="targetActor">The actor that the camera will point at during the scene</param>
        public Camera(Actor targetActor)
            :base()
        {
            _camera3D = new Camera3D();
            _targetActor = targetActor;
            _targetActor.AddChild(this);
        }

        /// <summary>
        /// Called when the camera is added to the scene.
        /// Initializes some of the camera's variables and sets its position.
        /// </summary>
        public override void Start()
        {
            _camera3D.up = new System.Numerics.Vector3(0, 1, 0); //Camera up vector (rotation towards target)
            _camera3D.fovy = 45; // Camera field of view Y
            _camera3D.projection = CameraProjection.CAMERA_PERSPECTIVE; //Camera mode type
            SetTranslation(0, 3, -13);
        }

        /// <summary>
        /// Called every frame
        /// </summary>
        /// <param name="deltaTime">The time that passed between frames</param>
        public override void Update(float deltaTime)
        {
            // Sets the camera's position
            _camera3D.position = new System.Numerics.Vector3(WorldPosition.X, WorldPosition.Y, WorldPosition.Z);
            // Point the camera is focused on
            _camera3D.target = new System.Numerics.Vector3(_targetActor.WorldPosition.X, _targetActor.WorldPosition.Y + 2, _targetActor.WorldPosition.Z);

            //Calls the actor's update function
            base.Update(deltaTime);
        }
    }
}
