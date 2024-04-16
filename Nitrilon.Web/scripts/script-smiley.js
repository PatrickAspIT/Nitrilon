"use strict";

let eventId = 1;

// Get the smileys:
let greenPressed = document.querySelector("#green");
let limePressed = document.querySelector("#lime");
let yellowPressed = document.querySelector("#yellow");
let orangePressed = document.querySelector("#orange");
let redPressed = document.querySelector("#red");

// Add eventlisteners to the smileys:
greenPressed.addEventListener("click", sendToServer(1));
limePressed.addEventListener("click", sendToServer(2));
yellowPressed.addEventListener("click", sendToServer(3));
orangePressed.addEventListener("click", sendToServer(4));
redPressed.addEventListener("click", sendToServer(5));

// Function to send the rating to the server:
function sendToServer(rating)
{
    let apiURL = 'https://localhost:7268/api/EventRating?eventId={eventId}&ratingId={rating}';
    let requestOptions = {
      method: 'GET',
      headers: {
        'Content-Type': 'application/json'
      }
    };

    fetch(apiURL, requestOptions)
      .then(response => {
        if (!response.ok) {
          throw new Error('Network response was not ok');
        }
        return response.json();
      }
    )
    .catch(error => {
      console.error('Error: ', error);
    })
}