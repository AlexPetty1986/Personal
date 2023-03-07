// 1 - our WebAudio context, **we will export and make this public at the bottom of the file**
let audioCtx;

// **These are "private" properties - these will NOT be visible outside of this module (i.e. file)**
// 2 - WebAudio nodes that are part of our WebAudio audio routing graph
let element, sourceNode, analyserNode, gainNode, highShelfBiquadFilter, lowShelfBiquadFilter, distortionFilter;
let distortionAmount = 20;

// 3 - here we are faking an enumeration
const DEFAULTS = Object.freeze({
    gain: .5,
    numSamples: 256
});

// 4 - create a new array of 8-bit integers (0-255)
// this is a typed array to hold the audio frequency data
let audioData = new Uint8Array(DEFAULTS.numSamples/2);

// **Next are "public" methods - we are going to export all of these at the bottom of this file**
const setupWebaudio = (filepath) => {
    
    // 1 - The || is because WebAudio has not been standardized across browsers yet
    const AudioContext = window.AudioContext || window.webkitAudioContext;
    audioCtx = new AudioContext();

    // 2 - this creates an <audio> element
    element = new Audio();

    // 3 - have it point at a sound file
    loadSoundFile(filepath);

    // 4 - create an a source node that points at the <audio> element
    sourceNode = audioCtx.createMediaElementSource(element);

    // 5 - create an analyser node
    // note the UK spelling of "Analyser"
    analyserNode = audioCtx.createAnalyser();

    //highshelf
    highShelfBiquadFilter = audioCtx.createBiquadFilter();
    highShelfBiquadFilter.type = "highshelf";

    //lowshelf
    lowShelfBiquadFilter = audioCtx.createBiquadFilter();
    lowShelfBiquadFilter.type = "lowshelf";

    //distortion
    distortionFilter = audioCtx.createWaveShaper();

    // fft stands for Fast Fourier Transform
    analyserNode.fftSize = DEFAULTS.numSamples;

    // 7 - create a gain (volume) node
    gainNode = audioCtx.createGain();
    gainNode.gain.value = DEFAULTS.gain;

    // 8 - connect the nodes - we now have an audio graph
    sourceNode.connect(highShelfBiquadFilter);
    highShelfBiquadFilter.connect(lowShelfBiquadFilter);
    lowShelfBiquadFilter.connect(distortionFilter);
    distortionFilter.connect(analyserNode);
    analyserNode.connect(gainNode);
    gainNode.connect(audioCtx.destination);
}

const loadSoundFile = (filepath) => {
    element.src = filepath;
}

const playCurrentSound = () => {
    element.play();
}

const pauseCurrentSound = () => {
    element.pause();
}

const setVolume = (value) => {
    // make sure that it's a Number rather than a String
    value = Number(value);
    gainNode.gain.value = value;
}

const toggleHighShelf = (highshelf) => {
    if(highshelf)
    {
        highShelfBiquadFilter.frequency.setValueAtTime(1000, audioCtx.currentTime);
        highShelfBiquadFilter.gain.setValueAtTime(25, audioCtx.currentTime);
    }

    else
    {
        highShelfBiquadFilter.gain.setValueAtTime(0, audioCtx.currentTime);
    }
}

const toggleLowShelf = (lowshelf) => {
    if(lowshelf)
    {
        lowShelfBiquadFilter.frequency.setValueAtTime(1000, audioCtx.currentTime);
        lowShelfBiquadFilter.gain.setValueAtTime(15, audioCtx.currentTime);
    }

    else
    {
        lowShelfBiquadFilter.gain.setValueAtTime(0, audioCtx.currentTime);
    }
}

const toggleDistortion = (distort, distortOption) => {
    if(distort)
    {
        distortionFilter.curve = null;
        distortionFilter.curve = makeDistortionCurve(distortOption, distortionAmount)
    }

    else
    {
        distortionFilter.curve = null;
    }
}

const makeDistortionCurve = (option, amount = 10) => {
    let curve = new Float32Array(DEFAULTS.numSamples);

    for(let i = 0; i < DEFAULTS.numSamples; i++)
    {
        let x = i * 2 / DEFAULTS.numSamples - 1;
        switch(option)
        {
            case "1":
                curve[i] = (Math.PI + amount) * x / (Math.PI + amount * Math.abs(x));
                break;
            case "2":
                curve[i] = x * Math.cos(x) * amount / 5;
                break;
            case "3":
                curve[i] = Math.PI * x * i;
                break;
            case "4":
                curve[i] = x / amount * -i;
                break;
            case "5":
                curve[i] = (Math.PI + amount) * x;
                break;
            case "6":
                curve[i] = (Math.PI + 100 * x / 2) / (Math.PI + amount * Math.abs(x));
                break;
            case "7":
                curve[i] = -(Math.PI + 100 * x / 2) / (Math.PI - Math.random());
                break;
            case "8":
                curve[i] = Math.random() * 2 - 1;
                break;
            case "9":
                curve[i] = x * 5 + Math.random() * 2 - 1;
                break;
            case "10":
                curve[i] = x * Math.sin(x) * amount / 5;
                break;
        }
    }

    return curve;
}

export {audioCtx, audioData, setupWebaudio, playCurrentSound, pauseCurrentSound, loadSoundFile, setVolume, toggleHighShelf, toggleLowShelf, toggleDistortion, analyserNode};