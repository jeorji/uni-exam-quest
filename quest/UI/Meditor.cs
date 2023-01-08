using System;
using System.Collections.Generic;

public static class Mediator
{
    private static Dictionary<string, List<Action<object>>> _registeredPropertyActions = new Dictionary<string, List<Action<object>>>();

    public static void RegisterPropertyChanged<T>(Action<T> callback, string propertyName)
    {
        if (!_registeredPropertyActions.ContainsKey(propertyName))
        {
            _registeredPropertyActions[propertyName] = new List<Action<object>>();
        }

        _registeredPropertyActions[propertyName].Add(o => callback((T)o));
    }

    public static void SendPropertyChanged<T>(string propertyName, T newValue)
    {
        if (_registeredPropertyActions.ContainsKey(propertyName))
        {
            foreach (var action in _registeredPropertyActions[propertyName])
            {
                action(newValue);
            }
        }
    }
}
