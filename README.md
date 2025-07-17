Basic setup (10 min)
Time system design (15 min)
Implement Time system(1 hr)

In game collider for Time system(45min)

* forget to use collider

Basic player attack(30 Min)

Enemy movement (30min)

* Having trouble detect combat state

Detect combat state + minislime spawning after death (1 hr)

adjust combat script + health system(40 min)



design inventory system (1 hr)

from now, learning from this tutorial https://youtu.be/oJAE6CbsQQA?si=DbsIyHM7y\_Y0vfOS

* something not in tutorial but added

-> separate stacked limit

-> Item bin

Approx Time for everything related to inventory (6 hr)



Making player can attack only in combat



crafting system design (1 hr)

add where item can be craft

crafting system (1 hr)



\[ Challenge ]

* didn't have function to change time from today morning -> tomorrow morning yet

Idea -> add code that add inGameDayCount in TimeController if time of the day player want to change is same as current time of the day



* Slime AI

Problem -> no idea on how should I make slime stop and charge for attack at attack range

-> sometime jumping range is different



* Fining something in inventory require full loop every time

Idea -> having something similar to C++Dictionary/map to keep track of item player have separately



* drag and drop to stack item

Idea -> add code that check when drop if it can be stack



* Craft when material is enough but in separate slot

Idea -> loop check if all the material in inventory is enough and loop again to delete item



* when open Inventory in combat, every click still cast a spell

Idea -> changing condition of attacking or make player unable to open inventory during combat.



* Animation sprite have only walking toward right side

Idea -> adding sprite flip.X in animation (Tried, but get flicking sprite as result) or manual flip sprite



* Animation isn't smooth when attack rapidly

Idea -> play around with animation condition more, making attack animation play again every time clicking without need to have exit time

