# Touch Feedback for Virtual Reality

## Overview
**Touch Feedback for Virtual Reality** is an immersive VR application built using Unity, the XR Toolkit, and Meta Quest 2. The project provides a real-time multiplayer virtual environment with touch feedback functionality, enhancing user interactions within virtual meeting rooms. The project is associated with UCI Samueli School of Engineering.

This application focuses on improving user engagement and immersion by delivering real-time haptic feedback through ESP32-driven devices and a scalable backend built on AWS for handling communication and interaction data.

## Features
- **Responsive VR Front-end:** Developed with Unity and C# using the XR Toolkit, enabling immersive real-time multiplayer interactions.
- **Low-latency Communication:** Secure HTTPS pipeline for data transmission between Meta Quest 2 and the server, ensuring smooth user interactions.
- **Data Handling Architecture:** Real-time interaction data is securely stored in AWS S3, then batch-loaded into DynamoDB for scalable access.
- **Scalable Backend:** Built with Node.js, the backend supports real-time avatar synchronization, ensuring seamless interaction for over 50 concurrent users.
- **Haptic Feedback:** Integrated ESP32-driven haptic feedback with Meta Quest 2, enhancing the sense of touch in virtual environments.
- **Automated CI/CD:** Dockerized deployment with AWS Elastic Beanstalk and CodePipeline for seamless scaling, ensuring 99.9% uptime and reducing development overhead.

## Project Structure

```ruby
.
├── Assets
│   ├── Oculus
│   │   ├── OculusProjectConfig.asset
│   │   ├── OculusProjectConfig.asset.meta
│   ├── Resources
│   │   ├── MetaXRAudioSettings.asset
│   │   ├── MetaXRAudioSettings.asset.meta
│   │   ├── OVRBuildConfig.asset
│   │   ├── OVRBuildConfig.asset.meta
│   │   ├── OculusRuntimeSettings.asset
│   │   ├── OculusRuntimeSettings.asset.meta
│   ├── Scenes
│   │   ├── SampleScene.unity
│   │   ├── SampleScene.unity.meta
│   ├── XR
│   │   ├── Loaders
│   │   │   ├── OculusLoader.asset
│   │   │   ├── OculusLoader.asset.meta
│   │   ├── Settings
│   │   │   ├── OculusSettings.asset
│   │   │   ├── OculusSettings.asset.meta
│   │   ├── XRGeneralSettingsPerBuildTarget.asset
│   │   ├── XRGeneralSettingsPerBuildTarget.asset.meta
│   ├── XRI
│   │   ├── Settings
│   ├── Scripts
│   │   ├── ColorChangeCode.cs
│   │   ├── CubeScript.cs
│   │   ├── PokingManager.cs
│   ├── Materials
│   │   ├── New Material.mat
│   │   ├── New Material 1.mat
│   │   ├── New Material 2.mat
├── Packages
│   ├── manifest.json
│   ├── packages-lock.json
├── ProjectSettings
│   ├── AudioManager.asset
│   ├── EditorBuildSettings.asset
│   ├── GraphicsSettings.asset
│   ├── InputManager.asset
│   ├── ProjectVersion.txt
│   ├── TagManager.asset
│   ├── TimeManager.asset
│   ├── UnityConnectSettings.asset
├── .gitignore
├── README.md
```
# Installation

## Prerequisites
- Unity 2022.3 or higher.
- Meta Quest 2 headset.
- ESP32 hardware for haptic feedback.
- AWS account (for backend services like S3, DynamoDB, Elastic Beanstalk, etc.).

## Steps
1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/TouchFeedbackVR.git
2. Open the project in Unity.
3. Make sure to install required packages:
  - XR Interaction Toolkit
  - Oculus Integration SDK
4. Set up the backend environment on AWS:
  - Configure S3 and DynamoDB for data storage.
  - Deploy the backend server using Node.js on AWS Elastic Beanstalk.
5. Build and deploy the project to Meta Quest 2.

## Oculus SDK Setup
**To integrate the Oculus SDK:**

1. Download and install the Oculus Integration package into Unity.
2. Ensure the OculusLoader is configured in the XR Management settings under XR -> Loaders.
3. Add the necessary OculusSettings under XR -> Settings.

## Usage
1. Launch the application on Meta Quest 2.
2. Interact with other users in the virtual meeting rooms.
3. Feel real-time touch feedback when interacting with virtual objects or avatars.
4. Backend automatically syncs interactions and avatar movements across all users in real time.

## AWS Backend Setup
1. Deploy the backend Node.js application using AWS Elastic Beanstalk.
2. Set up S3 for real-time data storage and DynamoDB for batch data processing.
3. Ensure HTTPS endpoints are secured for communication between Meta Quest 2 and the server.

## Presentation Video
Check out this demonstration video to see Touch Feedback for Virtual Reality in action!

[![Touch-Feedback-for-Virtual-Reality/Assets/Spinoverse.png](https://github.com/HasiniReddy57/Touch-Feedback-for-Virtual-Reality/blob/main/Assets/Spinoverse.png)](https://drive.google.com/file/d/1NQIL3MsY1MfwYd5NgHR7iM7MOYJ7xqmY/view)

In this video, you can see how real-time interactions work within the VR meeting rooms, as well as a demonstration of the touch feedback system using ESP32-driven haptic devices.

## Contributing
**Contributions are welcome! Please follow these steps:**

1. Fork the repository.
2. Create a feature branch (`git checkout -b feature/AmazingFeature`).
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`).
4. Push to the branch (`git push origin feature/AmazingFeature`).
5. Open a pull request.

## License
This project is licensed under the MIT License - see the [LICENSE]() file for details.

## Acknowledgments
- [UCI Samueli School of Engineering](https://engineering.uci.edu/home) for their support and collaboration.
- [Meta](https://about.meta.com/) for providing Oculus hardware and development kits.
- [AWS](https://www.google.com/aclk?sa=l&ai=DChcSEwiC3_a09YaJAxUCCK0GHWWHFI0YABAAGgJwdg&co=1&ase=2&gclid=CjwKCAjwmaO4BhAhEiwA5p4YL1xfj7UZ7MiVMtsqButaWoPIRcqDudlSx_0xn3HWn261TUhApYfkPRoCrroQAvD_BwE&sig=AOD64_0yvIgd667mtxpPyuHrs0Myv-_xag&q&nis=4&adurl&ved=2ahUKEwi1lvC09YaJAxX-JEQIHU0zKF0Q0Qx6BAgIEAE) for their reliable cloud infrastructure.
