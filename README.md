# AblyDemo
Ably .NET IoT Raspberry PI Game Demo

This repo contains a simple game that runs on a Raspberry PI with the SenseHat.  The game uses is written in .NET, using the Internet of Things (IoT) extensions and employs the Ably realtime service to allow the games controller to run remotely (either in a different process on the Raspberry PI running the main game loop, or on a completely different machine: for example a Apple Mac, that also has .NET installed).

## Parts required

To run this you will need:

1. .NET, available [here](https://dotnet.microsoft.com/download)
2. The .NET IoT extensions, available [here](https://github.com/dotnet/iot)
3. A Raspberry PI, the Raspberry PI 4B is [recommended](https://www.raspberrypi.org/products/raspberry-pi-4-model-b/)
4. A Raspberry PI [SenseHAT](https://www.raspberrypi.org/products/sense-hat/)
5. The Ably API along with a free Ably account.

Note: The Raspberry PI 4B is recommended .NET runs very nicely on the 2GB base model.  2GB is also realistically enough memory to use Visual Studio Code on the Raspberry PI, allowing you to tinker with the code in-situ.

