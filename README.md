# Project-La-Can
First-year BUT Informatique project (IUT Robert Schuman). C# console application for ferry booking: managing crossings, passengers, vehicles, and generating a JSON reservation file.


1--------

First we have 2 main routes :

Lorient ↔ Groix

Quiberon ↔ Belle-Île

From that we get 4 possible journeys :

Lorient → Groix

Groix → Lorient

Quiberon → Belle-Île

Belle-Île → Quiberon

2--------

These 4 journeys are run by LA CAN, so each one has an id :

id1 → Lorient → Groix

id2 → Groix → Lorient

id3 → Quiberon → Belle-Île

id4 → Belle-Île → Quiberon

These ids are what the program uses internally.

3--------

So the program logic is something like :

ask the user for a reservation name

choose one of the 4 journeys

ask the user for a day of the month

choose a departure hour

hours depend on the journey

they come from a CSV file

we only manage November

4--------

After the journey is chosen, we create a Traversee structure that contains :

liaison → id of the journey (1 to 4)

date → day chosen by the user (formatted as a string)

depart → hour chosen by the user

This is mainly to group all journey info together (and later for JSON).

5--------

Then we ask the user for passengers and vehicles.

Passengers :

last name

first name

category of the passenger (adult, young, child, baby, animal)

each category has a code and a price

Vehicles :

choose a vehicle category (trotinette, bike, car, etc.)

enter the quantity

each vehicle also has a code and a price

6--------

At the end :

show a summary of everything the user entered

journey, date, hour

list of passengers

list of vehicles

calculate the total price

display the final amount