# WakeOnLan

This is a little example of the usage of WakeOnLan that can be usable by including the reference to WakeOnLan.dll

## Usage
```cSharp
string Mac = ...Get the Mac Address....
//Instance the class
WakeOnLanClient WOLClient = new WakeOnLanClient();
//Wake the remote PC
WOLClient.Wake(Mac);
```

|AppVeyor|Travis|
|--------|------|
|[![Build status](https://ci.appveyor.com/api/projects/status/9c13yq87v5fvp006?svg=true)](https://ci.appveyor.com/project/kabestrus/wakeonlan)|[![Build Status](https://travis-ci.org/JorTurFer/WakeOnLan.svg?branch=master)](https://travis-ci.org/JorTurFer/WakeOnLan)|