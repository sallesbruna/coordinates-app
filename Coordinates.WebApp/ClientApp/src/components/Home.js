import React from 'react';
import { connect } from 'react-redux';
import "./Home.css";

function sendNavigateCommand(event) {
    event.preventDefault();

    const formElement = document.getElementById('coordinates-form');
    const formData = new FormData(formElement);
    
    const lastCoordinateJson = localStorage.getItem("lastCoordinate");
    
    let lastCoordinate = { x: 1, y: 1};
    if(lastCoordinateJson) {
        lastCoordinate = JSON.parse(lastCoordinateJson);
    }

    formData.append("lastCoordinateX", lastCoordinate.x);
    formData.append("lastCoordinateY", lastCoordinate.y);

    fetch("/api/coordinates",
        {
            method: "POST",
            body: formData,
        })
        .then((res) => {
            res.json().then((data) => {
                const str = JSON.stringify(data);
                
                document.getElementById("result").innerText = `(${data.x}, ${data.y})`;
                
                localStorage.setItem("lastCoordinate", str);
                
            });
        });

    
    // CLEAR FORM AND AUTOFOCUS INPUT
    formElement.reset();
    document.getElementById('coordinates-form-direction').focus();  

    return false;
}

const Home = props => (
  <div className="input-container">
    <div className="input-box">
        <form onSubmit={sendNavigateCommand} id="coordinates-form">
            <span>[</span>
            <input type="text" placeholder="N" required autoFocus="autoFocus" name="direction" id="coordinates-form-direction" />
            <span>,</span>
            <input type="number" step="1" min="0" max="99" required placeholder="10" name="intensity" />
            <span>]</span>
            <input type="submit" hidden/>
        </form>
        <br/>
        <div id="result"></div>
    </div>
  </div>
);

export default connect()(Home);
