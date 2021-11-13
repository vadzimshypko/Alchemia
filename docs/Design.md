# Architecture #

The main game mechanic is creating new elements from already discovered ones. At the begining of the game only 4 elements are availible. By ddragging 2 elements on one another a player checks if thier combination creates a new element. The goal is to discorever all elements.

Application parts: 
* Data
* Logic
* User interaction

Vocabulary:
* Element
* Combination
* React - action done by 2 elements draged one on another that create a new element(as the according combination exists).
* Discovered 
* Exploared - all combinations that have the element as an input were discovered.`
* Combination have element(Combination with element) - a combination as at least one field(```input1``` or ```input2```) equal to the element ``id_name```

## Data ##
All data used in the game logic is described in the input __.json__ files. Such files are created manually and must be validated by __data_validation__ module before uploading it to the game package.

During application lauch data is read from the files into collections. Afterwards it can be used during the gameplay.

Data required for the project is devided into 2 groups: __elements__ and __combinations__

See __Entities.md__ for detailed information.

## Logic ## 

### Read input from files ###

 1. Read __elements.json__ element by element into ```HashMap<String, Element>  elements``` . Each HashMap entity has:
 * ```id_name``` value from json as a key
 * instance of class ```Element``` containing all the element fields from the file as a value. Any additional fields can be added to the ```Element``` object if nessesary. For instance, field ```isDiscovered``` doesn't exists in __elements.json__, but is read  from a player status file.    
 
 2. Read __combinations.json__ and process each record using the algorithm:  
 * read ```output``` field into a ```List<String>```
 * create an instance of class ```Combination``` passing ```input1```, ```input2``` and  ```List<String> output```
 * in ```elements``` map find elements with ```id_name``` equal to ```input1``` or ```input2```. Update found elements with a link to the combination
 * put a combination into ```HashSet<Combination> combinations```

### State ###

During the game log a player progress.

#### Write ####
Once  a new element is discovered write its hash into __elements.state__. Add the hash of the combination used to discovery into __collections.state__.

#### Read ####

During application lauch read state files after __*.json__ files are read:
* for each hash in __elements.state__ find the according element in ```HashMap elements``` and set the field ```isDiscovered``` to ```ture```.
* update ```HashSet combinations``` in the same way reading __combinations.state__


### Game core API functions ###

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


