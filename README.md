
# ProfessionalThief

The Professional thief is a Top-Down 2D stealth game where you play as a thief whose aim is to steal special gadgets and money from the mansions. After stealing these gadgets you can also use them to your advantage to easily avoid patrolling guards and cameras.

## Features

1. **Levels** - There are currently three unique levels in the game. The Player has to navigate in a dark indoor environment with very limited visibility.
2. **Collectables** - Players' main objective is to steal a unique gadget in each level plus they can also collect some cash, silver, and gold coins on the way.
3. **Gadgets** - There are three gadgets in the game that are hidden in a special safe. These gadgets can be recharged using batteries that can be obtained from the safes hidden in the mansion.
   1. **Torch** - Increases visibility and lasts a long time than other gadgets.
   2. **Stun Gun** - Disables cameras and guards temporarily and can be recharged using one battery.
   3. **Night Vision Googles** - Gives players the ability to see everything for a short duration of time.

## Design Patterns Used

1. **State Machine** - It used to define enemy movement states like scanning, patrolling and stunned.
2. **Observer Pattern** = It is used to update UI elements and change in game state like win and lose state.
3. **Singleton** - Added Singleton classes to create Game and Level managers.

## Demo

[Click Here](https://vik7am.itch.io/professional-thief) to play WebGL Build.
