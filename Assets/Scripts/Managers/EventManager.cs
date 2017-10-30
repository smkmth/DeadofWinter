using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
/// <summary>
/// Dont touch this class! it just some weird vodoo which handles unity events. creates a singlton 
/// instance of event manager,a dictonary of events, allows you to stop listening and start
/// listening to events, and to run methods from events. 
/// DO NOT SET UP EVENTS INSIDE THIS CLASS
/// this class just manages events. You can create a new even as shown in ItemActions.
/// </summary>
public class EventManager : MonoBehaviour {

	private Dictionary <string, UnityEvent> eventDictionary;

	public static EventManager eventManager;

	public static EventManager instance 

	{
		get {

			if (!eventManager) {

				eventManager = FindObjectOfType (typeof(EventManager)) as EventManager;

				if (!eventManager) {

					Debug.LogError ("No Active Event Manager script on a game object in scene ");
				}
				else 
				{
					eventManager.Init();

				}
				


			}
			return eventManager;
		}

	}

	void Init()
	{
		if (eventDictionary == null) {
			eventDictionary = new Dictionary<string, UnityEvent> ();
		}

	}

	public static void StartListening (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.AddListener (listener);

		} else {
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);

		}

	}

	public static void StopListening (string eventName, UnityAction listener){
		if (eventManager == null)
			return;
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) 
		{
			thisEvent.RemoveListener (listener);

		}

	}
	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent)) {
			thisEvent.Invoke ();
		}

	}






}