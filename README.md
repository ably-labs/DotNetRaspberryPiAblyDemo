# AblyDemo
Ably .NET IoT Raspberry PI Game Demo

This repo contains a simple game that runs on a Raspberry PI with the SenseHat.  The game uses is written in .NET, using the Internet of Things (IoT) extensions and employs the Ably realtime service to allow the games controller to run remotely (either in a different process on the Raspberry PI running the main game loop, or on a completely different machine: for example a Apple Mac, that also has .NET installed).

## Parts required

To run this you will need:

1. .NET, available [here](https://dotnet.microsoft.com/download)
2. The .NET IoT extensions, available [here](https://github.com/dotnet/iot)
3. A Raspberry PI, the Raspberry PI 4B is [recommended](https://www.raspberrypi.org/products/raspberry-pi-4-model-b/)
4. A Raspberry PI [SenseHAT](https://www.raspberrypi.org/products/sense-hat/)
5. The [Ably API](https://www.nuget.org/packages/ably.io/) along with a [free Ably account.](https://ably.com/sign-up)

Note: The Raspberry PI 4B is recommended .NET runs very nicely on the 2GB base model.  2GB is also realistically enough memory to use Visual Studio Code on the Raspberry PI, allowing you to tinker with the code in-situ.

## Running the demo

To run the demo you will at a minimum need to:

Before you power up your Raspberry PI attach the SenseHAT to the GPIO header. Then power up your Raspberry PI and if it isn't already configure it to safely access the internet (at a minimum you should change the default password and ensure you do a `sudo apt update` and `sudo apt upgrade` to get all the latest patches.  Then on the 'PI install the .NET SDK and clone the `AblyDemo` repo.  Create a free Ably account and make a note of your Ably key.

Open up a terminal window on the PI and  `cd` into the `AblyDemo/AblyGame` directory, you can start the game using `dotnet run -- <your ably key>`.  Then either on the same PI in a second terminal window or on a different computer completely (that also has the .NET SDK installed) `cd` into the `AblyDemo/AblyController` directory and again run `dotnet run -- <your ably key>`.  You should now be able to use your cursor left and right keys to take control of the game.
