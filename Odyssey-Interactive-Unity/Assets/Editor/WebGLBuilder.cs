//place this script in the Editor folder within Assets.
using System;
using UnityEditor;


//to be used on the command line:
//$ Unity -quit -batchmode -executeMethod WebGLBuilder.build

class WebGLBuilder {
    static void build() {
        string[] scenes = {
            "Assets/_Scenes/MainMenu.unity",
            "Assets/_Scenes/Game.unity"
        };

		Console.WriteLine("Beginning build...");
        BuildPipeline.BuildPlayer(scenes, "webgl-build", BuildTarget.WebGL, BuildOptions.None);
		Console.WriteLine("Build complete");
    }
}