using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public static class Container
    {
        private static Dictionary<Type, object> _stores = null;

        private static Dictionary<Type, object> Stores
        {
            get
            {
                if (_stores == null)
                    _stores = new Dictionary<Type, object>();
                return _stores;
            }
        }

        private static Dictionary<string, object> CreateConstructorParameter(Type targetType)
        {
            Dictionary<string, object> paramArray = new Dictionary<string, object>();

            ConstructorInfo[] cis = targetType.GetConstructors();
            if (cis.Length > 1)
                throw new Exception("target object has more then one constructor,container can't peek one for you.");

            foreach (ParameterInfo pi in cis[0].GetParameters())
            {
                if (Stores.ContainsKey(pi.ParameterType))
                    paramArray.Add(pi.Name, GetInstance(pi.ParameterType));
            }
            return paramArray;
        }

        public static object GetInstance(Type t)
        {
            if (Stores.ContainsKey(t))
            {
                ConstructorInfo[] cis = t.GetConstructors();
                if (cis.Length != 0)
                {
                    Dictionary<string, object> paramArray = CreateConstructorParameter(t);
                    List<object> cArray = new List<object>();
                    foreach (ParameterInfo pi in cis[0].GetParameters())
                    {
                        if (paramArray.ContainsKey(pi.Name))
                            cArray.Add(paramArray[pi.Name]);
                        else
                            cArray.Add(null);
                    }
                    return cis[0].Invoke(cArray.ToArray());
                }
                else if (Stores[t] != null)
                    return Stores[t];
                else
                    return Activator.CreateInstance(t, false);
            }
            return Activator.CreateInstance(t, false);
        }

        public static void RegisterImplement(Type t, object impl)
        {
            if (Stores.ContainsKey(t))
                Stores[t] = impl;
            else
                Stores.Add(t, impl);
        }

        public static void RegisterImplement(Type t)
        {
            if (!Stores.ContainsKey(t))
                Stores.Add(t, null);
        }
    }
}
