# Major Issues with the Project: 

1 - Checking for Unsuccessful/Empty API Calls

I ran into an issue for a while that involved not being able to check whether or not the API was returning any actual data based on what was searched. I wanted my system to force a reentry of data if there was not an applicable fight in the API, so the capability to do this was necessary. The problem with actually implementing this has to do with the fact that I consistently struggled to find a way to return a string or list of strings from the API Call method, as the return type was of Task type. I researched several potential solutions (Including changing the return type to Task<List<string>> and Task<string>), but any form of implementation or alteration of the method's return type resulted in unsatisfactory results. In order to solve this, I ended up checking for the length of the JSON return to see if it was less than 50 characters, as 50 characters were not enough to hold any properly formatted or accurate data, so this would filter out all invalid or empty results.

2 - Pulling from List of JSON Objects and their Attributes



3 - Cleaning Up the JSON (HTML Tags, Whitespaces, Other Invalid Data)



4 - Changing the Console Output Color of an Object from the ToString

