// Original source: https://gist.github.com/jagwire/0129d50778c8b4462b68
using UnityEditor;

class WebGLBuilder {
    static void build() {
        string[] scenes = {
            "Assets/_Scenes/MainMenu.unity",
            "Assets/_Scenes/Game.unity"
        };

        BuildPipeline.BuildPlayer(scenes, "webgl-build", BuildTarget.WebGL, BuildOptions.None);
    }
}