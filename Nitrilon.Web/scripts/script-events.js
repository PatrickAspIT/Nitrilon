"use strict";

// Get the button:
let fetchButton = document.getElementById("fetchButton");

// Get the event container:
let eventList = document.querySelector("#event-Container");

// Add eventlistener to the button:
fetchButton.addEventListener("click", fetchEvents);

// Where to fetch the events from:
const getEventsURL = 'https://localhost:7268/api/Event/GetActiveorFutureEvents';

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
      // console.log(data);
      // let events = JSON.parse(data);
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

          eventCard.addEventListener("click", function(OnClick)
          {
            OnClick.preventDefault();
            localStorage.setItem("eventId", this.id);
            // sendNumberToReciever(this.id);
            // let eventId = event.id;
            // console.log(eventId);
            // console.log(OnClick);
            window.x = this.id;
            console.log("Event ID:", this.id);
            window.location.href = "./smileys.html";
          });
        }
      });
    })
    .catch(error => {
      console.error('Error:', error);
    });
    // window.location.href = "./smileys.html";
    fetchButton.removeEventListener("click", fetchEvents);
    fetchButton.classList.remove("pointer");
}

function sendNumberToReciever(numberToSend)
{
  const event = new CustomEvent('numberSent', {detail: numberToSend});
  document.dispatchEvent(event);
}