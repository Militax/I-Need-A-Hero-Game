using System;
using System.Collections.Generic;


[Serializable]
public class ActivationDevicesData
{
    [Serializable]
    public class Combination
    {
        public string colliderTag;
        public string active;
        public string inactive;
    }
    public Combination current;
    public bool HasBeenPressed;
    public bool IsActive;

}
