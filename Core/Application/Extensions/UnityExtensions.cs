using System;
using System.Collections.Generic;
using Unity;

namespace Umc.VigiFlow.Application.Extensions
{
    public static class UnityExtensions
    {
        public static void RegisterAllTypesForOpenGeneric(this IUnityContainer container, Type openGenericType, IEnumerable<Type> types)
        {
            if (!openGenericType.IsGenericTypeDefinition)
                throw new ArgumentException("typeToRegister must be an open generic type", nameof(openGenericType));

            foreach (Type type in types)
            {
                if (openGenericType.IsInterface)
                    RegisterInterfaceTypes(container, openGenericType, type, type);
                else
                    RegisterBaseTypes(container, openGenericType, type, type);
            }
        }

        private static void RegisterInterfaceTypes(IUnityContainer container, Type openGenericType, Type targetType, Type typeToRegister)
        {
            foreach (Type interfaceType in targetType.GetInterfaces())
                if (interfaceType.IsGenericType && !interfaceType.ContainsGenericParameters && openGenericType.IsAssignableFrom(interfaceType.GetGenericTypeDefinition()))
                    container.RegisterType(interfaceType, typeToRegister, typeToRegister.Name);
        }

        private static void RegisterBaseTypes(IUnityContainer container, Type openGenericType, Type targetType, Type typeToRegister)
        {
            if (targetType.BaseType != null && targetType.BaseType != typeof(object))
                if (targetType.BaseType.IsGenericType && openGenericType.IsAssignableFrom(targetType.BaseType.GetGenericTypeDefinition()))
                    container.RegisterType(targetType.BaseType, typeToRegister);
                else
                    RegisterBaseTypes(container, openGenericType, targetType.BaseType, typeToRegister);
        }
    }
}
