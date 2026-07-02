# Cyano Vision

> A speculative VR tool that reimagines human sight as cyanobacterial perception, built on Meta Quest 3 passthrough.

## Overview

Cyano Vision is a speculative tool developed for the pictorial *From machinery to sensibility: (Un)learning cyanobacteria between biological laboratory practice and more-than-human exploration.*

Built on the passthrough functionality of the Meta Quest 3, the tool speculatively transforms RGB camera data into a representation of cyanobacterial perception. Users can adjust a range of parameters to play with and reshape that perception in real time.

## Development Ecosystem

| Dependency | Version |
|---|---|
| Unity | 2022.3.50f1 |
| Meta XR All-in-One | 69.0.1 |
| Target platform | Meta Quest 3 |

## Getting Started

### Clone

```bash
git clone https://github.com/<user>/<repo>.git
```

### Open in Unity

1. Open **Unity Hub** → **Add** → select the cloned folder.
2. Open the project with **Unity 2022.3.50f1**.
3. Let Unity import packages and resolve dependencies on first launch.

### Run

The default scene is located at:

```
Assets/Scenes/CyanoVision
```

Open this scene, connect a Meta Quest 3 in developer mode, and build and run to the headset.


### Build Settings

1. Open **File** → **Build Settings**.
2. Switch Platform to Android.
3. Make sure **Scenes/CyanoVision** is on the top of **Scenes In Build**.
4. Connect the Quest to your computer, put on the headset, and select **Allow** when prompted to enable **USB debugging** for the computer.
5. Set **Run Device** to connected **Oculus Quest (serial no)**.
6. Click **Build and Run**.



## Scene Components

The experience is composed of the following key elements within the default scene:

- **`[BuildingBlock] Camera Rig`** - Default MetaXR component for VR/MR experience. MR/Passthrough parameters setted for the experience.

- **`[BuildingBlock] Passthrough`** — the OVR Passthrough Layer drawn from the Meta SDK building blocks. Its parameters are configured to the default Cyano Vision settings. These can be overridden through the control panel UI, but cannot be restored without restarting the experience.

- **Passthrough Script** — a custom script written for this experience that overrides the default passthrough parameters on the `[BuildingBlock] Passthrough`.

- **CyanoVisionCPanel** — a UI panel based on the Meta SDK template. Anchored to the left hand/controller. User can interact with hand tracking or controllers with right hand. Hidden in default, use third/menu button in the controller, or **palm-up pinch gesture** on left hand. It allows users to adjust the vision-effect parameters with sliders and toggle them on or off with buttons. To apply custom parameters, Filter Override(button) must be enabled.
  - Toggle buttons:
    - Edge Rendering
    - Filter Override
    - Particles
    - Dark/Light Efect Status (not interactable)

- **Particle System** — in addition to the OVR Passthrough Layer, a Unity particle system is used to mimic the small dust particles characteristic of cyanobacterial perception.

## Citation

If you reference this work, please cite the accompanying pictorial: (pre-print)

> Kim, J., Nicenboim, I., Öğretmen, O., Martins, J., & Karana, E. (2026). *From machinery to sensibility: (Un)learning cyanobacteria between biological laboratory practice and more-than-human exploration.* https://doi.org/10.13140/RG.2.2.19501.65766

```bibtex
@misc{kim2026cyanobacteria,
  author = {Kim, Jiho and Nicenboim, Iohanna and {\"O}{\u{g}}retmen, Okan and Martins, Joana and Karana, Elvin},
  title  = {From machinery to sensibility: (Un)learning cyanobacteria between biological laboratory practice and more-than-human exploration},
  year   = {2026},
  doi    = {10.13140/RG.2.2.19501.65766},
  url    = {https://www.researchgate.net/publication/407125790_From_machinery_to_sensibility_Unlearning_cyanobacteria_between_biological_laboratory_practice_and_more-than-human_exploration}
}
```

## Acknowledgements

Built with the Meta XR All-in-One SDK. The passthrough layer and control panel UI are adapted from the Meta SDK building blocks and templates.


## Copyright

This project is made available under a CC-BY. 

## Contact

**Corresponding author** - Jiho Kim - J.Kim-4@tudelft.nl 
**Developer** - Okan Efe Öğretmen - oogretmen19@ku.edu.tr
 
