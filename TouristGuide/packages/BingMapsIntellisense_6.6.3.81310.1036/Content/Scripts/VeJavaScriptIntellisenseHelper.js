// Bing Maps JavaScript Intellisense Helper v6.3081310.1036
VEAltitudeMode = function()
{
    /// <summary>ENUM: Defines the altitude of a point on the globe.</summary>
    /// <field name="Default">The altitude is meters above ground level.</field>        
    /// <field name="Absolute">The altitude is meters above the WGS 84 ellipsoid.</field>  
    /// <field name="RelativeToGround">The altitude is meters above ground level.</field>  
};

VEAltitudeMode.Default = null;
VEAltitudeMode.Absolute = null;
VEAltitudeMode.RelativeToGround = null;

﻿VEBirdseyeScene = function()
{
    /// <summary>Contains the information about a specific bird's eye image.</summary>
}

VEBirdseyeScene.prototype = 
{
    ContainsLatLong: function(Latlong)
    {
        /// <summary>Determines whether the location specified by a VELatLong Class object is within the current VEBirdseyeScene object.</summary>
        /// <param name="Latlong" type="VELatLong">A VELatLong Class object. Required.</param>
        /// <returns type="Boolean">A Boolean value. True if the location specified by the VELatLong object is within the bounds of the VEBirdseyeScene object.</returns>        
    },
    
    ContainsPixel: function(x, y, zoomLevel)
    {
        /// <summary>Determines whether a specified pixel is within the current VEBirdseyeScene object.</summary>
        /// <param name="x" type="Number">The X component of the pixel. Required.</param>
        /// <param name="y" type="Number">The Y component of the pixel. Required.</param>
        /// <returns type="Boolean">A Boolean value. True if the specified pixel is within the bounds of the VEBirdseyeScene object.</returns>        
    },
    
    GetBoundingRectangle: function()
    {
        /// <summary>Returns an unencrypted and rounded off bounding rectangle for the VEBirdseyeScene object.</summary>
        /// <returns type="VELatLongRectangle">A VELatLongRectangle Class object containing the bounding rectangle.</returns>        
    },
    
    GetHeight: function()
    {
        /// <summary>Returns the height of the image in the current VEBirdseyeScene object, in pixels, at maximum resolution.</summary>
        /// <returns type="Number">The height in pixels.</returns>        
    },
    
    GetID: function()
    {
        /// <summary>Returns the ID of the current VEBirdseyeScene object.</summary>
        /// <returns type="Number">The scene ID as an integer.</returns>        
    },
    
    GetOrientation: function()
    {
        /// <summary>Returns the orientation (VEOrientation Enumeration) of the current VEBirdseyeScene object.</summary>
        /// <returns type="VEOrientation">The VEOrientation Enumeration value.</returns>        
    },
    
    // Not officialy supported anymore
    GetThumbnailFilename: function()
    {
        /// <summary>(NOT OFFICIAL) Returns the file name of the thumbnail image associated with the current VEBirdseyeScene object.</summary>
        /// <returns type="String">The URL of the thumbnail image.</returns>        
    },
    
    GetWidth: function()
    {
        /// <summary>Returns the width of the image in the current VEBirdseyeScene object, in pixels, at maximum resolution.</summary>
        /// <returns type="Number">The width in pixels.</returns>        
    },
    
    LatLongToPixel: function(LatLong, zoomLevel)
    {
        /// <summary>Converts a VELatLong Class object (latitude/longitude pair) to the corresponding pixel on the map.</summary>
        /// <param name="LatLong" type="VELatLong">A VELatLong Class object, which contains the latitude and longitude of a point. This method also accepts an encrypted VELatLong object, as supplied by the VEBirdseyeScene.PixelToLatLong Method.</param>
        /// <param name="zoomLevel" type="Number">The zoom level of the current map view</param>        
        /// <returns type="VEPixel">A pixel location of the VELatLong Class point. This object has two properties, x and y.</returns>        
    },
    
    PixelToLatLong: function(pixel, zoomLevel)
    {
        /// <summary>Converts a point in the bird's eye scene to an encrypted latitude/longitude value.</summary>
        /// <param name="pixel" type="VEPixel">A VEPixel Class object representing a pixel location on the map</param>
        /// <param name="zoomLevel" type="Number">The zoom level of the current map view</param>        
        /// <returns type="String">A String value that represents an encrypted VELatLong object.</returns>        
    }   
}

﻿VEClusteringOptions = function() {
/// <summary>Contains the options for customizing a pushpin cluster display.</summary>
/// <field name="Icon">A VECustomIconSpecification Class which describes the icon representing the pushpin cluster.</field>
/// <field name="Callback">The name of the function called when clustering changes.</field>
};

VEClusteringOptions.prototype = {
    Icon: null,
    Callback: null
};
﻿VEClusteringType = function() {
/// <summary>ENUM: An enumeration of pushpin clustering algorithms.</summary>
/// <field name="None">No pushpin clustering</field>
/// <field name="Grid">A simple clustering algorithm</field>
};

VEClusteringType.None = null;
VEClusteringType.Grid = null;﻿VEClusterSpecification = function() {
    /// <summary>Contains the shape objects and location of a pushpin cluster.</summary>
    /// <field name="Shapes">An array of VEShape Class items representing the pushpins in a pushpin cluster.</field>
    /// <field name="LatLong">A VELatLong Class object indicating the center of the pushpin cluster.</field>
};

VEClusterSpecification.prototype = {
    Shapes: null,
    LatLong: null,
    
    GetClusterShape: function() {
        /// <summary>Returns a VEShape Class that represents the pushpin cluster.</summary>
    }
};
﻿VEColor = function(r, g, b, a) 
{
    /// <summary>Initializes a new instance of the VEColor object.</summary>
    /// <param name="r" type="Number">The red component value. Valid values range from 0 through 255.</param>
    /// <param name="g" type="Number">The green component value. Valid values range from 0 through 255.</param>
    /// <param name="b" type="Number">The blue component value. Valid values range from 0 through 255.</param>
    /// <param name="a" type="Number">The alpha (transparency) component value. Valid values range from 0.0 through 1.0.</param>
    /// <field name="R" type="Number">Specifies the red component value. Valid values range from 0 through 255.</field>
    /// <field name="G" type="Number">Specifies the green component value. Valid values range from 0 through 255.</field>
    /// <field name="B" type="Number">Specifies the blue component value. Valid values range from 0 through 255.</field>
    /// <field name="A" type="Number">Specifies the alpha (transparency) component value. Valid values range from 0.0 through 1.0.</field>
}

VEColor.prototype =
{   
    R: null,
    G: null,
    B: null,
    A: null
}

﻿VECustomIconSpecification = function()
{
    /// <summary>Initializes a new instance of the VECustomIconSpecification.</summary>   
    /// <field name="BackColor" type="VEColor">A VEColor object representing the icon's background and transparency.</field>
    /// <field name="CustomHTML" type="String">Custom HTML representing the pin's appearance. 2D only.</field>    
    /// <field name="ForeColor " type="VEColor">A VEColor object representing the icon's text color and transparency.</field>
    /// <field name="Image" type="String">A String representing the URL of an image file.</field>  
    /// <field name="ImageOffset" type="VEPixel">A VEPixel object representing the image's offset from the icon's anchor.</field>
    /// <field name="TextBold" type="Boolean">Specifies whether the text for the icon should be bold.</field>
    /// <field name="TextContent" type="String">The actual text to display for the icon.</field>
    /// <field name="TextFont" type="String">A String containing the name of the font to use for the icon text.</field>
    /// <field name="TextItalics" type="Boolean">Specifies whether the text for the icon should be italic.</field>
    /// <field name="TextOffset" type="VEPixel">A VEPixel object representing the amount to offset text from the top left corner.</field>
    /// <field name="TextSize " type="Number">Specifies the size at which to display text, in points.</field>
    /// <field name="TextUnderline" type="Boolean">Specifies whether the text for the icon should be underlined.</field>
};

VECustomIconSpecification.prototype =
{  
    BackColor: null,
    CustomHTML: null,
    ForeColor: null,
    Image: null,
    ImageOffset: null,
    TextBold: null,
    TextContent: null,
    TextFont: null,
    TextItalics: null,
    TextOffset: null,
    TextSize: null,
    TextUnderline: null
}

﻿VEDashboardSize = function()
{
    /// <summary>ENUM: An enumeration that represents the size and type of dashboard to be displayed on the map.</summary>
    /// <field name="Normal">This is the dashboard that is used by default.</field>        
    /// <field name="Small">This is a dashboard smaller than the default: it only contains zoom-out (+) and zoom-in (-) buttons and road, aerial, and hybrid buttons for changing the map style.</field>  
    /// <field name="Tiny">This is the smallest dashboard option available. This dashboard only contains zoom-out (+) and zoom-in (-) buttons.</field>  
};

VEDashboardSize.Normal = null;
VEDashboardSize.Small = null;
VEDashboardSize.Tiny = null;

﻿VEDataType = function()
{
    /// <summary>ENUM: An enumeration of shape layer data types.</summary>
    /// <field name="GeoRSS">This represents a GeoRSS data import.</field>        
    /// <field name="VECollection">This represents a Live Search Maps Collection (http://maps.live.com) import.</field>  
    /// <field name="ImportXML">This represents a KML data import.</field>  
};

VEDataType.GeoRSS = null;
VEDataType.VECollection = null;
VEDataType.ImportXML = null;

﻿VEDistanceUnit = function()
{
    /// <summary>ENUM: An enumeration of the distance unit used for generating routes and itineraries.</summary>
    /// <field name="Miles">Generates route information in miles.</field>        
    /// <field name="Kilometers">Generates route information in kilometers.</field>  
};

VEDistanceUnit.Miles = null;
VEDistanceUnit.Kilometers = null;

﻿VEException  = function()
{
    /// <summary>Contains the exception information for the map control.</summary>
    /// <field name="message">A text description of the exception.</field>        
    /// <field name="name">The name of the exception.</field>  
    /// <field name="source">The source object that caused the exception.</field>  
};

VEException.prototype =
{
    message: null,
    name: null,
    source: null
}

﻿VEFailedShapeRequest = function()
{
    /// <summary>ENUM: Defines a list of the actions on how to draw the polygons or the polylines whose points exceed the maximum limit or when a request to the server fails.</summary>
    /// <field name="DoNotDraw">Do not draw the shape.</field>        
    /// <field name="DrawInaccurately">Draw the shape inaccurately.</field>  
    /// <field name="QueueRequest">Resubmit the drawing request.</field>  
};

VEFailedShapeRequest.DoNotDraw = null;
VEFailedShapeRequest.DrawInaccurately = null;
VEFailedShapeRequest.QueueRequest = null;

﻿VEFindResult  = function()
{
    /// <summary>A single "what" result returned from a VEMap.Find Method search.</summary>
    /// <field name="Description">The description of the found result.</field>        
    /// <field name="IsSponsored">A Boolean value that indicates whether the found result is a paid advertisement.</field>  
    /// <field name="LatLong">A VELatLong Class object that represents the location of the found result.</field>  
    /// <field name="Name">The name of the found result.</field>
    /// <field name="Phone">The telephone number of the found result. </field>
    /// <field name="FindType">Gets or sets the VEFindType Enumeration that represents the type of Find that was performed.</field>  
    /// <field name="Shape">A reference to the VEShape Class object corresponding to this FindResult object. The VEShape object represents the result's pushpin displayed on the map.</field>
};

VEFindResult.prototype =
{
    Description: null,
    IsSponsored: null,
    LatLong: null,
    Name: null,
    Phone: null,
    FindType: null,
    Shape: null
}

﻿VEFindType = function()
{
    /// <summary>ENUM: An enumeration of search types.</summary>
    /// <field name="Businesses">Performs a business search.</field>        
};

VEFindType.Businesses = null;

﻿VEGeocodeLocation = function()
{
    /// <summary>A location used to interpolate a found result for a location search.</summary>
    /// <field name="LatLong">A VELatLong Class object specifying the latitude and longitude of the location.</field>        
    /// <field name="Precision">A VELocationPrecision Enumeration value specifying the precision of the location.</field> 
};

VEGeocodeLocation.prototype =
{
    LatLong : null,
    Precision : null
}

﻿VEGeocodeOptions = function ()
{
    /// <summary>Contains additional geocoding options for the VEMap.Geocode Method.</summary>
    /// <field name="SetBestMapView ">A Boolean value that specifies whether the map control moves the view to the first location match. The default value is true.</field>        
    /// <field name="UseDefaultDisambiguation">A Boolean value indicating whether to show the disambiguation dialog if there is more than one result with high match confidence. The default value is true.</field> 
};

VEGeocodeOptions.prototype =
{
    SetBestMapView: null,
    UseDefaultDisambiguation: null
}

﻿VEImageryMetadata = function() {
    /// <summary>Contains information about the specified imagery.
    /// <field name="DateRangeStart">A string specifying the start date of the date range when the imagery was created.</field>
    /// <field name="DateRangeEnd">A string specifying the end date of the date range when the imagery was created.</field>
};

VEImageryMetadata.prototype = {
    DateRangeStart: null,
    
    DateRangeEnd: null
};

﻿VEImageryMetadataOptions = function() {
    /// <summary>Contains the options that represent the imagery.</summary>
    /// <field name="LatLong">A VELatLong Class object specifying the center of the map view. Optionsl. Defaults to the center of the current map view.</field>
    /// <field name="MapStyle">A VEMapStyle Enumeration value specifying the map style. Optional. Defaults to the current map style.</field>
    /// <field name="ZoomLevel">An integer specifying the zoom level. Optional. Defaults to the current zoom level.</field>
};

VEImageryMetadataOptions.prototype = {
    LatLong: null,
    
    MapStyle: null,
    
    ZoomLevel: null
};

﻿VELatLong = function(latitude, longitude, altitude, altitudeMode)
{
    /// <summary>Initializes a new instance of the VELatLong Class.</summary>
    /// <param name="latitude" type="Number">The latitude of a single point on the globe.</param>
    /// <param name="longitude" type="Number">The longitude of a single point on the globe.</param>
    /// <param name="altitude" type="Number">The altitude of a single point on the globe.</param>
    /// <param name="altitudeMode" type="VEAltitudeMode">A VEAltitudeMode Enumeration value representing the mode in which an altitude is represented.</param>
    /// <field name="Altitude">Specifies the altitude of a single point on the globe.</field>        
    /// <field name="AltitudeMode">Specifies the mode in which an altitude is represented.</field>        
    /// <field name="Latitude">Specifies the latitude of a single point on the globe.</field>        
    /// <field name="Longitude">Specifies the longitude of a single point on the globe.</field>        
}

VELatLong.prototype = 
{
    Altitude: null,
    AltitudeMode: null,
    Latitude: null,
    Longitude: null,
    
    SetAltitude: function(altitude, mode)
    {
        /// <summary>Initializes a new instance of the VELatLong Class.</summary>
        /// <param name="altitude" type="Number">The altitude of a single point on the globe.</param>
        /// <param name="altitudeMode" type="VEAltitudeMode">A VEAltitudeMode Enumeration value representing the mode in which an altitude is represented.</param>
    }
}

﻿VELatLongRectangle = function(TopLeftLatLong, BottomRightLatLong, TopRightLatLong, BottomLeftLatLong) 
{
    /// <summary>Initializes a new instance of the VELatLongRectangle object.</summary>
    /// <param name="TopLeftLatLong" type="VELatLong">A VELatLong Class object that specifies the latitude and longitude of the upper-left corner of the map view.</param>
    /// <param name="BottomRightLatLong" type="VELatLong">A VELatLong Class object that specifies the latitude and longitude of the lower-right corner of the map view.</param>
    /// <param name="TopRightLatLong" type="VELatLong">If the map is in 3D mode, a VELatLong Class object that specifies the latitude and longitude of the upper-right corner of the map view.</param>
    /// <param name="BottomLeftLatLong" type="VELatLong">If the map is in 3D mode, a VELatLong Class object that specifies the latitude and longitude of the lower-left corner of the map view.</param>
   
    /// <field name="TopLeftLatLong" type="VELatLong">A VELatLong Class object that specifies the latitude and longitude of the upper-left corner of the map view.</field>
    /// <field name="BottomRightLatLong" type="VELatLong">A VELatLong Class object that specifies the latitude and longitude of the lower-right corner of the map view.</field>
    /// <field name="TopRightLatLong" type="VELatLong">If the map is in 3D mode, a VELatLong Class object that specifies the latitude and longitude of the upper-right corner of the map view.</field>
    /// <field name="BottomLeftLatLong" type="VELatLong">If the map is in 3D mode, a VELatLong Class object that specifies the latitude and longitude of the lower-left corner of the map view.</field>
 }

VELatLongRectangle.prototype =
{   
    TopLeftLatLong: null,
    BottomRightLatLong: null,
    TopRightLatLong: null,
    BottomLeftLatLong: null
}

﻿VELocationPrecision = function()
{
    /// <summary>ENUM: An enumeration of location precision values.</summary>
    /// <field name="Interpolated">The precision is estimated from multiple geocoded sources.</field>        
    /// <field name="Rooftop">The precision is from a single match.</field>  
};

VELocationPrecision.Interpolated = null;
VELocationPrecision.Rooftop = null;

﻿VEMap = function(control_id) {
    /// <summary>Initializes a new instance of the VEMap class.</summary>
    /// <param name="control_id" type="String">The ID of the HTML control that will contain the map.</param>
    /// <field name="onLoadMap">Specifies the function to call when the map is first loaded.</field>        
}

VEMap.GetVersion = function() {
    /// <summary>Returns the current version of the map control.</summary>
    /// <returns type="String"></returns>  
}

VEMap.prototype =
{

    onLoadMap: null,
    AddControl: function(element, zIndex) {
        /// <summary>Adds a custom control to the map.</summary>
        /// <param name="element">An HTML element that contains the control to be added.</param>
        /// <param name="zIndex" type="Number">The z-order for the control. Optional.</param>
    },

    AddCustomLayer: function (object) {
        /// <summary>Adds a custom layer to the map.</summary>
        /// <param name="object">The object to add as a layer to the map DIV container.</param>
    },

    AddShape: function(shape) {
        /// <summary>Adds a VEShape Class object or array of VEShape pushpin objects to the base layer.</summary>
        /// <param name="shape" type="VEShape">The VEShape object or array of VEShape pushpin objects to be added. Required.</param>
    },

    AddShapeLayer: function(Layer) {
        /// <summary>Adds the specified shape layer to the map.  If this layer reference already exists on the map, an exception is thrown, and no new layer is created.</summary>
        /// <param name="Layer" type="VEShapeLayer">A reference to the layer to add.</param>
    },

    AddTileLayer: function(layerSource, visibleOnLoad) {
        /// <summary>Adds a tile layer to the map, and if the visibleOnLoad parameter is true, it also shows it on the map.</summary>
        /// <param name="layerSource" type="VETileSourceSpecification">The VETileSourceSpecification Class object representing the source of the tile layer. Required.</param>
        /// <param name="visibleOnLoad" type="Boolean">The VETileSourceSpecification Class object representing the source of the tile layer. Required.</param>
    },

    AttachEvent: function(event, func) {
        /// <summary>Attaches a Map Control event to a specified function.</summary>
        /// <param name="event" type="String">The name of the Map Control event that generates the call.</param>
        /// <param name="func">The function to run when the event fires. It can be either the name of a function or the function itself.</param>
    },

    Clear: function() {
        /// <summary>Removes all shapes, shape layers, and search results on the map. Also removes the route from the map, if one is displayed.  The Clear method does not remove custom tile layers from the map.</summary>
    },

    ClearInfoBoxStyles: function() {
        /// <summary>Clears out all of the default Virtual Earth info box CSS styles.</summary>
    },

    ClearTraffic: function() {
        /// <summary>Clears the traffic map.</summary>
    },

    DeleteAllShapeLayers: function() {
        /// <summary>Deletes all shape layers, along with any shapes within the layers.</summary>
    },

    DeleteAllShapes: function() {
        /// <summary>Deletes all shapes in all layers, leaving empty layers behind.</summary>
    },

    DeleteControl: function(element) {
        /// <summary>Removes the specified control from the map.</summary>
        /// <param name="element">An HTML element that contains the control to be deleted</param>
    },

    DeleteRoute: function() {
        /// <summary>Clears the current route (VERoute Class object) from the map.</summary>
    },

    DeleteShape: function(shape) {
        /// <summary>Deletes a VEShape Class object from any layer, including the base map layer.</summary>
        /// <param name="shape" type="VEShape">The reference to the VEShape object to be deleted. Required.</param>
    },

    DeleteShapeLayer: function(layer) {
        /// <summary>Deletes the specified shape layer from the map.</summary>
        /// <param name="layer" type="VEShapeLayer">A reference to the layer to delete. Required.</param>
    },

    DeleteTileLayer: function(layerID) {
        /// <summary>Completely removes a tile layer from the map.</summary>
        /// <param name="layerID" type="String">The ID of the layer to be deleted.</param>
    },

    DetachEvent: function(event, func) {
        /// <summary>Detaches the specified map control event so that it no longer calls the specified function.</summary>
        /// <param name="event" type="String">The name of the map control event that generates the call.</param>
        /// <param name="func">The function that was specified to run when the event fired.</param>
    },

    Dispose: function() {
        /// <summary>Deletes the VEMap object and releases any associated resources.</summary>
    },

    EnableShapeDisplayThreshold: function(enable) {
        /// <summary>Specifies whether shapes are drawn below a threshold zoom level.</summary>
        /// <param name="enable" type="Boolean">A Boolean value specifying whether to draw shapes below a threshold zoom level. By default shapes are not drawn below a threshold zoom level.</param>
    },

    EndContinuousPan: function() {
        /// <summary>Stops the continuous map panning initiated by a call to the VEMap.StartContinuousPan Method.</summary>
    },

    Find: function(what, where, findType, shapeLayer, startIndex, numberOfResults, showResults, createResults, useDefaultDisambiguation, setBestMapView, callback) {
        /// <summary>Performs a what (business) search and/or a where (location) search. At least one of these two parameters is required.</summary>
        /// <param name="what" type="String">The business name, category, or other item searched for. This parameter must be supplied for a pushpin to be included in the results.</param>
        /// <param name="where" type="String">The address or place name of the area searched for. This parameter is overloaded; see the Remarks section for more information.</param>
        /// <param name="findType" type="VEFindType">The VEFindType Enumeration that specifies the type of search performed. The only currently supported value is VEFindType.Businesses.</param>
        /// <param name="shapeLayer" type="VEShapeLayer">A reference to the VEShapeLayer Class object that contain the pins that result from this search if it is a "what" component. Optional. If the shape layer is not specified, the pins are added to the base map layer. If the reference is not a valid VEShapeLayer reference, an exception is thrown.</param>
        /// <param name="startIndex" type="Number">The beginning index of the results returned. Optional. Default is 0.</param>
        /// <param name="numberOfResults" type="Number">The number of results to be returned, starting at startIndex. The default is 10, the minimum is 1, and the maximum is 20.</param>
        /// <param name="showResults" type="Boolean">A Boolean object that determines whether the resulting pushpins are visible. Optional. Default is true.</param>        
        /// <param name="createResults" type="Boolean">A Boolean true or false that determines whether pushpins are created when the what parameter is supplied. Optional. If set to the default true, pushpins are created. If set to false: The array of VEFindResult Class objects is still present in the callback, but no pushpin layer is created; The VEShapeLayer reference field within the callback is null; Each VEFindResult object's corresponding Shape property is null.</param>        
        /// <param name="useDefaultDisambiguation" type="Boolean">A Boolean true or false that determines whether the default disambiguation box appears when multiple location matches are possible. Optional. Default is true. If set to true, the default disambiguation box appears. If set to false the default disambiguation box is not displayed.</param>        
        /// <param name="setBestMapView" type="Boolean">A Boolean true or false that determines whether the map view is moved to the first location match. If set to true, the map view is moved to the first location match. Default is true.</param>        
        /// <param name="callback">The name of the function to run when the search results are returned. If useDefaultDisambiguation is set to true, this callback will not be fired until the user has made a disambiguation choice. Optional.</param>        
    },

    FindLocations: function(veLatLong, callback) {
        /// <summary>Performs a search for locations that match a VELatLong input.</summary>
        /// <param name="veLatLong" type="VELatLong">A VELatLong Class object that specifies what map location to match.</param>
        /// <param name="callback">The name of the function that the server calls when it returns search results.</param>
    },

    Geocode: function (query, callback, options) {
        /// <summary>Finds a geographic location based on a specified address or place name string as well as other geocoding options. This method does not return a value. The function defined by the callback parameter receives arguments.</summary>
        /// <param name="query" type="String">The query string to match to a location on the map.</param>
        /// <param name="callback" type="String">The name of the function that the server calls with the geocode results. If this parameter is not null and useDefaultDisambiguation is true, this function is not called until the user has made a disambiguation choice.</param>
        /// <param name="options" type="VEGeocodeOptions">A VEGeocodeOptions Class object specifying additional options.</param>
    },

    GetAltitude: function() {
        /// <summary>In 3D mode, returns a double that represents the altitude (in meters) above the geoid.</summary>
        /// <returns type="Number">THIS VALUE NOT USED IN THE TOOLTIP:(</returns>        
    },

    GetBirdseyeScene: function() {
        /// <summary>If the map view is already set to bird's eye, returns the current VEBirdseyeScene Class object.</summary>
        /// <returns type="VEBirdseyeScene"></returns>        
    },

    GetCenter: function() {
        /// <summary>Returns a VELatLong Class object that represents the location of the center of the current map view.</summary>
        /// <returns type="VELatLong"></returns>        
    },

    GetDirections: function(locations, options) {
        /// <summary>Draws a multi-point route on the map and sends details about the route to a callback function.</summary>
        /// <param name="locations" type="Array">An array of objects specifying the points through which the route must pass. The points can be either VELatLong Class objects or String objects.</param>
        /// <param name="options" type="VERouteOptions">A VERouteOptions Class object specifying the routing options.</param>     
    },

    GetHeading: function() {
        /// <summary>In 3D mode, returns a double that represents the compass heading of the current map view.  Returns a double that represents the compass heading, where 0 is true north and 180 is true south.</summary>
        /// <returns type="Number"></returns>        
    },

    GetImageryMetadata: function(callback, options) {
        /// <summary>Returns information about the requested imagery, including imagery date stamps. This method requires that a valid token has been set using the VEMap.SetClientToken Method.</summary>
        /// <param name="callback">The name of the function to call when results are returned. The function must accept a VEImageryMetadata Class object. Required.<param>
        /// <param name="options" type="VEImageryMetadataOptions">A VEImageryMetadataOptions class specifying the imagery for which information is returned. Optional.<param>
        /// <returns type="VEImageryMetadata"></returns>
    },

    GetLeft: function() {
        /// <summary>Returns the pixel value of the left edge of the map control.</summary>
        /// <returns type="Number"></returns>        
    },

    GetMapMode: function() {
        /// <summary>Returns the current map mode as a VEMapMode Enumeration value.</summary>
        /// <returns type="Number"></returns>        
    },

    GetMapStyle: function() {
        /// <summary>Returns the current map style as a VEMapStyle Enumeration value that represents the current map style.</summary>
        /// <returns type="String"></returns>        
    },

    GetMapView: function() {
        /// <summary>Returns the current map view object as a VELatLongRectangle Class object.</summary>
        /// <returns type="VELatLongRectangle"></returns>        
    },

    GetPitch: function() {
        /// <summary>In 3D mode, returns a double that represents the pitch of the current map view.  A double that represents the pitch, where 0 is level and -90 is straight down.</summary>
        /// <returns type="Number"></returns>        
    },

    GetRoute: function(start, end, units, route_type, callback) {
        /// <summary>This method is deprecated. Use the VEMap.GetDirections Method instead. Draws a route on the map and sends details about the route to a callback function.</summary>
        /// <param name="start">The start location. This can be a string value of an address, a place name, or a VELatLong Class object that specifies the start location</param>
        /// <param name="end">The ending location. This can be a string value of an address, a place name, or a VELatLong object that specifies the end location</param>
        /// <param name="units" type="VEDistanceUnit">A VEDistanceUnit Enumeration value that specifies either miles or kilometers. Optional. Default is VEDistanceUnit.Miles</param>
        /// <param name="route_type" type="VERouteType">A VERouteType Enumeration value specifying either the shortest route or the quickest route. Optional. Default is VERouteType.Shortest</param>
        /// <param name="callback" type="Function">Specifies the function called after the route is drawn on the map. The callback function is passed a VERouteDeprecated Class object containing information about the route.</param>
    },

    GetShapeByID: function(ID) {
        /// <summary>Gets the reference to a VEShape Class object based on its internal identifier.</summary>
        /// <param name="ID" type="String">The identifier of the shape to retrieve. Required.</param>
        /// <returns type="VEShape"></returns>  
    },

    GetShapeLayerByIndex: function(index) {
        /// <summary>Gets the reference to a VEShapeLayer Class object based on its index.</summary>
        /// <param name="index" type="Number">The index of the layer that you wish to retrieve. Required.</param>
        /// <returns type="VEShapeLayer"></returns>  
    },

    GetShapeLayerCount: function() {
        /// <summary>Gets the total number of shape layers on the map.</summary>
        /// <returns type="Number"></returns>        
    },

    GetTileLayerByID: function(id) {
        /// <summary>Gets a tile layer based upon its identifier.</summary>
        /// <param name="id" type="String">The unique identifier of the tile layer.</param>
        /// <returns type="VETileSourceSpecification"></returns>  
    },

    GetTileLayerByIndex: function(index) {
        /// <summary>Gets a tile layer based upon its identifier.</summary>
        /// <param name="index" type="Number">The index into the list of tile layers. The value ranges from 0 to GetTileLayerCount.</param>
        /// <returns type="VETileSourceSpecification"></returns>  
    },

    GetTileLayerCount: function() {
        /// <summary>Gets the number of tile layers.</summary>
        /// <returns type="Number"></returns>        
    },

    GetTop: function() {
        /// <summary>Returns the pixel value of the top edge of the map control.</summary>
        /// <returns type="Number"></returns>        
    },

    GetZoomLevel: function() {
        /// <summary>Returns the current zoom level of the map.</summary>
        /// <returns type="String"></returns>        
    },

    Hide3DNavigationControl: function() {
        /// <summary>In 3D mode, hides the default user interface for controlling the map in 3D mode. By default, this control is shown.</summary>
    },

    HideAllShapeLayers: function() {
        /// <summary>Hides all of the shape layers on the map.</summary>
    },

    HideBaseTileLayer: function (element) {
        /// <summary>Hides the base tile layer of the map.</summary>
    },

    HideControl: function(element) {
        /// <summary>Hides the specified control from view.</summary>
        /// <param name="element" type="String">An HTML element that contains the control to be hidden.</param>
    },

    HideDashboard: function() {
        /// <summary>Hides the default user interface for controlling the map (the compass and the zoom control).</summary>
    },

    HideFindControl: function() {
        /// <summary>Removes the Find control from the map.</summary>
    },

    HideInfoBox: function() {
        /// <summary>Hides a shape's custom or default info box.  There can be only one info box on the screen at a given time. The method will hide the currently visible info box.</summary>
    },

    HideMiniMap: function() {
        /// <summary>Hides the mini map from view.</summary>
    },

    HideScalebar: function() {
        /// <summary>Hides the scale bar from the map.</summary>
    },

    HideTileLayer: function(layerID) {
        /// <summary>Hides the specified control from view.</summary>
        /// <param name="layerID" type="String">The ID of the layer to be hidden.</param>
    },

    HideTrafficLegend: function() {
        /// <summary>Hides the traffic legend.</summary>
    },

    ImportShapeLayerData: function(shapeSource, callback, setBestView) {
        /// <summary>Imports data from a GeoRSS feed, Live Search Maps (http://maps.live.com) collection, or KML URL.</summary>
        /// <param name="shapeSource" type="VEShapeSourceSpecification"> VEShapeSourceSpecification Class object specifying the imported shape data.</param>
        /// <param name="callback">The function that is called after the data has been imported.</param>
        /// <param name="setBestView" type="Boolean">A Boolean value that specifies whether the map view is changed to the best view for the layer.</param>
    },

    Import3DModel: function(modelShapeSource, callback, latlong, orientation, scale) {
        /// <summary>Imports a model data file and displays a 3D model on the map.</summary>
        /// <param name="modelShapeSource" type="VEModelSourceSpecification">A VEModelSourceSpecification Class object specifying the model data to import.</param>
        /// <param name="callback">The name of the function that is called after the data has been imported. See below for the arguments received by the callback.</param>
        /// <param name="latlong" type="VELatLong">A VELatLong Class object that specifies the point at which to place the origin of the model.</param>
        /// <param name="orientation" type="VEModelOrientation">A VEModelOrientation Class object that specifies the orientation of the model on the map.</param>
        /// <param name="scale" type="VEModelScale">A VEModelScale Class object that specifies the scale of the model.</param>
    },

    IncludePointInView: function(latlong) {
        /// <summary>Changes the map view so that it includes both the specified VELatLong Class point and the center point of the current map.</summary>
        /// <param name="latlong" type="VELatLong">A VELatLong Class object that specifies the latitude and longitude of the point to include</param>
    },

    IsBirdseyeAvailable: function() {
        /// <summary>Determines whether the bird's eye map style is available in the current map view.</summary>
        /// <returns type="Boolean"></returns>        
    },

    LatLongToPixel: function(LatLong) {
        /// <summary>Converts a VELatLong Class object (latitude/longitude pair) to the corresponding pixel on the map.</summary>
        /// <param name="LatLong" type="VELatLong">A VELatLong Class object that contains the latitude and longitude of a point.</param>
    },

    LoadMap: function(VELatLong, zoom, style, fixed, mode, showSwitch, tileBuffer, mapOptions) {
        /// <summary>Loads the specified map. All parameters are optional.</summary>
        /// <param name="VELatLong" type="VELatLong">A VELatLong Class object that represents the center of the map. Optional.</param>
        /// <param name="zoom" type="Number">The zoom level to display. Valid values range from 1 through 19. Optional. Default is 4.</param>
        /// <param name="style" type="VEMapStyle">A VEMapStyle Enumeration value specifying the map style. Optional. Default is VEMapStyle.Road.</param>
        /// <param name="fixed" type="Boolean">A Boolean value that specifies whether the map view is displayed as a fixed map that the user cannot change. Optional. Default is false.</param>
        /// <param name="mode" type="VEMapMode">A VEMapMode Enumeration value that specifies whether to load the map in 2D or 3D mode. Optional. Default is VEMapMode.Mode2D.</param>
        /// <param name="showSwitch" type="Boolean">A Boolean value that specifies whether to show the map mode switch on the dashboard control. Optional. Default is true (the switch is displayed).</param>
        /// <param name="tileBuffer" type="Number">How much tile buffer to use when loading map. Default is 0 (do not load an extra boundary of tiles). This parameter is ignored in 3D mode.</param>        
        /// <param name="mapOptions" type="VEMapOptions">A VEMapOptions Class that specifies other map options to set.</param>        
    },

    LoadTraffic: function(showFlow) {
        /// <summary>Loads the traffic map.  The traffic map is only available at zoom levels from 9 through 15, inclusively.</summary>
        /// <param name="showFlow" type="Boolean">Whether to show the traffic flow.</param>
    },

    Pan: function(deltaX, deltaY) {
        /// <summary>When in 2D mode, moves the map the specified amount.  The Pan method only applies to 2D mode maps. If you are working with maps in 3D mode, use the VEMap.StartContinuousPan Method and VEMap.EndContinuousPan Method.</summary>
        /// <param name="deltaX" type="Number">The amount to move the map horizontally, in pixels</param>
        /// <param name="deltaY" type="Number">The amount to move the map vertically, in pixels</param>
    },

    PanToLatLong: function(VELatLong) {
        /// <summary>Pans the map to a specific latitude and longitude.</summary>
        /// <param name="VELatLong" type="VELatLong">A VELatLong Class object that represents the latitude and longitude of the point on which to center the map</param>
    },

    PixelToLatLong: function(pixel) {
        /// <summary>Converts a pixel (a point on the map) to a VELatLong Class object (latitude/longitude pair).</summary>
        /// <param name="pixel" type="VEPixel">VEPixel Class object representing a pixel location on the map.</param>
        /// <returns type="VELatLong"></returns> 
    },

    RemoveCustomLayer: function (object) {
        /// <summary>Removes a custom layer from the map.</summary>
        /// <param name="object">The object to remove from the map DIV container.</param>
    },

    Resize: function(width, height) {
        /// <summary>Resizes the map based on the specified width and height.  If this method is called with no parameters, the map is resized to fit the entire DIV element.</summary>
        /// <param name="width" type="Number">The width, in pixels, of the map. Optional.</param>
        /// <param name="height" type="Number">The height, in pixels, of the map. Optional.</param>
    },

    Search: function (query, callback, options) {
        /// <summary>Resizes the map based on the specified width and height.  If this method is called with no parameters, the map is resized to fit the entire DIV element.</summary>
        /// <param name="query" type="String">The string to use in the search.</param>
        /// <param name="callback" type="String">The name of the function that the server calls with the search results.</param>
        /// <param name="options" type="VESearchOptions">A VESearchOptions Class object specifying additional options.</param>
    },

    SetAltitude: function(altitude) {
        /// <summary>In 3D mode, sets the altitude, in meters, above the WGS 84 ellipsoid in the map view.</summary>
        /// <param name="altitude" type="Number">The altitude, in meters.</param>
    },

    SetBirdseyeOrientation: function(orientation) {
        /// <summary>Changes the orientation of the existing bird's eye image (VEBirdseyeScene Class object) to the specified orientation.</summary>
        /// <param name="orientation" type="VEOrientation "></param>
    },

    SetBirdseyeScene: function(id) {
        /// <summary>Displays the bird's eye image specified by the VEBirdseyeScene Class ID.</summary>
        /// <param name="id" type="Number">The ID of the VEBirdseyeScene Class object that you want to display</param>
    },

    SetBirdseyeScene: function(veLatLong, orientation, zoomLevel, callback) {
        /// <summary>Displays the bird's eye image specified by the center of the map, the orientation, and the zoom level</summary>
        /// <param name="veLatLong" type="VELatLong">A VELatLong Class object specifying the center of the image. Optional. If this parameter is not supplied the center of the map is used.</param>
        /// <param name="orientation" type="VEOrientation">A VEOrientation Enumeration value specifying the direction to which which the image is viewed. Optional. If this value is not supplied, the default value VEOrientation.North is used.</param>
        /// <param name="zoomLevel" type="Number">The level of zoom. Optional. If this parameter is not supplied, the value 1 is used.</param>
        /// <param name="callback">The name of the function called when the SetBirdseyeScene method completes.</param>
    },

    SetCenter: function(VELatLong) {
        /// <summary>Centers the map to a specific latitude and longitude.</summary>
        /// <param name="VELatLong" type="VELatLong">A VELatLong Class object that contains the latitude and longitude of the point on which to center the map.</param>       
    },

    SetCenterAndZoom: function(VELatLong, zoomLevel) {
        /// <summary>Centers the map to a specific latitude and longitude and sets the zoom level.</summary>
        /// <param name="VELatLong" type="VELatLong">A VELatLong Class object that contains the latitude and longitude of the point on which to center the map.</param>       
        /// <param name="zoomLevel" type="Number">The zoom level for the map. Valid values range from 1 through 19.</param>       
    },

    SetClientToken: function(clientToken) {
        /// <summary>Sets a Virtual Earth token for the VEMap object.</summary>
        /// <param name="clientToken">A string representing the Virtual Earth token.</param>
    },

    SetDashboardSize: function(dashboardSize) {
        /// <summary>Sets the map dashboard size and type.  This method must be called before VEMap.LoadMap Method.</summary>
        /// <param name="dashboardSize" type="VEDashboardSize">A VEDashboardSize Enumeration representing the dashboard size. Valid values are Normal, Small, and Tiny.</param>       
    },

    SetDefaultInfoBoxStyles: function() {
        /// <summary>Sets the info box CSS styles back to their original classes.</summary>
    },

    SetFailedShapeRequest: function(policy) {
        /// <summary>Specifies what the map control does when a request to the server to get the accurate position of a shape when the map style is changed to birdseye fails.</summary>
        /// <param name="policy" type="VEFailedShapeRequest">A VEFailedShapeRequest Enumeration value that defines the policy.</param>       
    },

    SetHeading: function(heading) {
        /// <summary>In 3D mode, sets the compass heading of the current map view.</summary>
        /// <param name="heading" type="Number">The compass direction, expressed as a double. A value of 0 is true north, and a value of 180 is true south. Values less than 0 and greater than 360 are valid and are calculated as compass directions.</param>       
    },

    SetMapMode: function(mode) {
        /// <summary>Sets the mode of the map.</summary>
        /// <param name="mode" type="VEMapMode">A VEMapMode Enumeration value that specifies whether to load the map in 2D or 3D mode.</param>       
    },

    SetMapStyle: function(mapStyle) {
        /// <summary>Sets the style of the map.</summary>
        /// <param name="mapStyle" type="VEMapStyle">A VEMapStyle Enumeration value specifying the map style.</param>       
    },

    SetMapView: function(object) {
        /// <summary>Sets the map view to include all of the points, lines, or polygons specified in the provided array, or to the view defined by a VEMapViewSpecification Class object.</summary>
        /// <param name="object">In 2D mode, an array of VELatLong Class points or a VELatLongRectangle Class object. In 3D mode, can also be a VEMapViewSpecification Class object. This object defines the location, altitude, pitch, and heading to use for the map view.</param>       
    },

    SetMouseWheelZoomToCenter: function(zoomToCenter) {
        /// <summary>Specifies whether to zoom to the center of the screen or to the cursor position on the screen.</summary>
        /// <param name="zoomToCenter" type="Boolean">A Boolean value specifying whether to zoom to the center of the screen or to the cursor position. If true, the map control zooms to the center of the screen; if false, the map control zooms to the cursor position on the screen.</param>       
    },

    SetPitch: function(pitch) {
        /// <summary>In 3D mode, sets the pitch of the current map view.</summary>
        /// <param name="pitch" type="Number">The pitch direction, expressed as a double. A value of 0 is level and a value of -90 is straight down. Values less than -90 or greater than 0 are ignored, and the pitch is set to -90.</param>       
    },

    SetPrintOptions: function(printOptions) {
        /// <summary>This method controls how the map is printed.</summary>
        /// <param name="printOptions " type="VEPrintOptions">A VEPrintOptions Class specifying the print options to set.</param>           
    },

    SetScaleBarDistanceUnit: function(distanceUnit) {
        /// <summary>Sets the distance unit (kilometers or miles) for the map scale.</summary>
        /// <param name="distanceUnit" type="VEDistanceUnit">A VEDistanceUnit Enumeration value that specifies either miles or kilometers.</param>       
    },

    SetShapesAccuracy: function(policy) {
        /// <summary>Specifies the accuracy in converting shapes when the map style is changed to birdseye.</summary>
        /// <param name="policy" type="VEShapeAccuracy">The VEShapeAccuracy Enumeration value specifying the accuracy in converting shapes.</param>       
    },

    SetShapesAccuracyRequestLimit: function(max) {
        /// <summary>Specifies the maximum number of shapes that are accurately converted at one time when the map style is changed to birdseye.</summary>
        /// <param name="max" type="Number">The maximum number of shapes that are accurately converted.</param>       
    },

    SetTileBuffer: function(numRings) {
        /// <summary>Sets the number of "rings" of map tiles that should be loaded outside of the visible mapview area. This is also called tile overfetching.</summary>
        /// <param name="numRings" type="Number">An integer value greater than or equal to 0 that indicates the number of rings of additional tiles that should be loaded. The default is 0, and the maximum is 3.</param>       
    },

    SetTrafficLegendText: function(text) {
        /// <summary>Specifies the text shown with the traffic legend, if visible.</summary>
        /// <param name="text" type="String">A string specifying the text shown with the traffic legend.</param>       
    },

    SetZoomLevel: function(zoomLevel) {
        /// <summary>Sets the view of the map to the specified zoom level.</summary>
        /// <param name="zoomLevel" type="Number">The zoom level for the map. Valid values range from 1 through 19.</param>       
    },

    Show3DBirdseye: function(showBirdseye) {
        /// <summary>Controls whether or not to show the Birdseye and BirdseyeHybrid map styles when the map mode is set to VEMapMode.Mode3D.</summary>
        /// <param name="showBirdseye" type="Boolean">A Boolean value that specifies whether or not to show the Birdseye or BirdseyeHybrid map styles when the map mode is set to VEMapMode.Mode3D. The default is false.</param>       
    },

    Show3DNavigationControl: function() {
        /// <summary>In 3D mode, shows the default user interface for controlling the map in 3D mode. By default, this control is shown.</summary>
    },

    ShowAllShapeLayers: function() {
        /// <summary>Shows all shape layers on the map.</summary>
    },

    ShowControl: function(element) {
        /// <summary>Makes the specified control visible. This method only affects control elements that have been hidden from view using the VEMap.HideControl Method.</summary>
        /// <param name="element">An HTML element that contains the control to be shown.</param>       
    },

    ShowDashboard: function() {
        /// <summary>Shows the default user interface for controlling the map (the compass-and-zoom control). By default, this control is shown.</summary>
    },

    ShowDisambiguationDialog: function(showDialog) {
        /// <summary>Specifies whether the default disambiguation dialog is displayed when multiple results are returned from a location query using the VEMap.GetDirections Method.</summary>
        /// <param name="showDialog" type="Boolean">A Boolean value. True enables the disambiguation dialog; false disables it.</param>       
    },

    ShowFindControl: function() {
        /// <summary>Shows the Find control, which enables users to enter search queries.</summary>
    },

    ShowInfoBox: function(shape, anchor, offset) {
        /// <summary>Shows an information box for the shape.</summary>
        /// <param name="shape" type="VEShape">The reference to the shape for which an info box is to be shown. Required.</param>       
        /// <param name="anchor">The anchor point where the info box is docked when displayed. This can either be a VELatLong Class object or a VEPixel Class object. This value must be a valid point on the current map. Optional.</param>       
        /// <param name="offset" type="VEPixel">If the anchor point is a VELatLong object, this parameter, a VEPixel object, specifies the anchor point's offset from that latlong position. Optional.</param>       
    },

    ShowMessage: function(message) {
        /// <summary>Displays the specified message in a dialog box on the map.</summary>
        /// <param name="message" type="String">The message you want to display on the map.</param>       
    },

    ShowMiniMap: function(xoffset, yoffset, size) {
        /// <summary>Displays the mini map at the specified offset from the top left corner of the screen.</summary>
        /// <param name="xoffset" type="Number">The x coordinate offset as a number of pixels from the top left corner of the screen. Optional.</param>       
        /// <param name="yoffset" type="Number">The y coordinate offset as a number of pixels from the top left corner of the screen. Optional.</param>       
        /// <param name="size" type="VEMiniMapSize">A VEMiniMapSize Enumeration value that specifies the mini map size. Optional. Default value is VEMiniMapSize.Small.</param>       
    },

    ShowScalebar: function() {
        /// <summary>Displays the scale bar on the map.</summary>
    },

    ShowTileLayer: function(layerID) {
        /// <summary>Shows a tile layer on the map.</summary>
        /// <param name="layerID" type="String">The ID of the layer to be shown.</param>       
    },

    ShowTrafficLegend: function(x, y) {
        /// <summary>Displays the traffic legend.</summary>
        /// <param name="x" type="Number">The x-coordinate of the top-left corner of the legend. Optional.</param>       
        /// <param name="y" type="Number">The y-coordinate of the top-left corner of the legend. Optional.</param>
    },

    StartContinuousPan: function(x, y) {
        /// <summary>Moves the map in the specified direction until the VEMap.EndContinuousPan Method is called.</summary>
        /// <param name="x" type="Number">The speed, as a percentage of the fastest speed, to move the map in the x direction. Positive numbers move the map to the right, while negative numbers move the map to the left.</param>       
        /// <param name="y" type="Number">The speed, as a percentage of the fastest speed, to move the map in the y direction. Positive numbers move the map down, while negative numbers move the map up</param>
    },

    ZoomIn: function() {
        /// <summary>Increases the map zoom level by 1.  Valid values range from 1 through 19. If you call the ZoomIn method when the current zoom level is already at the maximum, the zoom level does not change.</summary>
    },

    ZoomOut: function() {
        /// <summary>Decreases the map zoom level by 1.  Valid values range from 1 through 19. If you call the ZoomOut method when the current zoom level is already at the minimum, the zoom level does not change.</summary>
    }
}

﻿VEMapMode = function()
{
    /// <summary>ENUM: An enumeration of map modes.</summary>
    /// <field name="Mode2D">Displays the map in the traditional two dimensions.</field>        
    /// <field name="Mode3D">Loads the Virtual Earth 3D control, displays the map in three dimensions, and displays the 3D navigation control.</field>  
};

VEMapMode.Mode2D = null;
VEMapMode.Mode3D = null;

﻿VEMapOptions = function()
{
    /// <summary>Contains the options to set when loading the map.</summary>
    /// <field name="BirdseyeOrientation">A VEOrientation Enumeration value indicating the orientation of the bird's eye map. The default value is VEOrientation.North.</field>        
    /// <field name="EnableBirdseye">A Boolean value specifying whether or not to enable the Birdseye map style in the map control.</field>
    /// <field name="EnableDashboardLabels">A Boolean value that specifies whether or not labels appear on the map when a user clicks the Aerial or Birdseye map style buttons on the map control dashboard.</field>
    /// <field name="LoadBaseTiles">A Boolean value indicating whether or not to load the base map tiles. The default value is true.</field>        
}

VEMapOptions.prototype =
{
    BirdseyeOrientation: null,
    EnableBirdseye : null,
    EnableDashboardLabels : null,
    LoadBaseTiles: null
}

﻿VEMapStyle = function()
{
    /// <summary>ENUM: An enumeration of map styles.</summary>
    /// <field name="Road">The road map style.</field>        
    /// <field name="Shaded">The shaded map style, which is a road map with shaded contours.</field>  
    /// <field name="Aerial">The aerial map style.</field>  
    /// <field name="Hybrid">The hybrid map style, which is an aerial map with a label overlay.</field>        
    /// <field name="Oblique">The oblique map style, which is the same as Birdseye.</field>  
    /// <field name="Birdseye">The bird's eye (oblique-angle) imagery map style.</field> 
    /// <field name="BirdseyeHybrid">The bird's eye hybrid map style, which is a bird's eye map with a label overlay</field> 
};

VEMapStyle.Road = null;
VEMapStyle.Shaded = null;
VEMapStyle.Aerial = null;
VEMapStyle.Hybrid = null;
VEMapStyle.Oblique = null;
VEMapStyle.Birdseye = null; 
VEMapStyle.BirdseyeHybrid = null;

﻿VEMapViewSpecification = function(center, zoom, altitude, pitch, heading)
{
    /// <summary>Initializes a new instance of the VEMapViewSpecification object.</summary>
    /// <param name="center" type="VELatLong">A VELatLong Class object that specifies the center point of the map. Required.</param>
    /// <param name="zoom" type="Number">An integer that represents the zoom level of the map. In Mode2D: required; In Mode3D: ignored when altitude is specified.</param>
    /// <param name="altitude" type="Number">If VEMapMode Enumeration is set to Mode3D, the altitude of the view, in meters above the geoid.</param>
    /// <param name="pitch" type="Number">If VEMapMode Enumeration is set to Mode3D, the pitch of the view, in degrees. A value of –90 is straight down and a value of 0 is level.</param>
    /// <param name="heading" type="Number">If VEMapMode Enumeration is set to Mode3D, the heading of the view, in compass degrees. A value of 0 or 360 is true north.</param>
 }
 
 ﻿VEMatchCode = function()
{
    /// <summary>ENUM: A match code value as received from the geocoder.</summary>
    /// <field name="None">No match was found.</field>        
    /// <field name="Good">The match was good.</field>  
    /// <field name="Ambiguous">The match was ambiguous.</field>  
    /// <field name="UpHierarchy">The match was found by a broader search.</field>  
    /// <field name="Modified">The match was found, but to a modified place.</field>  
};

VEMatchCode.None = null;
VEMatchCode.Good = null;
VEMatchCode.Ambiguous = null;
VEMatchCode.UpHierarchy = null;
VEMatchCode.Modified = null;

﻿VEMatchConfidence = function()
{
    /// <summary>ENUM: A match confidence value as received from the geocoder.</summary>
    /// <field name="High">The confidence of a match is high.</field>        
    /// <field name="Medium">The confidence of a match is medium.</field>  
    /// <field name="Low">The confidence of a match is low.</field>  
};

VEMatchConfidence.High = null;
VEMatchConfidence.Medium = null;
VEMatchConfidence.Low = null;

﻿VEMiniMapSize = function()
{
    /// <summary>ENUM: This enumeration represents the size of the mini map.</summary>
    /// <field name="Small">This represents a small mini map.</field>        
    /// <field name="Large">This represents a large mini map.</field>  
};

VEMiniMapSize.Small = null;
VEMiniMapSize.Large = null;

﻿VEModelFormat = function() {
    /// <summary>An enumeration of 3D model formats.</summary>
    /// <field name="OBJ">The 3D model data is in Wavefront OBJ format.</field>
};
VEModelFormat.OBJ = null;

﻿VEModelOrientation = function(heading, tilt, roll) {
    /// <summary>Represents the orientation of a 3D model on the map.</summary>
    /// <param name="heading">A floating-point value specifying in decimal degrees the counter-clockwise rotation of the 3D model about the z-axis, looking along the positive z-axis away from the origin. Optional. The default value is 0.</param>
    /// <param name="tilt">A floating-point value specifying in decimal degrees the counter-clockwise rotation of the 3D model about the x-axis, looking along the positive x-axis away from the origin. Optional. The default value is 0.</param>
    /// <param name="roll">A floating-point value specifying in decimal degrees the counter-clockwise rotation of the 3D model about the y-axis, looking along the positive y-axis away from the origin. Optional. The default value is 0.</param>
    /// <field name="Heading">A floating-point value specifying in decimal degrees the counter-clockwise rotation of the 3D model about the z-axis, looking along the positive z-axis away from the origin.</field>
    /// <field name="Roll">A floating-point value specifying in decimal degrees the counter-clockwise rotation of the 3D model about the y-axis, looking along the positive y-axis away from the origin.</field>
    /// <field name="Tilt">A floating-point value specifying in decimal degrees the counter-clockwise rotation of the 3D model about the x-axis, looking along the positive x-axis away from the origin.</field>
};
VEModelOrientation.prototype = {
    Heading: null,
    Roll: null,
    Tilt: null
};

﻿VEModelScale = function(x, y, z) {
    /// <summary>Represents the scae of a 3D model with respect to the map.</summary>
    /// <param name="x">A floating-point value specifying the x-axis scale factor of a 3D model. Optional. The default value is 1.</param>
    /// <param name="y">A floating-point value specifying the y-axis scale factor of a 3D model. Optional. The default value is 1.</param>
    /// <param name="z">A floating-point value specifying the z-axis scale factor of a 3D model. Optional. The default value is 1.</param>
    /// <field name="X">A floating-point value specifying the x-axis scale factor of a 3D model.</field>
    /// <field name="Y">A floating-point value specifying the y-axis scale factor of a 3D model.</field>
    /// <field name="Z">A floating-point value specifying the z-axis scale factor of a 3D model.</field>
};
VEModelScale.prototype = {
    X: null,
    Y: null,
    Z: null
};

﻿VEModelScaleUnit = function() {
    /// <summary>An enumeration of scale units.</summary>
    /// <field name="Inches">Scale is defined in Inches.</field>
    /// <field name="Feet">Scale is defined in Feet.</field>
    /// <field name="Yards">Scale is defined in Yards.</field>
    /// <field name="Millimeters">Scale is defined in Millimeters.</field>
    /// <field name="Centimeters">Scale is defined in Centimeters.</field>
    /// <field name="Meters">Scale is defined in Meters.</field>
};
VEModelScaleUnit.Inches = null;
VEModelScaleUnit.Feet = null;
VEModelScaleUnit.Yards = null;
VEModelScaleUnit.Millimeters = null;
VEModelScaleUnit.Centimeters = null;
VEModelScaleUnit.Meters = null;

﻿VEModelSourceSpecification = function(modelFormat, modelSource, layer) {
    /// <summary>Contains the specification for importing a 3D model onto the map.</summary>
    /// <param name="modelFormat">A VEModelFormat Enumeration value specifying the data format of the 3D model being imported. Optional. The default value is VEModelFormat.OBJ.</param>
    /// <param name="modelSource">A string specifying the URL of the 3D model data file. Required.</param>
    /// <param name="layer">A VEShapeLayer Class specifying the shape layer into which the 3D model will be imported. Optional. If this parameter is not specified, the 3D model is added to the base layer.</param>
    /// <field name="Format">A VEModelFormat Enumeration value specifying the data format of the 3D model being imported.</field>
    /// <field name="Layer">A VEShapeLayer Class specifying the shape layer into which the 3D model will be imported.</field>
    /// <field name="ModelSource">A string specifying the URL of the 3D model data file.</field>
};
VEModelSourceSpecification.prototype = {
    Format: null,
    Layer: null,
    ModelSource: null
};

﻿VEModelStatusCode = function() {
    /// <summary>An enumeration of status codes returned in callback of the VEMap.Import3DModel Method.</summary>
    /// <field name="Success">The 3D model was successfully loaded.</field>
    /// <field name="InvalidURL">The 3D model failed to load because the given URL is invalid.</field>
    /// <field name="Failed">The 3D model failed to load. The file format may be incorrect.</field>
};
VEModelStatusCode.Success = null;
VEModelStatusCode.InvalidURL = null;
VEModelStatusCode.Failed = null;

﻿VEOrientation = function()
{
    /// <summary>ENUM: An enumeration of orientations for bird's eye images.</summary>
    /// <field name="North">The image was taken looking toward the North.</field>        
    /// <field name="South">The image was taken looking toward the South.</field>  
    /// <field name="East">The image was taken looking toward the East.</field>        
    /// <field name="West">The image was taken looking toward the West.</field>  
};

VEOrientation.North = null;
VEOrientation.South = null;
VEOrientation.East = null;
VEOrientation.West = null;

﻿VEPixel = function(x, y) 
{
    /// <summary>Initializes a new instance of the VEColor object.</summary>
    /// <param name="x" type="Number">The pixel's x coordinate.</param>
    /// <param name="y" type="Number">The pixel's y coordinate.</param>
    /// <field name="x" type="Number">Gets or sets the pixel's x coordinate.</field>
    /// <field name="y" type="Number">Gets or sets the pixel's y coordinate.</field>
 }

VEPixel.prototype =
{   
    x: null,
    y: null
}

﻿VEPlace = function() 
{
    /// <summary>A found result returned from a location search.</summary>
    /// <field name="LatLong" type="VELatLong">Gets a VELatLong Class object that represents the best location of the found result.</field>
    /// <field name="Locations" type="Array">An array of VEGeocodeLocation Class objects specifying all of the possible match results returned by the geocoder for this place.</field>
    /// <field name="Name" type="String">Gets the String object that represents Virtual Earth's unambiguous name for the location.</field>
    /// <field name="MatchCode" type="VEMatchCode">A VEMatchCode Enumeration value specifying the match code from the geocoder. This property value is only valid for where-only searches.</field>
    /// <field name="MatchConfidence" type="VEMatchConfidence">A VEMatchConfidence Enumeration value specifying the match confidence from the geocoder. This property value is only valid for where-only searches.</field>
    /// <field name="Precision " type="VELocationPrecision">A VELocationPrecision Enumeration value specifying the match precision from the geocoder for the best result, which is found in the VEPlace.LatLong property.</field>
}

VEPlace.prototype =
{   
    LatLong: null,
    Locations: null,
    Name: null,
    MatchCode: null,
    MatchConfidence: null,
    Precision: null
}

﻿VEPrintOptions = function(enablePrinting)
{
    /// <summary>Initializes a new instance of the VEPrintOptions class.</summary>
    /// <param name="enablePrinting" type="Boolean">A Boolean value that represents whether or not to make the map printable. Required.</param>
    /// <field name="EnablePrinting">A Boolean value specifying whether or not to make the map printable.</field>        
}

VEPrintOptions.prototype =
{
    EnablePrinting : null
}

﻿VERoute  = function()
{
    /// <summary>Contains the route and itinerary information for a generated route. A VERoute object is returned to the callback when the VEMap.GetDirections Method is called.</summary>
    /// <field name="Distance">A floating-point value that specifies the total length of the route.</field>        
    /// <field name="RouteLegs">An array of VERouteLeg Class objects that specify the intermediate legs of the route.</field>  
    /// <field name="Time">The total elapsed time, in seconds, to traverse the route.</field>  
    /// <field name="ShapePoints">An array of VELatLong Class objects that identify the shape of the route. Remarks: The shape points are created for the highest zoom level, which means the closest to the ground. Terms of Use: All use of route shape point data is restricted to customers who have received explicit permission and instructions about route shape points from Microsoft. For more information on terms for use of route shape points, contact the Bing Maps Licensing Team.</field>  
};

VERoute.prototype =
{
    Distance : null,
    RouteLegs : null,
    Time : null, 
    ShapePoints : null
}

﻿VERouteDistanceUnit = function()
{
    /// <summary>ENUM: An enumeration specifying the units used for the route.</summary>
    /// <field name="Mile">The route is shown in units of miles.</field> 
    /// <field name="Kilometer">The route is shown in units of kilometers.</field> 
};

VERouteDistanceUnit.Mile = null;
VERouteDistanceUnit.Kilometer = null;

﻿VERouteHint = function() {
    /// <summary>Specifies a route itinerary item hint.</summary>
    /// <field name="Type">A VERouteHintType Enumeration value specifying the type of the hint.</field>
    /// <field name="Text">A string that describes the route itinerary item hint.</field>
};
VERouteHint.prototype = {
    Type: null,
    Text: null
};

﻿VERouteHintType = function() {
    /// <summary>An enumeration specifying route itinerary item hint types.</summary>
    /// <field name="PreviousIntersection">The hint describes the intersection that comes before the itinerary item.</field>
    /// <field name="NextIntersection">The hint describes the intersection that comes after the itinerary item.</field>
    /// <field name="Landmark">The hint describes a landmark along the road or near the itinerary item.</field>
};
VERouteHintType.PreviousIntersection = null;
VERouteHintType.NextIntersection = null;
VERouteHintType.Landmark = null;

﻿VERouteItinerary  = function()
{
    /// <summary>Contains the itinerary information (step-by-step directions) of a VERoute Class object.</summary>
    /// <field name="Items">An array of VERouteItineraryItem Class objects specifying the step-by-step directions for the route.</field> 
};

VERouteItinerary.prototype =
{
    Items : null
}

﻿VERouteItineraryItem = function()
{
    /// <summary>Specifies a step in the step-by-step directions of a route.</summary>
    /// <field name="Distance">A floating-point number specifying the distance of the step</field>        
    /// <field name="LatLong">A VELatLong Class object specifying the position of the step</field>  
    /// <field name="Shape">A VEShape Class object specifying the shape of the step</field>
    /// <field name="Text">A String specifying the description of the step</field>
    /// <field name="Time">The total elapsed time, in seconds, to traverse the route itinerary step.</field>
    /// <field name="Hints">An array of VERouteHint Class items that correspond to the itinerary item.</field>  
};

VERouteItineraryItem.prototype =
{
    Distance : null,
    LatLong : null,
    Shape : null,
    Text : null,
    Time : null,
    Hints: null
}

﻿VERouteLeg  = function()
{
    /// <summary>Specifies the intermediate legs of the route.</summary>
    /// <field name="Distance">A floating-point number specifying the length of the route leg.</field>        
    /// <field name="Itinerary">A VERouteItinerary Class object specifying the itinerary of the route leg.</field>  
    /// <field name="Time">An integer specifying the total elapsed time, in seconds, to traverse the route leg.></field> 
};

VERouteLeg.prototype =
{
    Distance : null,
    Itinerary : null,
    Time : null
}

﻿VERouteLocation = function()
{
    /// <summary>Contains the location information (address and a latitude/longitude pair) of the VERouteDeprecated.StartLocation Property and VERouteDeprecated.EndLocation Property points of a route.</summary>
    /// <field name="Address">Specifies the street address (as a string) of the location.</field>        
    /// <field name="LatLong">Specifies the latitude and longitude (as a VELatLong Class) of the location.</field>
};

VERouteLocation.prototype =
{
    Address : null,
    LatLong : null
}

﻿VERouteMode = function()
{
    /// <summary>ENUM: An enumeration of route modes.</summary>
    /// <field name="Driving">The returned route contains driving directions.</field>        
    /// <field name="Walking">The returned route contains walking directions.</field>  
};

VERouteMode.Driving = null;
VERouteMode.Walking = null;

﻿VERouteOptimize = function()
{
    /// <summary>ENUM: An enumeration specifying how a route is optimized.</summary>
    /// <field name="MinimizeTime">The route is optimized to minimize time.</field>        
    /// <field name="MinimizeDistance">The route is optimized to minimize distance.</field>  
    /// <field name="Default">No route optimization is done. The route is calculated in the order in which the locations are specified.</field>  
};

VERouteOptimize.MinimizeTime = null;
VERouteOptimize.MinimizeDistance = null;
VERouteOptimize.Default = null;

﻿VERouteOptions = function()
{
    /// <summary>Provides optional attributes for a multi-point route.</summary>
    /// <field name="DistanceUnit">A VERouteDistanceUnit Enumeration value specifying the units used by the route.</field>        
    /// <field name="DrawRoute">A Boolean value specifying whether the route is drawn on the map.</field>
    /// <field name="RouteCallback">The name of the function called when the method has generated the route. Optional. The default value is null. The called function receives a VERoute Class object.</field>
    /// <field name="RouteColor">A VEColor Class object specifying the color of the route line.</field>
    /// <field name="RouteMode">A VERouteMode Enumeration value specifying the mode of route to return. The default value is VERouteMode.Driving.</field>
    /// <field name="RouteOptimize">A VERouteOptimize Enumeration value specifying how the route is optimized.</field>
    /// <field name="RouteWeight">The thickness, in pixels, of the route line.</field>
    /// <field name="RouteZIndex">The z-index of the route line. The default value is 4.</field>
    /// <field name="SetBestMapView">A Boolean value specifying whether the map view is set to the best view of the route after it is drawn. The default is true, which means that the map view is set.</field>
    /// <field name="ShowDisambiguation">A Boolean value specifying whether a disambiguation dialog box is shown.</field>
    /// <field name="ShowErrorMessages">Whether to show any error messages.</field>
    /// <field name="UseMWS">A Boolean value specifying whether to use the MapPoint Web Service to generate the route.</field>
    /// <field name="UseTraffic">A Boolean value specifying whether to calculate the route using traffic information.</field>
}

VERouteOptions.prototype =
{
    DistanceUnit : null,
    DrawRoute : null,
    RouteCallback : null,
    RouteColor : null,
    RouteMode : null,
    RouteOptimize : null,
    RouteWeight : null,
    RouteZIndex : null,
    SetBestMapView : null,
    ShowDisambiguation : null,
    ShowErrorMessages : null,
    UseMWS : null,
    UseTraffic : null
}

﻿VERouteSegment = function() 
{
    /// <summary>Contains details about one segment of a VERoute Class object.</summary>
    /// <field name="Instruction" type="String">The driving instructions for this segment of the route.</field>
    /// <field name="Distance" type="Number">The distance of this segment of the route.</field>
    /// <field name="LatLong" type="VELatLong">A VELatLong Class object of the start point of this segment.</field>
}

VERouteSegment.prototype =
{   
    Instruction: null,
    Distance: null,
    LatLong: null
}

﻿VERouteType = function()
{
    /// <summary>ENUM: An enumeration of route types.</summary>
    /// <field name="Shortest">Generates the shortest (by distance) route.</field>        
    /// <field name="Quickest">Generates the shortest (by estimated driving time) route.</field>
};

VERouteType.Shortest = null;
VERouteType.Quickest = null;

﻿VERouteWarning = function()
{
    /// <summary>Specifies a traffic warning.</summary>
    /// <field name="Severity">A VERouteWarningSeverity Enumeration value specifying the severity level of the warning.</field>        
    /// <field name="Text">A String that describes the route warning.</field>
}

VERouteWarning.prototype =
{
    Severity : null,
    Text : null
}

﻿VERouteWarningSeverity = function()
{
    /// <summary>ENUM: An enumeration specifying the severity level of a route warning.</summary>
    /// <field name="None">A warning which has no impact on traffic.</field>        
    /// <field name="LowImpact">A warning which has low impact on traffic.</field>  
    /// <field name="Minor">A minor traffic incident.</field>  
    /// <field name="Moderate">A moderate traffic incident.</field>        
    /// <field name="Serious">A serious traffic incident.</field>  
};

VERouteWarningSeverity.None = null;
VERouteWarningSeverity.LowImpact = null;
VERouteWarningSeverity.Minor = null;
VERouteWarningSeverity.Moderate = null;
VERouteWarningSeverity.Serious = null;

﻿VESearchOptions = function ()
{
    /// <summary>Contains additional search options for the VEMap.Search Method.</summary>
    /// <field name="BoundingRectangle">A VELatLongRectangle Class that defines the area to search. If this property is not specified, the current map view is used. The default value is null.</field>        
    /// <field name="CreateResults">A Boolean value that specifies whether VEShape objects are created. The default value is true.</field>        
    /// <field name="FindType">A VEFindType Enumeration value that specifies the type of search performed. The only supported value is VEFindType.Businesses.</field>        
    /// <field name="NumberOfResults">An integer that defines the number of results to be returned, starting at StartIndex. The default value is 10, the minimum value is 1, and the maximum value is 20.</field>        
    /// <field name="SetBestMapView ">A Boolean value that specifies whether the map control moves the view to the first location match. The default value is true.</field>        
    /// <field name="ShapeLayer">A VEShapeLayer Class object that will contain the VEShape objects created as a result of this search. Optional. If the shape layer is not specified, the pins are added to the base map layer.</field> 
    /// <field name="ShowResults">A Boolean value indicating whether the VEShape objects are visible. Optional. The default value is true.</field> 
    /// <field name="StartIndex">An integer specifying the beginning index of the results returned. Optional. The default value is 0.</field> 
    /// <field name="UseDefaultDisambiguation">A Boolean value indicating whether to show the disambiguation dialog if there is more than one result with high match confidence. The default value is true.</field> 
};

VESearchOptions.prototype =
{
    BoundingRectangle: null,
    CreateResults: null,
    FindType: null,
    NumberOfResults: null,
    SetBestMapView: null,
    ShapeLayer: null,
    ShowResults: null,
    StartIndex: null,
    UseDefaultDisambiguation: null
}

﻿VEShape = function(type, points)
{
    /// <summary>Initializes a new instance of the VEShape class.</summary>
    /// <param name="type" type="VEShapeType">A VEShapeType Enumeration value of type that represents the type of shape. Required.</param>
    /// <param name="points">If the shape is a pushpin, this parameter can either be a single VELatLong Class object or an array of VELatLong objects. If it is an array of VELatLong objects, only the first VELatLong object is used to define the pushpin's location. Any additional data members are ignored. If the shape is a polyline or polygon, it must be an array of VELatLong objects, containing at least two points for a polyline and at least three points for a polygon. Required.</param>
    /// <field name="Draggable" type="Boolean">A Boolean value indicating whether the VEShape icon on the map can be dragged using the mouse.</field>
    /// <field name="ondrag">Occurs when a shape is being dragged across the map.</field>        
    /// <field name="onenddrag">Occurs when a shape is being dragged across the map.</field>        
    /// <field name="ondrag">Occurs when a shape is being dragged across the map.</field>        
}

VEShape.prototype =
{
    // Fields
    Draggable: null,

    // Events
    ondrag: null,
    onenddrag: null,
    onstartdrag: null,

    // Functions
    GetAltitude: function()
    {
        /// <summary>Returns the altitude for the shape.  A floating-point value representing meters above the level represented by the altitude mode.</summary>
        /// <returns type="Number"></returns>
    },
    
    GetAltitudeMode: function()
    {
        /// <summary>Gets the mode in which the shape's altitude is represented.  This method returns VEAltitudeMode.RelativeToGround if the altitude is not set.</summary>
        /// <returns type="VEAltitudeMode"></returns>
    },
    
    GetCustomIcon: function()
    {
        /// <summary>Gets the VEShape objects custom icon.  A String or VECustomIconSpecification object representing the custom icon of the VEShape object.</summary>
        /// <returns type="String_OR_VECustomIconSpecification"></returns>
    },
    
    GetDescription: function()
    {
        /// <summary>Gets the description of the VEShape object. This description will be displayed in the shape's info box.  A String object representing the description field of the VEShape object.</summary>
        /// <returns type="String"></returns>
    },
    
    GetFillColor: function()
    {
        /// <summary>Gets the fill color and transparency for a polygon.  The default is semi-transparent green (alpha=0.3, RGB=0, 128, 0). This method is ignored for pushpins and polylines. </summary>
        /// <returns type="VEColor"></returns>
    },
    
    GetIconAnchor: function()
    {
        /// <summary>Gets a VELatLong Class object representing the shape's custom icon anchor point.</summary>
        /// <returns type="VELatLong"></returns>
    },
    
    GetID: function()
    {
        /// <summary>Gets the internal identifier of the VEShape object.  Use this identifier when working with VEShape object events. A VEShape object only has an identifier when it has been added to a layer. If you try to get the identifier of a VEShape object that is not part of a layer, the VEShape.GetID method returns null.</summary>
        /// <returns type="String"></returns>
    },
    
    GetLineColor: function()
    {
        /// <summary>Gets the line color or transparency for a polyline or polygon.  A VEColor Class object representing the line color or transparency for a polyline or polygon. This method returns null for pushpins.</summary>
        /// <returns type="VEColor"></returns>
    },
    
    GetLineToGround: function()
    {
        /// <summary>Gets whether a line is drawn from the shape to the ground.  If the shape type is Polyline or Polygon, this method returns a Boolean value; if the shape type is Pushpin, this method returns null.</summary>
        /// <returns type="Boolean"></returns>
    },
    
    GetLineWidth: function()
    {
        /// <summary>Gets the line width of a polyline or polygon.  This method returns null for pushpins. If the line width is not set, the default value 2 is returned.</summary>
        /// <returns type="Number"></returns>
    },
    
    GetMaxZoomLevel: function()
    {
        /// <summary>Gets the maximum zoom level at which the shape is visible.  The default maximum zoom level is 21.</summary>
        /// <returns type="Number"></returns>
    },
    
    GetMinZoomLevel: function()
    {
        /// <summary>Gets the minimum zoom level at which the shape is visible.  The default minimum zoom level is 1.</summary>
        /// <returns type="Number"></returns>
    },
    
    GetMoreInfoURL: function()
    {
        /// <summary>Gets the string containing the URL of the "more info" link that is displayed in the shape's info box.</summary>
        /// <returns type="String"></returns>
    },
    
    GetPhotoURL: function()
    {
        /// <summary>Gets the shape's "photo" URL.</summary>
        /// <returns type="String"></returns>
    },
    
    GetPoints: function()
    {
        /// <summary>Returns an array of VELatLong objects representing the points that make up the pushpin, polyline, or polygon.</summary>
        /// <returns type="Array"></returns>
    },
    
    GetShapeLayer: function()
    {
        /// <summary>Gets the reference to the layer containing the specified VEShape object.</summary>
        /// <returns type="VEShapeLayer"></returns>
    },
    
    GetTitle: function()
    {
        /// <summary>Gets the title of the VEShape object.</summary>
        /// <returns type="String"></returns>
    },
    
    GetType: function()
    {
        /// <summary>Gets the type of the VEShape object.</summary>
        /// <returns type="VEShapeType"></returns>
    },
    
    GetZIndex: function()
    {
        /// <summary>Gets the z-index of a pushpin shape or pushpin attached to a polyline or polygon.</summary>
        /// <returns type="Number"></returns>
    },
    
    GetZIndexPolyShape: function()
    {
        /// <summary>Gets the z-index for a polyline or polygon.</summary>
        /// <returns type="Number"></returns>
    },
    
    Hide: function()
    {
        /// <summary>Hides the specified VEShape object from view.</summary>
    },
    
    HideIcon: function()
    {
        /// <summary>Hides the icon associated with a polyline or polygon. This method is ignored for pushpins.</summary>
    },
    
    IsModel: function()
    {
        /// <summary>Returns whether the shape is a model.</summary>
        /// <returns type="Boolean"></returns>
    },
    
    SetAltitude: function(altitude, altitudeMode)
    {
        /// <summary>Specifies the altitude for the shape.</summary>
        /// <param name="altitude" type="Number">A floating-point value or array of floating-point values specifying the altitude, in meters, of the shape.</param>
        /// <param name="altitudeMode" type="VEAltitudeMode">A VEAltitudeMode Enumeration value specifying the mode in which the shape's altitude is represented.</param>
        /// <returns type="Boolean"></returns>
    },
    
    SetAltitudeMode: function(mode)
    {
        /// <summary>Specifies the mode in which a shape's altitude is represented.</summary>
        /// <param name="mode" type="VEAltitudeMode">A VEAltitudeMode Enumeration value specifying the altitude representation.</param>
    },
    
    SetCustomIcon: function(customIcon)
    {
        /// <summary>Sets the VEShape object's custom icon.</summary>
        /// <param name="customIcon" type="String">A String object containing either a URL to an image, custom HTML that defines the custom icon, or a VECustomIconSpecification object.</param>
    },
    
    SetDescription: function(details)
    {
        /// <summary>Sets the description of the VEShape object.</summary>
        /// <param name="details" type="String">A String object containing either plain text or HTML that represents the VEShape object's description field.</param>
    },
    
    SetFillColor: function(color)
    {
        /// <summary>Sets the fill color and transparency of a polygon.</summary>
        /// <param name="color" type="VEColor">A VEColor object representing the fill color and transparency.</param>
    },
    
    SetIconAnchor: function(point)
    {
        /// <summary>Sets the info box anchor of the VEShape object.</summary>
        /// <param name="point" type="VELatLong">A VELatLong Class object representing the shape's info box anchor point.</param>
    },
    
    SetLineColor: function(color)
    {
        /// <summary>Sets the line color or transparency for a polyline or polygon.</summary>
        /// <param name="color" type="VEColor">A VEColor Class object representing the line color and transparency.</param>
    },
    
    SetLineToGround: function(extrude)
    {
        /// <summary>Specifies whether a line is drawn from the shape to the ground.</summary>
        /// <param name="extrude" type="Boolean">A Boolean value specifying whether a line is drawn from the shape to the ground.</param>
    },
    
    SetLineWidth: function(width)
    {
        /// <summary>Sets the line width for a polyline or polygon.</summary>
        /// <param name="width" type="Number">An integer representing the line's width.</param>
    },
    
    SetMaxZoomLevel: function(level)
    {
        /// <summary>Sets the maximum zoom level at which the shape is visible.</summary>
        /// <param name="level" type="Number">An integer specifying the maximum zoom level.</param>
    },
    
    SetMinZoomLevel: function(level)
    {
        /// <summary>Sets the maximum zoom level at which the shape is visible.</summary>
        /// <param name="level" type="Number">An integer specifying the minimum zoom level.</param>
    },
    
    SetMoreInfoURL: function(moreInfoURL)
    {
        /// <summary>Sets the shape's "more info" URL.</summary>
        /// <param name="moreInfoURL" type="String">A String object containing the URL of the "more info" link that is displayed in the shape's info box.</param>
    },
    
    SetPhotoURL: function(photoURL)
    {
        /// <summary>Sets the shape's photo URL.</summary>
        /// <param name="photoURL" type="String">The string containing the URL of the image that is displayed in the shape's info box.</param>
    },
    
    SetPoints: function(points)
    {
        /// <summary>Sets the points of the VEShape Class object.</summary>
        /// <param name="points" type="Array">An array of VELatLong Class objects.</param>
    },
    
    SetTitle: function(title)
    {
        /// <summary>Sets the title of the VEShape object. This title will be displayed in the shape's info box.</summary>
        /// <param name="title" type="String">A String object containing either plain text or HTML that represents the VEShape object's title.</param>
    },
    
    SetZIndex: function(icon, polyshape)
    {
        /// <summary>Sets the maximum zoom level at which the shape is visible.</summary>
        /// <param name="icon" type="Number">Optional. An integer specifying the z-index for the shape's icon (or for the pushpin if the shape is a pushpin). If this value is null or undefined the z-index is not changed.</param>
        /// <param name="polyshape" type="Number">Optional. An integer specifying the z-index for the shape. This parameter is ignored if the shape is a pushpin. If this value is null or undefined the z-index is not changed.</param>
    },
        
    Show: function()
    {
        /// <summary>Makes the specified VEShape object visible.</summary>
    },

    ShowIcon: function () {
        /// <summary>Shows the icon associated with a polyline or polygon. This method is ignored for pushpins.</summary>
    }    
}

﻿VEShapeAccuracy  = function()
{
    /// <summary>ENUM: Specifies the accuracy of shape conversions when the map style is changed to birdseye.</summary>
    /// <field name="None">No shapes are accurately converted</field>        
    /// <field name="Pushpin">Only pushpins are accurately converted</field> 
};

VEShapeAccuracy.None = null;
VEShapeAccuracy.Pushpin = null;

﻿VEShapeLayer = function() {
    /// <summary>Initializes a new instance of the VEShapeLayer class.</summary>
}

VEShapeLayer.prototype =
{
    AddShape: function(shape) {
        /// <summary>Adds a VEShape Class object or array of VEShape objects to the layer.</summary>
        /// <param name="shape" type="VEShape">The VEShape object or array of VEShape objects to be added. Required.</param>
    },

    DeleteAllShapes: function() {
        /// <summary>Deletes all VEShape Class objects (pushpins, polylines, and polygons) from the layer.</summary>
    },

    DeleteShape: function(shape) {
        /// <summary>Adds a VEShape Class object or array of VEShape objects to the layer.</summary>
        /// <param name="shape" type="VEShape">A reference to the VEShape object (pushpin, polyline, and polygon) to delete. Required.</param>
    },

    GetBoundingRectangle: function() {
        /// <summary>Returns a best-fit VELatLongRectangle Class object based on the shapes currently present in the layer.</summary>
        /// <returns type="VELatLongRectangle"></returns>
    },

    GetClusteredShapes: function(type) {
        /// <summary>Returns an array of VEClusterSpecification Class objects representing the calculated pushpin clusters.</summary>
        /// <param name="type" type="VEClusteringType">A VEClusteringType Enumeration specifying the algorithm used to determine which pushpins to cluster.</param>
        /// <returns type="Array"></returns>
    },

    GetDescription: function() {
        /// <summary>Gets the description of the VEShapeLayer object.</summary>
        /// <returns type="String"></returns>
    },

    GetShapeByID: function(id) {
        /// <summary>Retrieves a reference to a VEShape Class object contained in this layer based on the specified ID.</summary>
        /// <param name="id" type="String">The identifier of the VEShape object. Required.</param>
        /// <returns type="VEShape"></returns>
    },

    GetShapeByIndex: function(index) {
        /// <summary>Retrieves a reference to a VEShape Class object contained in this layer based on the specified index.</summary>
        /// <param name="index" type="Number">The index of the shape to retrieve. Required.</param>
        /// <returns type="VEShape"></returns>
    },

    GetShapeCount: function() {
        /// <summary>Returns the total number of shapes in the current layer.</summary>
        /// <returns type="Number"></returns>
    },

    GetTitle: function() {
        /// <summary>Gets the title of the VEShapeLayer Class object.</summary>
        /// <returns type="String"></returns>
    },

    Hide: function() {
        /// <summary>Hides the layer from view on the map.</summary>
    },

    IsVisible: function() {
        /// <summary>Returns true if the layer is visible, otherwise returns false.</summary>
        /// <returns type="Boolean"></returns>
    },

    SetClusteringConfiguration: function(type, options) {
        /// <summary>Sets the method for determining which pushpins are clusted as well as how the cluster is displayed.</summary>
        /// <param name="type" type="VEClusteringType">A VEClusteringType Enumeration specifying which shapes to cluster, OR the name of the function used to determine which pushpins are clustered. The function must accept a VEShapeLayer Class object and return an array of VEClusterSpecification Class objects. Required.</param>
        /// <param name="options" type="VEClusteringOptions">A VEClusteringOptions Class object specifying how the pushpin cluster is displayed. Optional.</param>
    },

    SetDescription: function(details) {
        /// <summary>Sets the description of the VEShapeLayer object.</summary>
        /// <param name="details" type="String ">A String object containing either plain text or HTML that represents the VEShapeLayer object's description field.</param>
    },

    SetTitle: function(title) {
        /// <summary>Sets the title of the VEShapeLayer object.</summary>
        /// <param name="title" type="String">A String object containing either plain text or HTML that represents the VEShapeLayer object's title.</param>
    },

    Show: function() {
        /// <summary>Shows the layer on the map.</summary>
    }
}

﻿VEShapeSourceSpecification = function(dataType, dataSource, layer)
{
    /// <summary>Initializes a new instance of the VEShapeSourceSpecification object.</summary>
    /// <param name="dataType" type="VEDataType">A VEDataType Enumeration that specifies the type of data to import. Required.</param>
    /// <param name="dataSource" type="String">A URL representing the GeoRSS feed or KML data, or a globally-unique identifier (GUID) representing the Live Maps collection. Required.</param>
    /// <param name="layer" type="VEShapeLayer">A VEShapeLayer Class object in which the VEShape objects are contained after importing. If this parameter value is null, the VEShape objects are added to the base layer.</param>
    
    /// <field name="Layer" type="Number">A VEShapeLayer Class object in which the VEShape objects are contained after importing.</field>
    /// <field name="LayerSource" type="Number">A String specifying the layer source.</field>
    /// <field name="MaxImportedShapes" type="Number">Specifies the maximum number of items that can be imported from an XML file. The default value is 200.</field>
    /// <field name="Type" type="Number">A VEDataType Enumeration value defining the type of data to be imported into a shape layer.</field>
}

VEShapeSourceSpecification.prototype =
{   
    Layer: null,
    LayerSource: null,
    MaxImportedShapes: null,
    Type: null
}

﻿VEShapeType = function()
{
    /// <summary>ENUM: An enumeration of the Shape types.</summary>
    /// <field name="Pushpin">This represents a Shape object that is a pushpin.</field>        
    /// <field name="Polyline">This represents a Shape object that is a polyline.</field>  
    /// <field name="Polygon">This represents a Shape object that is a polygon.</field>  
};

VEShapeType.Pushpin = null;
VEShapeType.Polyline = null;
VEShapeType.Polygon = null;

﻿VETileSourceSpecification = function(tileSourceId, tileSource, numServers, bounds, minZoom, maxZoom, getTilePath, opacity, zindex) 
{
    /// <summary>Initializes a new instance of the VETileSourceSpecification object.</summary>
    /// <param name="tileSourceId" type="Number">A unique identifier for the layer. Each layer on a map must have a unique Identifier. Required.</param>
    /// <param name="tileSource" type="String">The location of the tiles. Required.</param>
    /// <param name="numServers" type="Number">The number of servers on which the tiles are hosted. Optional. The default value is 1.</param>
    /// <param name="bounds" type="Array">An array of VELatLongRectangle Class objects that specifies the approximate coverage area of the layer. Optional.</param>
    /// <param name="minZoom" type="Number">The minimum zoom level at which to display the custom tile source. Optional.</param>
    /// <param name="maxZoom" type="Number">The maximum zoom level at which to display the custom tile source. Optional.</param>
    /// <param name="getTilePath" type="String">When viewing a map in 2D mode, the function that determines the correct file names for the tiles. Optional.</param>
    /// <param name="opacity" type="Number">The opacity level of the tiles when displayed on the map. 0.0 to 1.0. Optional.</param>
    /// <param name="zindex" type="Number">The z-index value for the tiles. Optional.</param>
    
    /// <field name="Bounds" type="Array">An array of VELatLongRectangle Class objects that specifies the approximate coverage area of the layer.</field>
    /// <field name="ID" type="Number">The unique identifier for the layer. Each tile layer on a map must have a unique ID.</field>
    /// <field name="MaxZoom" type="Number">The maximum zoom level at which to display the custom tile source.</field>
    /// <field name="MinZoom" type="Number">The minimum zoom level at which to display the custom tile source.</field>
    /// <field name="NumServers" type="Number">The number of servers on which the tiles are hosted.</field>
    /// <field name="Opacity" type="Number">Specifies the opacity level of the tiles when displayed on the map. 0.0 to 1.0.</field>
    /// <field name="TileSource" type="String">The location of the tiles.</field>
    /// <field name="ZIndex" type="Number">Specifies the z-index for the tiles.</field>
}

VETileSourceSpecification.prototype =
{   
    Bounds: null,
    ID: null,
    MaxZoom: null,
    MinZoom: null,
    NumServers: null,
    Opacity: null,
    TileSource: null,
    ZIndex: null
}

