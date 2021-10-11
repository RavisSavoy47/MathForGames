using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using MathLibrary1;

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
            while(!_applicationShouldClose)
            {
                Update();
                Draw();
                Thread.Sleep(150);
            }

            //Call end for the entire application
            End();
        }

        /// <summary>
        /// Called when th eapplication starts 
        /// </summary>
        private void Start()
        {
            Scene scene = new Scene();
            Actor actor = new Actor('P', new MathLibrary1.Vector2 { X = 0, Y = 0 }, "Actor1", ConsoleColor.Yellow);
            Actor actor2 = new Actor('A', new MathLibrary1.Vector2 { X = 10, Y = 4 }, "Actor2", ConsoleColor.Blue);

            scene.AddActor(actor2);
            scene.AddActor(actor);

            _currentSceneIndex = AddScene(scene);

            _scenes[_currentSceneIndex].Start();
        }

        /// <summary>
        /// Called everytime the game loops
        /// </summary>
        private void Update()
        {
            _scenes[_currentSceneIndex].Update();
        }

        /// <summary>
        /// Called every time the game loops to update visuals
        /// </summary>
        private void Draw()
        {
            Console.Clear();
            _scenes[_currentSceneIndex].Draw();
        }

        /// <summary>
        /// Called when the application exits
        /// </summary>
        private void End()
        {
            _scenes[_currentSceneIndex].End();
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

        public static void Render(Icon icon, Vector2 positison)
        {
            if (positison.X < 0 || positison.X >= _buffer.GetLength(0) || positison.Y < 0 || positison.Y >= _buffer.GetLength(1))
                return;


        }
    }
}
