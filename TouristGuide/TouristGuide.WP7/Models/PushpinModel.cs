// ----------------------------------------------------------------------------------
// Microsoft Developer & Platform Evangelism
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// ----------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
// ----------------------------------------------------------------------------------

using System;
using System.Device.Location;

namespace TouristGuide.WP7.Models
{
    /// <summary>
    /// Represents a pushpin data model.
    /// </summary>
    public class PushpinModel
    {
        /// <summary>
        /// Gets or sets the pushpin location.
        /// </summary>
        public GeoCoordinate Location { get; set; }

        /// <summary>
        /// Gets or sets the pushpin icon uri.
        /// </summary>
        public Uri Icon { get; set; }

        /// <summary>
        /// Gets or sets the pushpin type name.
        /// </summary>
        public string TypeName { get; set; }

        public PushpinModel Clone(GeoCoordinate location)
        {
            return new PushpinModel
            {
                Location = location,
                TypeName = TypeName,
                Icon = Icon
            };
        }
    }
}
