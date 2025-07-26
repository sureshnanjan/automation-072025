/************************************************************************************
*  © 2025 AscendionQA. All rights reserved.
*  
*  File: SuperMan.cs
*  Description: This file defines the SuperMan class which demonstrates 
*               the use of delegates (Action) for executing callback methods.
*  
*  Author: Shreya S G
*  Created On: 26-Jul-2025
*  
*  NOTE:
*  - The Play method accepts an Action delegate, allowing any method with no 
*    parameters and no return value to be executed (e.g., displaying subtitles).
************************************************************************************/

using System;

namespace MainProgram
{
    /// <summary>
    /// Represents a SuperMan class that can "play" an action such as showing subtitles.
    /// </summary>
    public class SuperMan
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SuperMan"/> class.
        /// </summary>
        public SuperMan() { }

        /// <summary>
        /// Simulates playing a movie and executes a provided action (e.g., showing subtitles).
        /// </summary>
        /// <param name="subtitle">
        /// An <see cref="Action"/> delegate representing the method to execute when playing (e.g., a subtitle display).
        /// </param>
        public void Play(Action subtitle)
        {
            // Simulate playing a movie
            Console.WriteLine("Playing movie...");

            // Execute the provided action (e.g., show subtitles)
            subtitle();
        }
    }
}
