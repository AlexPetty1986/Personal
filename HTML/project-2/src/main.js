/*
	main.js is primarily responsible for hooking up the UI to the rest of the application 
	and setting up the main event loop
*/

// We will write the functions in this file in the traditional ES5 way
// In this instance, we feel the code is more readable if written this way
// If you want to re-write these as ES6 arrow functions, to be consistent with the other files, go ahead!

import * as utils from './utils.js';
import * as audio from './audio.js';
import * as canvas from './canvas.js';

const drawParams = {
  showFilter : true,
  showBars : true,
  showCircles : true,
  showNoise : false,
  showInvert : false,
  showEmboss: false,
  solidBars: false,
  solidCircles: false,
  moveCircles: false,
  circleMayhem: false
};

let circleOp = document.querySelector("#circleOptions");
let barOp = document.querySelector("#barOptions");
let vidElement = document.querySelector("#videoSource");
let songStop = 0;

// 1 - here we are faking an enumeration
const DEFAULTS = Object.freeze({
	sound1  :  "media/tetris_typea.mp3"
});

const init = () => {
  audio.setupWebaudio(DEFAULTS.sound1);
	console.log("init called");
	console.log(`Testing utils.getRandomColor() import: ${utils.getRandomColor()}`);
	let canvasElement = document.querySelector("canvas"); // hookup <canvas> element
	setupUI();
  canvas.setupCanvas(canvasElement, audio.analyserNode, audio.audioData);
  loop();
}

const setupUI = () => {
  playButton.onclick = e => {
    console.log(`audioCtx.state before = ${audio.audioCtx.state}`);
    if(audio.audioCtx.state == "suspended")
    {
        audio.audioCtx.resume();
    }

    console.log(`audioCtx.state after = ${audio.audioCtx.state}`);
    if(e.target.dataset.playing == "no")
    {
        audio.playCurrentSound();
        e.target.dataset.playing = "yes";
    }

    else
    {
        audio.pauseCurrentSound();
        e.target.dataset.playing = "no";
    }
  };

  playVideo.onclick = e => {
    if(e.target.dataset.isplaying == "yes")
    {
      vidElement.pause();
      e.target.dataset.isplaying = "no";
    }
    else
    {
      vidElement.play();
      vidElement.muted = true;
      e.target.dataset.isplaying = "yes";
    }

    console.log(e.target.dataset.isplaying);
  }

  //C - hookup volume slider & label
  let volumeSlider = document.querySelector("#volumeSlider");
  let volumeLabel = document.querySelector("#volumeLabel");

  volumeSlider.oninput = e => {
    audio.setVolume(e.target.value);

    volumeLabel.innerHTML = Math.round((e.target.value/2 * 100));
  };

  volumeSlider.dispatchEvent(new Event("input"));

  let highTreble = document.querySelector("#highShelf");
  let lowBass = document.querySelector("#lowShelf");
  let distortMusic = document.querySelector("#distort");
  let distortType = document.querySelector("#distortionType");

  highTreble.oninput = e => {
    audio.toggleHighShelf(e.target.checked);
  }

  lowBass.oninput = e => {
    audio.toggleLowShelf(e.target.checked);
  }

  distortMusic.oninput = e => {
    audio.toggleDistortion(e.target.checked, distortType.value);
  }

  distortType.onchange = e => {
    distortMusic.dispatchEvent(new Event("input"));
  }

  //D - hookup track <select>
  let trackSelect = document.querySelector("#trackSelect");
  trackSelect.onchange = e => {
    audio.loadSoundFile(e.target.value);
    vidElement.removeAttribute('src');
    vidElement.pause();
    if(playButton.dataset.playing == "yes")
    {
      playButton.dispatchEvent(new MouseEvent("click"));
    }
    if(playVideo.dataset.isplaying == "yes")
    {
      vidElement.pause();
      playVideo.dataset.isplaying = "no";
    }
  };

  document.querySelector("#filterCB").oninput = function(e){
    drawParams.showFilter = e.target.checked;
  };

  document.querySelector("#blueGradient").oninput = e => {
    document.querySelector("#blueLabel").innerHTML = e.target.value;
  }

  document.querySelector("#greenGradient").oninput = e => {
    document.querySelector("#greenLabel").innerHTML = e.target.value;
  }

  document.querySelector("#yellowGradient").oninput = e => {
    document.querySelector("#yellowLabel").innerHTML = e.target.value;
  }

  document.querySelector("#redGradient").oninput = e => {
    document.querySelector("#redLabel").innerHTML = e.target.value;
  }

  document.querySelector("#magentaGradient").oninput = e => {
    document.querySelector("#magentaLabel").innerHTML = e.target.value;
  }

  document.querySelector("#blueGradient").dispatchEvent(new Event("input"));
  document.querySelector("#greenGradient").dispatchEvent(new Event("input"));
  document.querySelector("#yellowGradient").dispatchEvent(new Event("input"));
  document.querySelector("#redGradient").dispatchEvent(new Event("input"));
  document.querySelector("#magentaGradient").dispatchEvent(new Event("input"));

  document.querySelector("#barsCB").oninput = function(e){
    drawParams.showBars = e.target.checked;
    if(e.target.checked)
    {
      barOp.style = "display: inline";
    }

    else
    {
      barOp.style = "display: none";
    }
  };

  document.querySelector("#solidBars").oninput = function(e){
    drawParams.solidBars = e.target.checked;
  };

  document.querySelector("#circlesCB").oninput = function(e){
    drawParams.showCircles = e.target.checked;
    if(e.target.checked)
    {
      circleOp.style = "display: inline";
    }

    else
    {
      circleOp.style = "display: none";
    }
  };

  document.querySelector("#solidCircles").oninput = function(e){
    drawParams.solidCircles = e.target.checked;
  };

  document.querySelector("#moveCircles").oninput = function(e){
    drawParams.moveCircles = e.target.checked;
    if(e.target.checked)
    {
      document.querySelector("#circleMadness").style = "display: inline";
    }

    else
    {
      document.querySelector("#circleMadness").style = "display: none";
    }
  };

  document.querySelector("#circleMayhem").oninput = function(e){
    drawParams.circleMayhem = e.target.checked;
  };

  document.querySelector("#noiseCB").oninput = function(e){
    drawParams.showNoise = e.target.checked;
  };

  document.querySelector("#invertCB").oninput = function(e){
    drawParams.showInvert = e.target.checked;
  };

  document.querySelector("#embossCB").oninput = function(e){
    drawParams.showEmboss = e.target.checked;
  };
	
} // end setupUI

//have the play button reset once the song ends
const endTheSong = () => {
  for(let i = 0; i < audio.audioData.length - 1; i++)
  {
    if(audio.audioData[i] == 0 && playButton.dataset.playing == "yes")
    {
      songStop++;
    }

    else
    {
      songStop = 0;
    }
  }

  if(songStop >= audio.audioData.length && playButton.dataset.playing == "yes")
  {
    playButton.dispatchEvent(new MouseEvent("click"));
    songStop = 0;
  }
}

const loop = () => {
  requestAnimationFrame(loop);
  canvas.draw(drawParams);
  endTheSong();
}

export {init};