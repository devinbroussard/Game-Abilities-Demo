using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;
using MathLibrary;
using Raylib_cs;

namespace GameAbilitiesDemo
{
    class Engine
    {
        //Initializing variables
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        /// <summary>
        /// Stopwatch used to track deltaTime 
        /// </summary>
        private Stopwatch _stopwatch = new Stopwatch();
        public static Scene CurrentScene;
        public static Camera Camera;

        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            float currentTime = 0;
            float lastTime = 0;
            float deltaTime = 0;

            //Loops until the application is told to close
            while (!_applicationShouldClose && !Raylib.WindowShouldClose())
            {
                //Get how much time has passed since the application started
                currentTime = _stopwatch.ElapsedMilliseconds / 1000.0f;

                //Set delta time to tbe the difference in time from the last time recorded to the current time
                deltaTime = currentTime - lastTime;

                //Update the application
                Update(deltaTime);
                //Draw all items
                Draw();

                //Set the last time recorded to be the current time
                lastTime = currentTime;
            }

            //Called when the application closes
            End();
        }


        /// <summary>
        /// Called when the application starts
        /// </summary>
        private void Start()
        {
            _stopwatch.Start(); //Starts the stopwatch

            InitializeWindow(); //Initializes the window that the application uses
            Scene.InitializeActors(); //Initializes the scenes' actors

            Scene sceneOne = new Scene(); //Creates the first scene
            sceneOne.AddActor(Scene.SceneOneActors); //Adds the scene one actors to the scene
            sceneOne.AddUIElement(Scene.SceneOneUIElements); //Adds the scene one UI elements to the scene
            SetCurrentScene(sceneOne); //Sets the current scene to be the first scene

            _scenes[_currentSceneIndex].Start(); //Starts the first scene
        }

        /// <summary>
        /// Calls the scene's update functions every frame.
        /// </summary>
        private void Update(float deltaTime)
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_ESCAPE))
                CloseApplication();
            _scenes[_currentSceneIndex].Update(deltaTime);
            _scenes[_currentSceneIndex].UpdateUI(deltaTime);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.BeginMode3D(Camera.Camera3D);

            Raylib.ClearBackground(Color.DARKGRAY);
            Raylib.DrawGrid(10, 10); //Used to visualize the floor in the game

            //Adds all actor icons to buffer
            _scenes[_currentSceneIndex].Draw();

            Raylib.EndMode3D();

            _scenes[_currentSceneIndex].DrawUI();

            Raylib.EndDrawing();
        }

        /// <summary>
        /// Called when the application exits
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();

                Raylib.CloseWindow();
        }

        /// <summary>
        /// Adds a scene to the engine's scene array
        /// </summary>
        /// <param name="scene">The scene that will be added to the scene array</param>
        /// <returns>The index where the new scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Create a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy all the values from the old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
                tempArray[i] = _scenes[i];

            //Set the last index to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //Return the last index
            return _scenes.Length - 1;
        }

        /// <summary>
        /// Adds and sets the current scene to the scene given
        /// </summary>
        /// <param name="scene">The scene given</param>
        public void SetCurrentScene(Scene scene)
        {
            _currentSceneIndex = AddScene(scene);
            CurrentScene = _scenes[_currentSceneIndex];
        }

        /// <summary>
        /// Initializes the window that raylib will use during the game
        /// </summary>
        public void InitializeWindow()
        {
            int height = Raylib.GetMonitorHeight(1);
            int width = Raylib.GetMonitorWidth(1);
            //Create a window using rayLib
            Raylib.InitWindow(width, height, "Math For Games");
            Raylib.ToggleFullscreen();
            Raylib.DisableCursor();
            Raylib.SetTargetFPS(60);
        }

        /// <summary>
        /// A function that can be used globally to end the application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}
