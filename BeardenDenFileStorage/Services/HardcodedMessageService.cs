using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BearDenFileStorage
{
    public class HardcodedMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hardcoded message from a service.";
        }
    }
}
