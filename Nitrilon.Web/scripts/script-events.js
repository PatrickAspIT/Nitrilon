"use strict";

// Get the button to fetch the events from the server:
let fetchButton = document.getElementById("fetchButton");

// Get the button to go to the rating site:
let ratingSiteButton = document.getElementById("ratingSite");

// Get the button to go to the member site:
let memberSiteButton = document.getElementById("memberSite");

// Get the event container:
let eventList = document.querySelector("#event-Container");

// Add eventlistener to the buttons:
fetchButton.addEventListener("click", fetchEvents);
ratingSiteButton.addEventListener("click", goToRatingSite);
memberSiteButton.addEventListener("click", goToMemberSite);

// Where to fetch the events from:
const getEventsURL = 'https://localhost:7268/api/Event/GetActiveorFutureEvents';

// Function to go to new site when ratingSiteButton is clicked:
function goToRatingSite()
{
  window.location.href = "./ratings.html";
}

// Function to go to new site when ratingSiteButton is clicked:
function goToMemberSite()
{
  window.location.href = "./members.html";
}

// Function to fetch the events from the server:
function fetchEvents()
{
  const fetchOptions = {
    method: 'GET',
    headers: {
      "Content-Type": "application/json",
    },
  };
  
  fetch(getEventsURL, fetchOptions)
    .then(response => {
      if (!response.ok) 
      {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      let events = data;
      console.log(events);

      // Loop through the events:
      events.forEach(event => {
        if (event != " ")
        {
          let eventCard = document.createElement("div");
          let text = document.createElement("p");
          eventCard.classList.add("eventCard");
          const formattedDate = new Date(event.date).toLocaleDateString();
          text.textContent = event.name + " - (" + formattedDate + ")";
          eventList.appendChild(eventCard);
          eventCard.appendChild(text);
          eventCard.classList.add("pointer");
          eventCard.setAttribute('id', event.id);

          // Add eventlistener to the eventCard:
          eventCard.addEventListener("click", function(OnClick)
          {
            OnClick.preventDefault();
            // Set the eventId in localStorage:
            localStorage.setItem("eventId", this.id);
            window.x = this.id;
            
            console.log("Event ID:", this.id);

            // Go to the smileys site:
            window.location.href = "./smileys.html";
          });
        }
      });
    })
    .catch(error => {
      console.error('Error:', error);
    });
    fetchButton.removeEventListener("click", fetchEvents);
    fetchButton.classList.remove("pointer");
}