"use strict";

// First Section:-----------------------------------------------

// Get 1st button to fetch the members from the server:
let fetchMembersButton = document.getElementById("seeMembers");

// Where to fetch the members from:
const getMembersURL = 'https://localhost:7268/api/Member';

// Add eventlistener to the button:
fetchMembersButton.addEventListener("click", fetchMembers);

//Section for this function:
let firstSection = document.getElementById("firstSection");

// Function to fetch the members from the server:
function fetchMembers()
{
  // Check if the member-Container already exists:
  if (document.getElementById("member-Container"))
  {
    // If it does, remove it:
    var divExists = document.getElementById("member-Container");
    divExists.remove();
  } else
  {
    // Make a container for this function:
    let memberList = document.createElement("div");
    memberList.id = "member-Container";

    // Make div containers for the different MembershipIds:
    let activeMembers = document.createElement("div");
    let passiveMembers = document.createElement("div");
    let inactiveMembers = document.createElement("div");

    // Append the main div container + div containers for the memberList:
    firstSection.appendChild(memberList);
    memberList.appendChild(activeMembers);
    memberList.appendChild(passiveMembers);
    memberList.appendChild(inactiveMembers);

    // Add text to the div containers:
    let activeMembersText = document.createElement("h2");
    let passiveMembersText = document.createElement("h2");
    let inactiveMembersText = document.createElement("h2");
    activeMembersText.textContent = "Active Members:";
    passiveMembersText.textContent = "Passive Members:";
    inactiveMembersText.textContent = "Inactive Members:";
    activeMembers.appendChild(activeMembersText);
    passiveMembers.appendChild(passiveMembersText);
    inactiveMembers.appendChild(inactiveMembersText);

    const fetchOptions = {
      method: 'GET',
      headers: {
        "Content-Type": "application/json",
      },
    };

    fetch(getMembersURL, fetchOptions)
      .then(response => {
        if (!response.ok) 
        {
          throw new Error('Network response was not ok');
        }
        return response.json();
      })
      .then(data => {
        let members = data;
        // console.log(members);

        // Loop through the members:
        members.forEach(member => {
          if (member != " ")
          {
            let memberCard = document.createElement("div");
            let textId = document.createElement("p");
            let textName = document.createElement("p");
            let textPhoneNumber = document.createElement("p");
            let textEmail = document.createElement("p");
            let textDate = document.createElement("p");
            let textMembershipId = document.createElement("p");
            memberCard.classList.add("memberCard");
            textId.textContent = "MemberId: " + member.memberId;
            textName.textContent = "Name: " + member.name;
            textPhoneNumber.textContent = "PhoneNumber: " + member.phoneNumber;
            textEmail.textContent = "Email: " + member.email;
            textDate.textContent = "Date: " + member.date;
            textMembershipId.textContent = "MembershipId: " + member.membershipId;
            if (member.membershipId == 1)
            {
              activeMembers.appendChild(memberCard);
            } else if (member.membershipId == 2)
            {
              passiveMembers.appendChild(memberCard);
            } else if (member.membershipId == 3)
            {
              inactiveMembers.appendChild(memberCard);
            }
            memberCard.appendChild(textId);
            memberCard.appendChild(textName);
            memberCard.appendChild(textPhoneNumber);
            memberCard.appendChild(textEmail);
            memberCard.appendChild(textDate);
            memberCard.appendChild(textMembershipId);
            memberCard.classList.add("pointer");
          }
        });
      });
  }  
}

// Second Section:-----------------------------------------------

// Add eventlistener to the addMember form submit button:
document.getElementById("addMemberForm").addEventListener("submit", addMember);

// Where to add the member to the server:
const addMemberURL = 'https://localhost:7268/api/Member';

// Function to add a member to the server:
function addMember(event)
{
  // Prevent the default action of the form:
  event.preventDefault();

  const fetchOptions = {
    method: 'POST',
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      "Name": this.name.value,
      "PhoneNumber": this.phoneNumber.value,
      "Email": this.email.value,
      "Date": this.date.value,
      "MembershipId": this.membershipId.value,
    }),
  };

  fetch(addMemberURL, fetchOptions)
    .then(response => {
      if (!response.ok) 
      {
        throw new Error('Network response was not ok');
      }
      return response.json(); // Gets a syntax error here, but it works.
    })
    .then(data => {
      //console.log(data);
      //console.log("Worked");
      
      let changeText = document.getquerySelector("#secondSection h2");
      changeText.textContent = "Medlem tilføjet!";

      // Reset the form:
      document.getElementById("addMemberForm").reset();

      // timeout to change text back to normal:
      setTimeout(() => {
        changeText.textContent = "Tilføj venligst et nyt medlem:";
      }, 3000);
    })
    .catch(error => {
      console.error('Error:', error);
    });
}

// Third Section:-----------------------------------------------

// add eventlistener to the removeMember form submit button:
document.getElementById("removeMemberForm").addEventListener("submit", removeMember);

// Function to remove a member from the server:
function removeMember(event)
{
  // Where to remove the member from the server:
  const removeMemberURL = `https://localhost:7268/api/Member/${this.memberId.value}?memberId=${this.memberId.value}`;

  // Prevent the default action of the form:
  event.preventDefault();

  const fetchOptions = {
    method: 'DELETE',
    headers: {
      "Content-Type": "application/json",
    },
  };

  fetch(removeMemberURL, fetchOptions)
    .then(response => {
      if (!response.ok) 
      {
        throw new Error('Network response was not ok');
      }
      return response.json(); // Gets a syntax error here, but it works.
    })
    .then(data => {
      //console.log(data);
      //console.log("Worked");

      let changeText = document.getquerySelector("#thirdSection h2");
      changeText.textContent = "Medlem fjernet!";

      // Reset the form:
      document.getElementById("removeMemberForm").reset();

      // timeout to change text back to normal:
      setTimeout(() => {
        changeText.textContent = "Fjern venligst et medlem:";
      }, 3000);
    })
    .catch(error => {
      console.error('Error:', error);
    });
}

// Fourth Section:-----------------------------------------------

// add eventlistener to the updateMembership form submit button:
document.getElementById("changeMembershipForm").addEventListener("submit", updateMembership);

// Function to update a members membership on the server:
function updateMembership(event)
{
  // Where to update the members membership on the server:
  const updateMembershipURL = `https://localhost:7268/api/Member/${this.memberId.value}`;

  console.log(updateMembershipURL);

  // Prevent the default action of the form:
  event.preventDefault();

  const fetchOptions = {
    method: 'PUT',
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({
      "MembershipId": this.membershipId.value,
    }),
  };

  fetch(updateMembershipURL, fetchOptions)
    .then(response => {
      if (!response.ok) 
      {
        throw new Error('Network response was not ok');
      }
      return response.json(); // Gets a syntax error here, but it works.
    })
    .then(data => {
      //console.log(data);
      //console.log("Worked");

      let changeText = document.getquerySelector("#fourthSection h2");
      changeText.textContent = "Medlemskab opdateret!";

      // Reset the form:
      document.getElementById("updateMembershipForm").reset();

      // timeout to change text back to normal:
      setTimeout(() => {
        changeText.textContent = "Opdater venligst et medlemskab:";
      }, 3000);
    })
    .catch(error => {
      console.error('Error:', error);
    });
}
