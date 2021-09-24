# AblyDemo
Ably .NET IoT Raspberry PI Game Demo

This repo contains a simple game that runs on a Raspberry PI with the SenseHat attached.  The game is written in .NET 5, using the Internet of Things (IoT) extensions and employs the Ably realtime service to allow the games controller to run remotely; either in a different process on the Raspberry PI running the main game loop, or on a completely different machine: for example a Apple Mac, that also has .NET installed.

## Parts required

To run this you will need:

1. .NET, available [here](https://dotnet.microsoft.com/download)
2. The .NET IoT extensions, available [here](https://github.com/dotnet/iot)
3. A Raspberry PI, the Raspberry PI 4B is [recommended](https://www.raspberrypi.org/products/raspberry-pi-4-model-b/)
4. A Raspberry PI [SenseHAT](https://www.raspberrypi.org/products/sense-hat/)
5. The [Ably API](https://www.nuget.org/packages/ably.io/) along with a [free Ably account.](https://ably.com/sign-up)

### Updating your OS

Before proceeding its important to emphasize that if you haven't already you should really change your PIs default password, particularly when connecting it to any kind of network.  Secondly, make sure your OS image is up to date with all the latest security fixes and updates, you can do this using:

```
sudo apt-get update
sudo apt-get upgrade
```

### Installing .NET

At the time of writing when installing .NET on the Raspberry PI the Microsoft installer will deploy the 3.x LTS version of .NET.  We want to use the newer 5.x version.  You can do this using:

```
wget -O - https://raw.githubusercontent.com/pjgpetecodes/dotnet5pi/master/install.sh | sudo bash
```

Refer to [Install and use .NET 5 on the Raspberry PI](https://www.petecodes.co.uk/install-and-use-microsoft-dot-net-5-with-the-raspberry-pi/)

Note: The Raspberry PI 4B is recommended .NET runs very nicely on the 2GB base model.  The code was developed on the 8GB model.  Note that the *oldest* Raspberry PI supported by .NET is the 3.  However this is not recommended due to the memory limitations of the '3.

## Running the demo

If you haven't done so already you will need to create a free Ably account and be sure to have your Ably Key handy.

Assuming the SenseHAT is plugged into your PI and .NET is installed, clone the [Demo Repo](https://github.com/ably-labs/DotNetRaspberryPiAblyDemo) to the PI and then `cd` into the `DotNetRaspberryPiAblyDemo/AblyGame` directory.

Now put another clone of the [Demo Repo](https://github.com/ably-labs/DotNetRaspberryPiAblyDemo) on a second machine and then `cd` into the `DotNetRaspberryPiAblyDemo/AblyController` directory.

We'll use the `dotnet run` command, passing in our Ably Key, to start both the *Controller* and the *Game*, enter the following at the command prompt in the respective directory on each machine:

```
dotnet run -- <your Ably Key>
```

You should now be able to use your cursor *left* and *right* keys on the *Controller* machine to interact with the *Game* running on the PI.
