# EasyWakeOnLan

This is a little example of the usage of EasyWakeOnLan that can be usable by including the reference to EasyWakeOnLan.dll

## Usage
```cSharp
string Mac = ...Get the Mac Address....
//Instance the class
EasyWakeOnLanClient WOLClient = new EasyWakeOnLanClient();
//Wake the remote PC
WOLClient.Wake(Mac);
```

|AppVeyor|Travis|
|--------|------|
|[![Build status](https://ci.appveyor.com/api/projects/status/mqqrjcsjutr59flb?svg=true)](https://ci.appveyor.com/project/kabestrus/easywakeonlan)|[![Build Status](https://travis-ci.org/JorTurFer/EasyWakeOnLan.svg?branch=master)](https://travis-ci.org/JorTurFer/EasyWakeOnLan)|