using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TouristGuide.Core.Models;
using System.Text;

namespace TouristGuide.Service
{
    [ServiceContract]
    public interface IWPService
    {
        [OperationContract]
        List<Attraction> GetAttractions(string place, int start, int count);
    }
}
