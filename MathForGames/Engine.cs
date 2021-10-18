﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary1;
using Raylib_cs;

namespace MathForGames
{
    class Engine
    {
        private static bool _applicationShouldClose = false;
        private static int _currentSceneIndex;
        private Scene[] _scenes = new Scene[0];
        private static Icon[,] _buffer;


        /// <summary>
        /// Called to begin the application
        /// </summary>
        public void Run()
        {
            //Call start for the entire application
            Start();

            //loop until the application is told to close
            while(!_applicationShouldClose && !Raylib.WindowShouldClose())
            {
                Update();
                Draw();
            }

            //Call end for the entire application
            End();
        }

        /// <summary>
        /// Called when th eapplication starts 
        /// </summary>
        private void Start()
        {
            //Create a window using raylib
            Raylib.InitWindow(800, 450, "Math For Games");

            Scene scene = new Scene();
            Actor actor = new Actor('P', 0, 0, Color.YELLOW, "Actor1");            
            Player player = new Player('@', 10, 5, 1, Color.VIOLET, "Player");
            scene.AddActor(player);
            scene.AddActor(actor);

            _currentSceneIndex = AddScene(scene);
            _scenes[_currentSceneIndex].Start();
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Called everytime the game loops.
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();

            while (Console.KeyAvailable)
                Console.ReadKey(true);
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.SKYBLUE);
            //Adds all actors icons to buffer
            _scenes[_currentSceneIndex].Draw();

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
        /// <returns>The index where th enew scene is located</returns>
        public int AddScene(Scene scene)
        {
            //Create a new temporary array
            Scene[] tempArray = new Scene[_scenes.Length + 1];

            //Copy all values from old array into the new array
            for (int i = 0; i < _scenes.Length; i++)
            {
                tempArray[i] = _scenes[i];
            }

            //Set the last item to be the new scene
            tempArray[_scenes.Length] = scene;

            //Set the old array to be the new array
            _scenes = tempArray;

            //Return the last index
            return _scenes.Length -1;
        }

        /// <summary>
        /// Gets the key in the input stream
        /// </summary>
        /// <returns>teh key that was pressed</returns>
        public static ConsoleKey GetNextKey()
        {
            //If there is no key being pressed
            if (!Console.KeyAvailable)
                //..return
                return 0;

            //return teh current key being pressed
            return Console.ReadKey(true).Key;
        }

        /// <summary>
        /// Ends teh application
        /// </summary>
        public static void CloseApplication()
        {
            _applicationShouldClose = true;
        }
    }
}
