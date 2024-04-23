"use strict";

// Gets eventId from localStorage which is set in script-events.js:
let eventId = localStorage.getItem("eventId");
console.log("Event ID: ", eventId);

// Create variable to track if the function can be called:
let canCallFunction = true;

// Get h2 on webpage:
let h2 = document.querySelector("main h2");
console.log(h2.textContent);

// Get the smileys:
let redPressed = document.querySelector("#red");
let orangePressed = document.querySelector("#orange");
let yellowPressed = document.querySelector("#yellow");
let limePressed = document.querySelector("#lime");
let greenPressed = document.querySelector("#green");

// Add eventlisteners to the smileys:
redPressed.addEventListener("click", function() {
  timeOut(1);
});
orangePressed.addEventListener("click", function() {
  timeOut(2);
});
yellowPressed.addEventListener("click", function() {
  timeOut(3);
});
limePressed.addEventListener("click", function() {
  timeOut(4);
});
greenPressed.addEventListener("click", function() {
  timeOut(5);
});

// Function to set timeout of the function sendToServer:
function timeOut(r){
  if (canCallFunction)
  {
    sendToServer(r);

    // Set a timeout to enable calling the function again after 5 seconds
    canCallFunction = false;

    // Changes text on webpage to "Tak for din bedømmelse, vent venligst 5 sekunder før du kan bedømme igen."
    h2.textContent = "Tak for din bedømmelse, vent venligst 5 sekunder før du kan bedømme igen.";
    setTimeout(function() {
      canCallFunction = true;

      // Changes text on webpage back to "Bedøm eventet"
      h2.textContent = "Bedøm eventet";
    }, 5000);
  } else {
    console.log("Function is currently disabled. Please wait.");
  }
}

// Function to send the rating to the server:
function sendToServer(rating) {
  const eventRatingURL = `https://localhost:7268/api/EventRating?eventId=${eventId}&ratingId=${rating}`;

  const fetchOptions = {
    method: 'POST',
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      "eventId": eventId,
      "ratingId": rating
    })
  };

  fetch(eventRatingURL, fetchOptions)
    .then(response => {
      if (!response.ok) {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      console.log("Worked");
      console.log(data); // Handle successful response data
    })
    .catch(error => {
      console.error('There has been a problem with your fetch operation:', error);
    });
}