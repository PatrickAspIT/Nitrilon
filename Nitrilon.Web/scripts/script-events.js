"use strict";

// Get the button:
document.getElementById("fetchButton");

// Add eventlistener to the button:
fetchButton.addEventListener("click", fetchEvents);

// Function to fetch the events from the server:
function fetchEvents()
{
    let apiURL = 'https://localhost:7268/api/Event';
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
    .then(data => {
        console.log(data);
    })
    .catch(error => {
      console.error('Error: ', error);
    })
}