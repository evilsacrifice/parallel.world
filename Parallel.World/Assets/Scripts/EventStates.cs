using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
public class EventStates
{
    private static EventStates _instance;
    private Dictionary<CustomEventTypes, bool> _eventStates;
    public static EventStates Instance
    {
        get
        {
            if (_instance == null)
                _instance = new EventStates();
            return _instance;
        }
    }

    private EventStates()
    {
        GetStatesFromDb();
    }

    private void GetStatesFromDb()
    {
        _eventStates = new Dictionary<CustomEventTypes, bool>();
        //тут должна быть загрузка из базы, или просто начальные состояня
        foreach (var type in Enum.GetValues(typeof(CustomEventTypes)))
        {
            _eventStates.Add((CustomEventTypes)type, false);
        }
    }

    public bool GetState(CustomEventTypes type)
    {
        var state = false;
        return _eventStates.TryGetValue(type, out state) ? false : state;
    }

    public void ChangeState(CustomEventTypes type, bool state)
    {
        _eventStates[type] = state;
    }

    public void InvertState(CustomEventTypes type)
    {
        _eventStates[type] = !_eventStates[type];
    }
}

public enum CustomEventTypes
{
    Movement = 0,
    Blablabla = 1,
    Satan = 2
}