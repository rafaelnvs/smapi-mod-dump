# AutoAnimalDoors
This is a mod created for StardewValley which will automate the animal door opening/closing process for all your barns and coops.

## Features
### Opening animal doors automatically
Your animal doors will open automatically at the time you specified in the config file no matter where your character is in the game world (you will hear the door opening sound). 

If that time never occurs during the day (for instance, you specified 730AM but you used some other mod to set the time to 900AM) the doors will still open unless it is past your specified doors close time. Note: the doors will only ever auto-open once per day.

Doors will not open in the Winter or on Rainy/Thunder Stormy days by defualt, this can be changed in the config file.

You can disable the animal doors opening automatically with a setting in the config file if you would like your doors to auto-close, but not auto-open.

### Closing animal doors automatically
Your animal doors will close automatically at the time you specified in the config file if all your animals are inside. If they are not yet inside, the doors will wait for all the animals to enter their homes before closing any doors. 

If you go to bed before your animal door close time, your animal doors will be closed, and all your animals will be warped back to their homes to keep them safe from attacks ;)

Note: The current implementation closes the animal doors and warps the animals back as soon as you get into bed (even if you select "No" from the "Go to sleep now?" dialog). It is difficult (impossible?) to warp your animals back to safety on time once "Yes" is pressed.

## Config File

The config file is where all the options for this mod can be set. It will be automatically created the first time the game is launched with this mod installed.

You can find it in the mods install directory.

### Values

| Name                      | Type      | Default | Description                                                                  |
|:------------------------- |:--------- |:------- |:---------------------------------------------------------------------------- |
| **AutoOpenEnabled**       | *boolean* | true    | true if doors should automatically open, false if not                        |
| **AnimalDoorOpenTime**    | *integer* | 730     | The time animal doors are scheduled to open (730 = 7:30 am, 1310 = 1:10 pm)  |
| **AnimalDoorCloseTime**   | *integer* | 1800    | The time animal doors are scheduled to close (730 = 7:30 am, 1310 = 1:10 pm) |
| **OpenDoorsWhenRaining**  | *boolean* | false   | true if doors should open even when raining/lightning, false if not          |
| **OpenDoorsDuringWinter** | *boolean* | false   | true if doors should open even during winter, false if not                   |

### Example config.json

```json
{
  "AutoOpenEnabled": false,
  "AnimalDoorOpenTime": 730,
  "AnimalDoorCloseTime": 1800,
  "OpenDoorsWhenRaining": false,
  "OpenDoorsDuringWinter": false
}
```

## Building the Code
This mod ustilizes the SMAPI API. So if you get any issues regarding not being able to resolve StardewModdingAPI. You likely need to do some of the setup described here: http://canimod.com/for-devs/creating-a-smapi-mod
