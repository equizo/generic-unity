# Main Menu Generic Unity Project
This project demonstrates architectural solutions and robust development tools, supported by a set of configuration files for both application and debugging scenarios.

## Overview
The project consists of three screens featuring UI and background 3D navigation. A main menu navigation demo. One of the key principles was to support a wide variety of platforms without relying on runtime branching and conditions. The selected platforms are Standalone and Mobile. Although these scenarios are quite different, this added challenge to building a solution that works on both platforms with a single code base, despite differences in both input and output.

- Unity Version: 2022.3.18
- 3rd Party Plugins Used: YamlDotNet: For serialization; DoTween: For animations.

Standalone platform capture

https://github.com/user-attachments/assets/bc0bdd76-b331-4350-9714-e92e1c1728e7

Mobile platform capture

https://github.com/user-attachments/assets/4c155581-f567-47ca-bf7d-25d6b4758130


## Configuration
This data-driven solution aims to separate the application's logic from its configuration, ensuring that constants and variables are managed externally rather than within the C# code. The goal is to avoid "magic numbers" and strings, outsourcing these to external configuration files.

Configuration files are located under the _Resources/config_ folder. There are two sets of files for the editor and build use cases, which often differ for testing purposes:

- _configuration_: The main configuration file, listing screens, addressable assets CDN (mock) settings, and other configuration files.
- _debug_: Debugging tools configuration to enhance the development experience.
- _path_: Path-related string constants.
- _request_: (Mock) API endpoints.

Gameplay-related configuration files are also located in the _Resources/config_ folder.

## Debug
The _debug_ config file is primarily used to toggle different console logging modules, such as the state machine, analytics, and purchases, on and off. This allows specific modules' console logging to be activated as needed, or for none at all.
![Unity_T5W8hANyAQ](https://github.com/user-attachments/assets/ca7a929e-857f-426d-bd99-a729eae8f705)

## Application Flow
The main scene is located at _Assets/Scenes/bootstapper_. There is only one scene, which can also load lighting settings if needed. However, within the scope of this project, multiple scenes are not necessary, so the bootstrapper is the only scene used.

The bootstrapper contains a GameObject with the _GameBootstrapper_ component, which initializes the Game. During this bootstrapping process, static data is initialized, platform (device) type-specific settings are applied, and the framerate is set.

The _Game_ class stores a reference to the _GameStateMachine_, which controls the app flow in a robust and deterministic manner. The _GameStateMachine_ starts in the _BootstrapState_, responsible for registering services. Each service is a separate entity performing specific tasks, managed by the service locator implementation _AllServices_.

As the _GameStateMachine_ switches states based on user actions (or not), the corresponding services perform tasks within those states. The _MenuNavigationState_ is the primary "gameplay" state, containing its own state machine with its own states, each tied to a specific UI screen.
Game states:
Menu navigation states:
Game and Menu state machine diagrams

![game](https://github.com/user-attachments/assets/704344cb-7f13-4c1d-b194-b6c5540169cb) 
![menu](https://github.com/user-attachments/assets/9d71820d-fa2b-49c2-8b38-cc0cd279202f)

## Platform-Dependency Solution
At an early stage, _PlatformDependentServices_ determines the device type and sets corresponding values, such as the root folder for prefab paths. For convenience, all assets are stored in _Resources_. However, the project allows for moving them to predefined storage, such as scriptable objects or addressable assets, so no assets from another platform are included in the build.

The folder hierarchy is consistent across platforms. Prefabs themselves can have different structures, assets, and components. The system does not rely on checking which prefab to spawn as long as the prefab exists and corresponding scripts are found. This minimizes runtime branching and allows for a streamlined flow.

This approach ensures that user input, UI elements, and scene 3D environments are platform-specific, with common prefabs stored in _Assets/Prefabs_. For example, the mobile platform might use a low-poly environment or a lighter post-processing stack compared to standalone assets.

## Optimization
The project employs best practices to minimize performance overhead, including:

- Cached loaded sprites to prevent multiple reads of the same sprites;
- Sprite atlases to reduce UI draw calls;
- Disabled raycasting on images and text elements where not needed;
- Deactivated GameObjects to avoid unnecessary canvas rebuilds;
- .png assets compressed.

## Data-Driven Approach
All data to render/process is stored in _Resources/configs_. The application deserializes the values and passes them to the relevant service for further processing.

##  UI
To showcase the flexibility of the UI, which is dynamically constructed by the data provider, the equipment state  generates 16 random equipment items by combining values from affix and weapon configuration files. Then equipment screen generates a complex layout setup allowing for flexible configurations without warning messages on the layout components or the need to rebuild the layout group. The behavior also varies between platforms. Skeleton view of components:
![Unity_ny2mW2GYqF](https://github.com/user-attachments/assets/6f4eee89-7b5f-4a0a-9c6a-77271d46e17d)

Navigation controls are different for each platform – ui buttons for standalone and swipe gestures for mobile.

##  License
MIT
