using System;
using System.Collections.Generic;
using UnityEngine.Assertions;

namespace KartRace.Application
{
    public class ServiceLocator
    {
        public static ServiceLocator Instance => instance ?? ( instance = new ServiceLocator() );
        private static ServiceLocator instance;

        public readonly Dictionary<Type, object> services;

        public ServiceLocator()
        {
            services = new Dictionary<Type, object>();
        }

        public void RegisterService<T>( T service )
        {
            var type = typeof( T );
            if( !services.ContainsKey( type ) )
            {
                services.Add( type, service );
                return;
            }
            Assert.IsFalse( services.ContainsKey( type ), $"Service {type} already registered" );
        }

        public T GetService<T>()
        {
            var type = typeof( T );
            if( !services.TryGetValue( type, out var service ) )
            {
                throw new Exception( $"Service {type} not found" );
            }
            return (T)service;
        }

    }
}

