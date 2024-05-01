"use strict";

// Get the event container:
let eventList = document.querySelector("#event-Container");

// Where to fetch the events from:
const getEventsURL = 'https://localhost:7268/api/Event/GetActiveorFutureEvents';

fetchEvents();
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
            fetchEventRatings(this.id);
            // OnClick.preventDefault();
            // // Set the eventId in localStorage:
            // localStorage.setItem("eventId", this.id);
            // window.x = this.id;
            
            // console.log("Event ID:", this.id);

            // // Go to the smileys site:
            // window.location.href = "./smileys.html";
          });
        }
      });
    })
    .catch(error => {
      console.error('Error:', error);
    });
}

function fetchEventRatings(eventId) {
  var divExists = !!document.getElementById(eventId + "-Ratings");
  if (divExists)
  {
    var divExists = document.getElementById(eventId + "-Ratings");
    divExists.remove();
  }
  else
  {
    let currentEvent = document.getElementById(eventId);
  const fetchOptions = {
    method: 'GET',
    headers: {
      "Content-Type": "application/json",
    },
  };
  
  fetch(`https://localhost:7268/api/EventRating?eventId=${eventId}`, fetchOptions)
    .then(response => {
      if (!response.ok) 
      {
        throw new Error('Network response was not ok');
      }
      return response.json();
    })
    .then(data => {
      let ratings = data;
      console.log(ratings);
      console.log(ratings.badRatingCount);
      let ratingCard = document.createElement("div");
      let horribleRatingCount = document.createElement("p");
      let badRatingCount = document.createElement("p");
      let neutralRatingCount = document.createElement("p");
      let goodRatingCount = document.createElement("p");
      let fantasticRatingCount = document.createElement("p");
      ratingCard.classList.add("ratingCard");
      horribleRatingCount.textContent = "Horrible rating: " + ratings.horribleRatingCount;
      badRatingCount.textContent = "Bad rating: " + ratings.badRatingCount;
      neutralRatingCount.textContent = "Neutral rating: " + ratings.neutralRatingCount;
      goodRatingCount.textContent = "Good rating: " + ratings.goodRatingCount;
      fantasticRatingCount.textContent = "Fantastic rating: " + ratings.fantasticRatingCount;
      ratingCard.id = eventId + "-Ratings";
      currentEvent.appendChild(ratingCard);
      ratingCard.appendChild(horribleRatingCount);
      ratingCard.appendChild(badRatingCount);
      ratingCard.appendChild(neutralRatingCount);
      ratingCard.appendChild(goodRatingCount);
      ratingCard.appendChild(fantasticRatingCount)
    })
    .catch(error => {
      console.error('Error:', error);
    });
  }  
}