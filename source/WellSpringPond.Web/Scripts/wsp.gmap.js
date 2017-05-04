document.addEventListener('DOMContentLoaded', function () {
  if (document.querySelectorAll('#mainMap').length > 0) {
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
document.getElementById('SearchLocationBtn').addEventListener('click', showSearchLocation);


var mainMap;
var initPos = {lat: 40.915215,  lng: 29.236134};
var searchPos = {lat: 44.610743,  lng: 20.537016};
var userPos = {lat: 55.628846, lng: 44.423012};

var userMarker;
var searchMarker;

var markers = [];



function createBaseMarkers(){

userMarker = new google.maps.Marker({
        position: userPos,
        map: null,
        animation: google.maps.Animation.DROP,
         icon:'http://maps.google.com/mapfiles/ms/icons/green-dot.png'
      });

markers.push(userMarker); 

searchMarker = new google.maps.Marker({
        position: searchPos,
        map: null,
        animation: google.maps.Animation.DROP    
      });
markers.push(searchMarker); 
}


function initMap() {
  mainMap = new google.maps.Map(document.getElementById('mainMap'), {
    center: initPos,
    zoom: 8
  });

  createBaseMarkers();
}

function showUserLocation() {  
  //userPos=initPos;
  mainMap.setCenter(userPos);
  userMarker.setPosition(userPos);
  userMarker.setMap(mainMap);  

  //set MyLocation button to active, and go button to inactive
  document.getElementById('myLocationBtn').className = 'btn btn-info';
  document.getElementById('SearchLocationBtn').className = 'btn btn-default';

}


function showSearchLocation() {   
  mainMap.setCenter(searchPos);
  searchMarker.setPosition(searchPos);
  searchMarker.setMap(mainMap); 

  //set MyLocation button to active, and go button to inactive
  document.getElementById('myLocationBtn').className = 'btn btn-default';
  document.getElementById('SearchLocationBtn').className = 'btn btn-info';

}