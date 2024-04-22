"use strict";

let eventId = localStorage.getItem("eventId");

// document.addEventListener('numberSent', function(event)
// {
//   eventId = event.detail;
//   console.log("Recieved number: ", recievedNumber);
// });

console.log("Event ID: ", eventId);
// console.log(window.x);

// import eventId from './script-events.js';

// Get the smileys:
let greenPressed = document.querySelector("#green");
let limePressed = document.querySelector("#lime");
let yellowPressed = document.querySelector("#yellow");
let orangePressed = document.querySelector("#orange");
let redPressed = document.querySelector("#red");

// Add eventlisteners to the smileys:
greenPressed.addEventListener("click", function() {
  sendToServer(1);
});
limePressed.addEventListener("click", function() {
  sendToServer(2);
});
yellowPressed.addEventListener("click", function() {
  sendToServer(3);
});
orangePressed.addEventListener("click", function() {
  sendToServer(4);
});
redPressed.addEventListener("click", function() {
  sendToServer(5);
});

const eventRatingURL = 'https://localhost:7268/api/EventRating?eventId=${eventId}&ratingId=${rating}';

// Function to send the rating to the server:
function sendToServer(rating)
{
  const fetchOptions = {
    method: 'POST',
    headers: {
      "Content-Type": "application/json",
    },
  };
  fetch(eventRatingURL, fetchOptions)
    .then(response => {
      if (!response.ok) 
      {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      console.log(data);
    })
    .catch(error => {
      console.error('There has been a problem with your fetch operation:', error);
    });
}