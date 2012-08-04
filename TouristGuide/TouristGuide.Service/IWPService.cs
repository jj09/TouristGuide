using System;
using System.ServiceModel;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using TouristGuide.Core.Models;
using System.Text;
using System.ServiceModel.Web;

namespace TouristGuide.Service
{
    [ServiceContract]
    public interface IWPService
    {
        [OperationContract]
        [WebInvoke(BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<Attraction> GetAttractions(string place, int start, int count);
    }
}
