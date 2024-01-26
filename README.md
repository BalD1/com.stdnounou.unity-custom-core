# __DESCRIPTION__ :

This is our own Unity custom core package. Please take note that even through we made it public, it is intended to our own projects, therefore might not fit yours.

It includes: 

- Our Singletons system
- A log helper
- Utility extensions methods
- A component holder, which  allows you to easily and quickly retrieve a component from an object through a dictionnary.

![image](https://github.com/BalD1/com.stdnounou.unity-custom-core/assets/24933826/80ee471e-f57c-4a2e-9d85-b0b6750fdc94)

# __REQUIREMENTS__ :
This package contains a ComponentHolder, which uses a dictionary to rapidly and easily retrieve a component from a given object, with errors handling.    
Obviously, this requires keys to retrieve the component. I chose an enum for this. However, since assets in the packages folder can (should) not be modified, I figured the better way would be to let the enum exist in the assets folder.    
So you'll need to manually add the enum into your assets folder :
- Either use [this package](https://github.com/BalD1/com.stdnounou.assets-creator.git)
  => Then click on this button, and let unity recompile ![image](https://github.com/BalD1/com.stdnounou.unity-custom-core/assets/24933826/ff122fe5-c506-4fd2-b701-943c6756f73f)
   
- Or manually add these files in the same folder, separated from your other scripts :
## ComponentsKeys.cs
```csharp
namespace StdNounou.Core 
{
    public enum E_ComponentsKeys
    {
        Rigidbody,
        AudioPlayer,
        Renderer,
        HealthSystem,
        StatsHandler
    }
}
```
## StdNounou.core.runtime_ref.asmref
```
{
    "reference": "GUID:07390520b8bc5a54cb973a134834aabf"
}
```

# __DEPENDECIES__ :

- Ayellowpaper's Serialized Dictionary: https://github.com/ayellowpaper/SerializedDictionary.git
- Leantween : https://github.com/AlgorithmJuice/LeanTween.git
