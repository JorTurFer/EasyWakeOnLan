# EasyWakeOnLan

This is a little example of the usage of EasyWakeOnLan that can be usable by including the reference to EasyWakeOnLan.dll and including a reference to Net Standard 1.5, but the easiest mode is including the reference to this library as nuget packet

## Usage Sync
```cSharp
string Mac = ...Get the Mac Address....
//Instance the class
EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
//Wake the remote PC
WOLClient.Wake(Mac);
```

## Usage Async
```cSharp
string Mac = ...Get the Mac Address....
//Instance the class
EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
//Wake the remote PC
WOLClient.WakeAsync(Mac);
```

## Dependency Inyection
Register IEasyWakeOnLanCient using EasyWakeOnLanCient

|AppVeyor|Travis|
|--------|------|
|[![Build status](https://ci.appveyor.com/api/projects/status/mqqrjcsjutr59flb?svg=true)](https://ci.appveyor.com/project/kabestrus/easywakeonlan)|[![Build Status](https://travis-ci.org/JorTurFer/EasyWakeOnLan.svg?branch=master)](https://travis-ci.org/JorTurFer/EasyWakeOnLan)|

## Get it from NuGet
[![NuGet][main-nuget-badge]][main-nuget]
[![NuGet][main-nuget-download]][main-nuget]

[main-nuget]: https://www.nuget.org/packages/EasyWakeOnLan/
[main-nuget-badge]: https://img.shields.io/nuget/v/EasyWakeOnLan.svg
[main-nuget-download]: https://img.shields.io/nuget/dt/EasyWakeOnLan.svg
