// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(showPosition);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function showPosition(position) {
    const lat = position.coords.latitude;
    const lon = position.coords.longitude;

    const url = "https://localhost:7214/api/Weathers?lat=" + lat + "&lon=" + lon;

    fetch(url)
        .then(response => response.json())
        .then(body => document.querySelector('#weather').innerHTML = Math.trunc(body.temperature) + " °" );
}

getLocation();