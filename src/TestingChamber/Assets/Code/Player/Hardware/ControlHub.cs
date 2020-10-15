using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Assets.Code.Player.Hardware
{
    public static class ControlHub
    {
        public static IControlScheme[] controlSchemes { get; }
        public static IControlSchemeKeys lastUsedControlScheme { get; set; }
        static ControlHub()
        {
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany((assembly) => assembly.GetTypes())
                .Where((type) => typeof(IControlScheme).IsAssignableFrom(type))
                .ToArray();
            List<IControlScheme> workingSchemes = new List<IControlScheme>();
            for (int i = 0; i < types.Length; i++)
            {
                Type type = types[i];
                try
                {
                    var scheme = (IControlScheme)Activator.CreateInstance(type);
                    workingSchemes.Add(scheme);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(
                        "ERROR: Device could not be initialized: " + type.Name);
                    Debug.WriteLine(ex);
                }
            }
            controlSchemes = workingSchemes.ToArray();
        }
    }
}
