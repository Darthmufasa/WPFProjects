using WebFrameworks.Classes;

namespace RESTfulGoogleMapsDirectionsAPI
{
    public class DirectionsRequest : RestSerializable
    {
        string _apiKey;
        string _origin;
        string _destination;
        TravelModes? _mode;
        string[] _waypoints;
        bool? _alternatives;
        RouteRestrictionOptions[] _avoid;
        UnitSystem? _units;
        string _region;
        int? _arrival_time;
        int? _departure_time;
        TrafficModel? _traffic_model;
        TransitMode? _transit_mode;
        TransitRoutingPreference? _transit_routing_preference;

        public string apiKey { get => _apiKey; set => SetProperty(ref _apiKey,value); }
        public string origin { get => _origin; set => SetProperty(ref _origin, value); }
        public string destination { get => _destination; set => SetProperty(ref _destination, value); }
        public TravelModes? mode { get => _mode; set => SetProperty(ref _mode, value); }
        public string[] waypoints { get => _waypoints; set => SetProperty(ref _waypoints, value); }
        public bool? alternatives { get => _alternatives; set => SetProperty(ref _alternatives, value); }
        public RouteRestrictionOptions[] avoid { get => _avoid; set => SetProperty(ref _avoid, value); }
        public UnitSystem? units { get => _units; set => SetProperty(ref _units, value); }
        public string region { get => _region; set => SetProperty(ref _region, value); }
        public int? arrival_time { get => _arrival_time; set => SetProperty(ref _arrival_time, value); }
        public int? departure_time { get => _departure_time; set => SetProperty(ref _departure_time, value); }
        public TrafficModel? traffic_model { get => _traffic_model; set => SetProperty(ref _traffic_model, value); }
        public TransitMode? transit_mode { get => _transit_mode; set => SetProperty(ref _transit_mode, value); }
        public TransitRoutingPreference? transit_routing_preference { get => _transit_routing_preference; set => SetProperty(ref _transit_routing_preference, value); }
    }
}
