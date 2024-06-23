using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using UnityEngine;

namespace Loyufei 
{
    public class Entity<TData> : IEntity<TData> 
    {
        public Entity(object identity, TData data)
        {
            Identity = identity;
            Data     = data;
        }

        public virtual TData  Data     { get; protected set;  }
        public virtual object Identity { get; protected set;  }
    }

    [Serializable]
    public class Entity<TIdentity, TData> : Entity<TData>
    {
        public Entity(TIdentity identity, TData data) : base(identity, data)
        {
            
        }

        [SerializeField]
        protected TIdentity _Identity;
        [SerializeField]
        protected TData     _Data;
        
        public override object Identity 
        {
            get => _Identity;

            protected set => _Identity = value.To<TIdentity>();
        } 

        public override TData  Data 
        {
            get => _Data;

            protected set => _Data = value;
        }
    }

    public class EntityAsset<TIdentity, TData> : ScriptableObject, IEntity<TData> 
    {
        [SerializeField]
        protected TIdentity _Identity;
        [SerializeField]
        protected TData _Data;

        public TIdentity Identity => _Identity;
        public TData     Data     => _Data;

        object IIdentity.Identity => _Identity;
    }
}
