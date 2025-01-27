﻿using System;
using System.Collections.Generic;
using System.Text;
using TodoIt.Model;

namespace TodoIt.Data
{
    public class People
    {
	private static Person[] personArray = new Person[0];

	public int Size()
	{
	    return personArray.Length;
	}

	public Person[] FindAll()
	{
	    return personArray;
	}

	public Person FindById(int personId)
	{
	    Person theItem = null;

	    foreach (Person item in personArray)
	    {
		if (item.PersonId == personId)
		    theItem = item;
	    }

	    return theItem;
	}

	public Person AddPerson(string firstName, string lastName)
	{
	    Person addPerson = new Person(firstName, lastName, PersonSequencer.nextPersonId());
	    int sizeofPersonArray = Size(); // Get incrementing size of Array.

	    Array.Resize(ref personArray, sizeofPersonArray + 1); // Increase the size of Array when add new person object
	    personArray[sizeofPersonArray] = addPerson; // Adding person object to Array.
	    return addPerson;
	}

	public bool PersonAfterRemove(int personId)
	{
	    bool     personToBeRemovedFound = false;
	    Person[] personArrayAfterRemove = new Person[0];
	    int      indxPersonArray = 0;
	    int      indxPersonArrayAfterRemove = 0;

	    while ( indxPersonArray < personArray.Length )
	    {
		if ( personArray[indxPersonArray].PersonId == personId) // den här Person ska inte med men mata inte fram indxPersonArrayAfterRemove
		{
		    indxPersonArray++;
		    personToBeRemovedFound = true;
		}
		else
		{
		    Array.Resize(ref personArrayAfterRemove, personArrayAfterRemove.Length + 1);
		    personArrayAfterRemove[indxPersonArrayAfterRemove] = personArray[indxPersonArray];
		    indxPersonArray++;
		    indxPersonArrayAfterRemove++;
		}
	    }
	    personArray = personArrayAfterRemove;
	    return personToBeRemovedFound;
	}

	public void Clear()
	{
	    personArray = new Person[0];
	    // Array.Clear(personArray, 0, personArray.Length);
	}
    }
}
