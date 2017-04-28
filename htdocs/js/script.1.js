document.addEventListener('DOMContentLoaded', function () {
  if (document.querySelectorAll('#map').length > 0) {
    if (document.querySelector('html').lang)
      lang = document.querySelector('html').lang;
    else
      lang = 'en';

    var js_file = document.createElement('script');
    js_file.type = 'text/javascript';
    js_file.src = 'https://maps.googleapis.com/maps/api/js?callback=initMap&key=AIzaSyB_0cXJH5dzvQjyTnlzFoySGX93Okxew8k&v=3&language=' + lang;
    document.getElementsByTagName('head')[0].appendChild(js_file);
  }
});

document.getElementById('myLocationBtn').addEventListener('click', showUserLocation);

var numberOfMarkersToShow = 3;

var Map;
var markers = [];

//40.915215, 29.236134 istanbul
var initPos = {
  lat: 40.915215,
  lng: 29.236134
};
var userPos;
var markerData = "../data/markers.json";

//make the map
function initMap() {
  Map = new google.maps.Map(document.getElementById('Map'), {
    center: initPos,
    zoom: 8
  });

  // fetch(markerData)
  // .then(function(response){return response.json()})
  // .then(plotMarkers); 
};


//var infoWindow = initInfoWindow();
//userPos = findDeviceLocation();

//sortf nearby markers by distance


// getting the marker locations form the map instance, and visializing them

var bounds;

function plotMarkers(m) {
  //markers = [];
  bounds = new maps.LatLngBounds();

  m.forEach(function (marker) {
    var position = new google.maps.LatLng(marker.lat, marker.lng);

    markers.push(
      new google.maps.Marker({
        position: position,
        map: map,
        animation: google.maps.Animation.DROP
      })
    );

    bounds.extend(position);
  });

  map.fitBounds(bounds);
};

function initInfoWindow() {
  infoWindow = new google.maps.InfoWindow;
};

function showUserLocation() {
  findDeviceLocation();
  map.setCenter(userPos);

  var userMarker = new google.maps.Marker({
        position: userPos,
        title:"I am here!",    
        animation: google.maps.Animation.DROP,   
        icon:'http://maps.google.com/mapfiles/ms/icons/green-dot.png'      
      });

  markers.push(userMarker);
  userMarker.map = map;
};

function findDeviceLocation() {
  if (navigator.geolocation) {
    navigator.geolocation.getCurrentPosition(function (position) {
      userPos = {
        lat: position.coords.latitude,
        lng: position.coords.longitude
      };      
    }, function () {
      handleLocationError(true, infoWindow, map.getCenter());
    });
  } else {
    // Browser doesn't support Geolocation
    handleLocationError(false, infoWindow, map.getCenter());
  }
};


function handleLocationError(browserHasGeolocation, infoWindow, pos) {
  infoWindow.setPosition(pos);
  infoWindow.setContent(browserHasGeolocation ?
    'Error: The Geolocation service failed.' :
    'Error: Your browser doesn\'t support geolocation.');
  infoWindow.open(map);
};


//onclick="document.getElementById('myLocationBtn').className = 'btn btn-info'"