using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Loyufei.DomainEvents
{
    public class ResponseEvent<Param1> : DomainEventBase
    {
        public ResponseEvent(Action<Param1> response) 
        {
            Response = response;
        }

        public Action<Param1> Response { get; }
    }

    public class ResponseEvent<Param1, Param2> : DomainEventBase
    {
        public ResponseEvent(Action<Param1, Param2> response)
        {
            Response = response;
        }

        public Action<Param1, Param2> Response { get; }
    }

    public class ResponseEvent<Param1, Param2, Param3> : DomainEventBase
    {
        public ResponseEvent(Action<Param1, Param2, Param3> response)
        {
            Response = response;
        }

        public Action<Param1, Param2, Param3> Response { get; }
    }
}