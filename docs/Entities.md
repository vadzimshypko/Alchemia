# Input data entities. Rulls and files format #

### Elements ###

Elements are units in the game. They are described in __elements.json__.
```
#elements.json
{
	"elements":[
	{
		"id_name": "primordail_soup",
		"display_name": "primordail soup",
		"image": "prim_soup.png"
	},
	{
		#another element
	}
]}
```

|Field name|Description|Value requrenments|
|:-|:-|:-|
|id_name| String indentifier of the element. Must be unique thought out the file. | Only latin latters. No spaces. Not null.|
|display_name| Name of the element that is shown to a user||
|image| Relative path to the element icon inside images directory|| 

### Combinations ###

Combinations are rules, which describe what elementes interactes with each other and what elements appear as a result of such a reaction.
A combination consists of a pair of *input* elements and array *output* - one or several elements created by the *input* reaction.

Rules:
* All values of ```input1```, ```input2```, ```output``` must be exiting ```id_name``` from __elements.json__
* A combination can be described by the following formula ```input1 + input2 = output ``` , which means order in which input elements are specified doesn't change interation logic 
* ```input1``` may be equal to ```input2```
* ```output``` can not contain to equal element

Combinations are described in __combinations.json__.

```
#combinations.json
{
	"combinations": [
	{
		"input1": "water",
		"input2": "fire",
		"output":[
					"steam"
				 ]
	},
	{
		"input1": "human",
		"input2": "human",
		"output":[
					"child",
					"family"
				 ]
	}
]}
```