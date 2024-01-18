
namespace StdNounou.Samples.HolderComponent
{
    public static class ComponentsKeys
    {
        // used for the editor Popup
        public readonly static string[] COMP_KEYS = {
        "Rigidbody",
        "Renderer",
        "AudioPlayer",
    };

        public static string Rigidbody { get => COMP_KEYS[0]; }
        public static string Renderer { get => COMP_KEYS[1]; }
        public static string AudioPlayer { get => COMP_KEYS[2]; }
    } 
}