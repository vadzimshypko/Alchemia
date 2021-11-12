# Architecture #

The main game mechanic is creating new elements from already discovered ones. At the begining of the game only 4 elements are availible. By ddragging 2 elements on one another a player checks if thier combination creates a new element. The goal is to discorever all elements.

Application parts: 
* Data
* Logic
* User interaction

Vocabulary:
* Element
* Combination
* React
* Discovered
* Exploared
* Combination have element(Combination with element)

## Data ##
All data used in the game logic is described in the input __.json__ files. Such files are created manually and must be validated by __data_validation__ module before uploading it to the game package.

During application lauch data is read from the files into collections. Afterwards it can be used during the gameplay.

Data required for the project is devided into 2 groups: __elements__ and __combinations__

See __Entities.md__ for detailed information.

## Logic ## 

Read input from files

### State ###

#### Write ####

#### Read ####

### Logic API functions ###

The following signatures to be detailed after defining objets structure in the code.
  
1. tryCombination(id_name, id_name)

Check whether there is a combination with given 2 elements.

__Input__: 2 strings ```id_name``` - reacting elements
__Output__: a list of strings ```id_name``` - result of the reaction - or ```null``` if there is no such a combination.

2. getAllElements()
3. getDiscoveredElements()
4. getAllCombinationsWith(id_name)  
Get a list of all possible combinations that have given ```id_name``` either as ```input1``` or ```input2```
5. getDiscoveredComdinationsWith(id_name)
6. isExplored(id_name)  
Were all combinations with given element discovered?
7. countDiscoveredElements()
8. countAllElements()
9. countDiscoveredCombination()
10. countAllCombinations()
11. sortDiscoveredElementsByTMSP()
12. sortDiscoveredElementsASC()
13. sortDiscoveredElementsDSC()
14. getElement(id_name)  
Show value of all field for the element with ```id_name```.  
15. getCombination(id_name, id_name)  
Show value of all field for the combination with both ```id_name```s.
16. getDiscoveredElementsWith(some_string)  
Return list of elements that have a ```some_string``` as a part of ```display_name```


