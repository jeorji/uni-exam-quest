using System;
using System.Collections.Generic;

public static class Mediator
{
    private static Dictionary<Type, List<Action<object>>> _registeredActions = new Dictionary<Type, List<Action<object>>>();
    private static Dictionary<string, List<Action<object>>> _registeredPropertyActions = new Dictionary<string, List<Action<object>>>();
    public static void Register<T>(Action<T> callback)
    {
        if (!_registeredActions.ContainsKey(typeof(T)))
        {
            _registeredActions[typeof(T)] = new List<Action<object>>();
        }

        _registeredActions[typeof(T)].Add(o => callback((T)o));
    }

    public static void Send<T>(T message)
    {
        if (_registeredActions.ContainsKey(typeof(T)))
        {
            foreach (var action in _registeredActions[typeof(T)])
            {
                action(message);
            }
        }
    }

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
