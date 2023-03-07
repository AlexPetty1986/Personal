/*
	The purpose of this file is to take in the analyser node and a <canvas> element: 
	  - the module will create a drawing context that points at the <canvas> 
	  - it will store the reference to the analyser node
	  - in draw(), it will loop through the data in the analyser node
	  - and then draw something representative on the canvas
	  - maybe a better name for this file/module would be *visualizer.js* ?
*/

import * as utils from './utils.js';

let currentTrack = document.querySelector("#trackSelect");
let ctx, canvasWidth, canvasHeight, filter, analyserNode, audioData, videoElement, filterType;
let bluePer, greenPer, yellowPer, redPer, magentaPer;
let firstWidth = 0;
let firstHeight = 0;
let secondWidth = 0;
let secondHeight = 0;
let thirdWidth = 0;
let thirdHeight = 0;
let moveLR = 10;
let moveUD = 10;

const setupCanvas = (canvasElement,analyserNodeRef, audioDataRef) => {
	// create drawing context
	ctx = canvasElement.getContext("2d");
	canvasWidth = canvasElement.width;
	canvasHeight = canvasElement.height;
    videoElement = document.querySelector("#videoSource");
	// keep a reference to the analyser node
	analyserNode = analyserNodeRef;
	// this is the array where the analyser data will be stored
	audioData = audioDataRef;
}

const draw = (params={}) => {
    // 1 - populate the audioData array with the frequency data from the analyserNode
	// notice these arrays are passed "by reference"
    //grab reference to the filter values
    filterType = document.querySelector("#filterType").value
    bluePer = document.querySelector("#blueGradient").value;
    greenPer = document.querySelector("#greenGradient").value;
    yellowPer = document.querySelector("#yellowGradient").value;
    redPer = document.querySelector("#redGradient").value;
    magentaPer = document.querySelector("#magentaGradient").value;

    //create the images for the bars
    let barsUD = new Image();
    let barsLR = new Image();

    //if solid bars has been checked
    if(params.solidBars)
    {
        analyserNode.getByteTimeDomainData(audioData);
    }

    //if it has not
    else
    {
        analyserNode.getByteFrequencyData(audioData);
    }

    //current track in use
    switch(currentTrack.value)
    {
        case "media/tetris_typea.mp3":
            //get the images for the bars
            barsUD.src = "images/tetris/t-block.png";
            barsLR.src = "images/tetris/z-block.png";
    
            // 2 - draw video background
            if(videoElement.src == "")
            {
                videoElement.src = "videos/tetris.mp4";
            }
            break;

        case "media/soysauceforgeese.mp3":
            //get the images for the bars
            barsUD.src = "images/fatal-fury/geese.png";
            barsLR.src = "images/fatal-fury/terry.png";

            // 2 - draw video background
            if(videoElement.src == "")
            {
                videoElement.src = "videos/geese.mp4";
            }
            break;

        case "media/icecapzone.mp3":
            //get the images for the bars
            barsUD.src = "images/sonic/sonic.ico";
            barsLR.src = "images/sonic/knuckles.ico";

            // 2 - draw video background
            if(videoElement.src == "")
            {
                videoElement.src = "videos/icecap.mp4";
            }
            break;

        case "media/athletic_theme.mp3":
            //get the images for the bars
            barsUD.src = "images/super-mario/mario.png";
            barsLR.src = "images/super-mario/bowser.png";

            // 2 - draw video background
            if(videoElement.src == "")
            {
                videoElement.src = "videos/level2.mp4";
            }
            break;

        case "media/spark_mandrill.mp3":
            //get the images for the bars
            barsUD.src = "images/mega-man-x/x.png";
            barsLR.src = "images/mega-man-x/zero.png";

            // 2 - draw video background
            if(videoElement.src == "")
            {
                videoElement.src = "videos/mandrill.mp4";
            }
            break;
    }

    ctx.save();
    ctx.drawImage(videoElement, 0, 0, canvasWidth, canvasHeight)
    ctx.restore();
		
	// 3 - draw filter
	if(params.showFilter)
    {
        //filter types available
        switch(filterType)
        {
            case "red":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:1,color:filterType}]);
                break;
            case "orange":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:1,color:filterType}]);
                break;
            case "yellow":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:1,color:filterType}]);
                break;
            case "green":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:1,color:filterType}]);
                break;
            case "blue":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:1,color:filterType}]);
                break;
            case "purple":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:1,color:filterType}]);
                break;
            case "gradient":
                filter = utils.getLinearGradient(ctx,0,0,0,canvasHeight,[{percent:bluePer,color:"blue"},{percent:greenPer,color:"green"},{percent:yellowPer,color:"yellow"},{percent:redPer,color:"red"},{percent:magentaPer,color:"magenta"}]);
                break;
        }
        
        ctx.save();
        ctx.fillStyle = filter;
        ctx.globalAlpha = .5;
        ctx.fillRect(0, 0, canvasWidth, canvasHeight);
        ctx.restore();
    }

	// 4 - draw bars
    if(params.showBars)
    {
        let barSpacing = 6;
        let margin = 8;
        let screenWidthForBars = canvasWidth - (audioData.length * barSpacing) - margin * 2;
        let barWidth = screenWidthForBars / audioData.length;
        let topSpacing = 100;

        ctx.save();
        ctx.fillStyle = `rgba(255, 255, 255, 1)`;
        ctx.strokeStyle = `rgba(0, 0, 0, 0.5)`;
        for(let i = 0; i < audioData.length; i++)
        {
            ctx.drawImage(barsUD, margin + i * (barWidth + barSpacing) - 20, topSpacing + 572 - audioData[i], 40, 40);
            ctx.drawImage(barsUD, margin + i * (barWidth + barSpacing) - 20, -topSpacing + 166 + audioData[audioData.length - i], 40, 40);
            ctx.drawImage(barsLR, topSpacing - 60 + audioData[i], margin + i * (barWidth + barSpacing) - 32, 40, 40);
            ctx.drawImage(barsLR, topSpacing + 1000 - audioData[i], margin + i * (barWidth + barSpacing) - 32, 40, 40);
        }
        ctx.restore();
    }

    //if solid circles has been checked
    if(params.solidCircles)
    {
        analyserNode.getByteTimeDomainData(audioData);
    }

    //if it has not
    else
    {
        analyserNode.getByteFrequencyData(audioData);
    }

    // 5 - draw circles
    if(params.showCircles)
    {
        let maxRadius = canvasHeight / 4;
        ctx.save();
        ctx.globalAlpha = 0.5;

        //if move circles has been checked
        if(params.moveCircles)
        {
            firstWidth += moveLR;
            firstHeight += moveUD;
            secondWidth += moveLR;
            secondHeight += moveUD;
            thirdWidth += moveLR;
            thirdHeight += moveUD;
        }

        //if it has not
        else
        {
            firstWidth = 0;
            firstHeight = 0;
            secondWidth = 0;
            secondHeight = 0;
            thirdWidth = 0;
            thirdHeight = 0;
        }

        for(const element of audioData)
        {
            let percent = element / 255;
            let circleRadius = percent * maxRadius;
            let firstColor = utils.makeColor(255, 0, 0, 0);
            let secondColor = utils.makeColor(0, 255, 0, 0);
            let thirdColor = utils.makeColor(0, 0, 255, 0);

            //current track
            switch(currentTrack.value)
            {
                case "media/tetris_typea.mp3":
                    //purple
                    firstColor = utils.makeColor(128, 0, 128, 0.34 - percent / 3.0);
                    //green
                    secondColor = utils.makeColor(68,255,68, 0.1 - percent / 10.0);
                    //orange
                    thirdColor = utils.makeColor(255, 127, 0, 0.5 - percent / 5.0);
                    break;

                case "media/soysauceforgeese.mp3":
                    //red
                    firstColor = utils.makeColor(255, 0, 0, 0.34 - percent / 3.0);
                    //white
                    secondColor = utils.makeColor(255, 255, 255, 0.1 - percent / 10.0);
                    //yellow
                    thirdColor = utils.makeColor(255, 255, 0, 0.5 - percent / 5.0);
                    break;

                case "media/icecapzone.mp3":
                    //blue
                    firstColor = utils.makeColor(0, 0, 255, 0.34 - percent / 3.0);
                    //yellow
                    secondColor = utils.makeColor(224, 160, 0, 0.1 - percent / 10.0);
                    //red
                    thirdColor = utils.makeColor(255, 0, 0, 0.5 - percent / 5.0);
                    break;

                case "media/athletic_theme.mp3":
                    //green
                    firstColor = utils.makeColor(79, 184, 75, 0.34 - percent / 3.0);
                    //red
                    secondColor = utils.makeColor(213, 0, 0, 0.1 - percent / 10.0);
                    //pink
                    thirdColor = utils.makeColor(255, 92, 183, 0.5 - percent / 5.0);
                    break;

                case "media/spark_mandrill.mp3":
                    //dark blue
                    firstColor = utils.makeColor(0, 64, 249, 0.34 - percent / 3.0);
                    //light blue
                    secondColor = utils.makeColor(107, 197, 240, 0.1 - percent / 10.0);
                    //red
                    thirdColor = utils.makeColor(240, 64, 16, 0.5 - percent / 5.0);
                    break;
            }

            //if move circles has been checked
            if(params.moveCircles)
            {
                //circle one
                ctx.beginPath();
                ctx.fillStyle = firstColor;
                ctx.arc((canvasWidth / 2) + firstWidth, (canvasHeight / 2) + firstHeight, circleRadius, 0, 2 * Math.PI, false);
                ctx.fill();
                ctx.closePath();
                //circle two
                ctx.beginPath();
                ctx.fillStyle = secondColor;
                if(params.circleMayhem)
                {
                    ctx.arc((canvasWidth / 2) - secondWidth, (canvasHeight / 2) - secondHeight, circleRadius * 1.5, 0, 2 * Math.PI, false);
                }
                else
                {
                    ctx.arc((canvasWidth / 2) + firstWidth, (canvasHeight / 2) + firstHeight, circleRadius * 1.5, 0, 2 * Math.PI, false);
                }
                ctx.fill();
                ctx.closePath();
                //circle three
                ctx.beginPath();
                ctx.fillStyle = thirdColor;
                if(params.circleMayhem)
                {
                    ctx.arc((canvasWidth / 2) + thirdWidth, (canvasHeight / 2) - thirdHeight, circleRadius * 0.5, 0, 2 * Math.PI, false);                        
                }
                else
                {
                    ctx.arc((canvasWidth / 2) + firstWidth, (canvasHeight / 2) + firstHeight, circleRadius * 0.5, 0, 2 * Math.PI, false);                        
                }
                ctx.fill();
                ctx.closePath();
            }

            //if it has not
            else
            {
                //circle one
                ctx.beginPath();
                ctx.fillStyle = firstColor;
                ctx.arc((canvasWidth / 2), (canvasHeight / 2), circleRadius, 0, 2 * Math.PI, false);
                ctx.fill();
                ctx.closePath();
                //circle two
                ctx.beginPath();
                ctx.fillStyle = secondColor;
                ctx.arc((canvasWidth / 2), (canvasHeight / 2), circleRadius * 1.5, 0, 2 * Math.PI, false);
                ctx.fill();
                ctx.closePath();
                //circle three
                ctx.beginPath();
                ctx.fillStyle = thirdColor;
                ctx.arc((canvasWidth / 2), (canvasHeight / 2), circleRadius * 0.5, 0, 2 * Math.PI, false);
                ctx.fill();
                ctx.closePath();
            }

            //if circle mayhem has been check
            if(params.circleMayhem)
            {
                if((canvasWidth / 2) + firstWidth + moveLR >= canvasWidth || (canvasWidth / 2) + firstWidth + moveLR <= 0)
                {
                    moveLR = -moveLR;
                }

                else if((canvasHeight / 2) + firstHeight + moveUD > canvasHeight || (canvasHeight / 2) + firstHeight + moveUD <= 0)
                {
                    moveUD = -moveUD;
                }

                if((canvasWidth / 2) + secondWidth + moveLR >= canvasWidth || (canvasWidth / 2) + secondWidth + moveLR <= 0)
                {
                    moveLR = -moveLR;
                }

                else if((canvasHeight / 2) + secondHeight + moveUD > canvasHeight || (canvasHeight / 2) + secondHeight + moveUD <= 0)
                {
                    moveUD = -moveUD;
                }

                if((canvasWidth / 2) + thirdWidth + moveLR >= canvasWidth || (canvasWidth / 2) + thirdWidth + moveLR <= 0)
                {
                    moveLR = -moveLR;
                }

                else if((canvasHeight / 2) + thirdHeight + moveUD > canvasHeight || (canvasHeight / 2) + thirdHeight + moveUD <= 0)
                {
                    moveUD = -moveUD;
                }
            }

            //if it has not
            else
            {
                if((canvasWidth / 2) + firstWidth + moveLR >= canvasWidth || (canvasWidth / 2) + firstWidth + moveLR <= 0)
                {
                    moveLR = -moveLR;
                }

                else if((canvasHeight / 2) + firstHeight + moveUD > canvasHeight || (canvasHeight / 2) + firstHeight + moveUD <= 0)
                {
                    moveUD = -moveUD;
                }
            }
        }
        ctx.restore();
    }

    // 6 - bitmap manipulation
	// TODO: right now. we are looping though every pixel of the canvas (320,000 of them!), 
	// regardless of whether or not we are applying a pixel effect
	// At some point, refactor this code so that we are looping though the image data only if
	// it is necessary
    const lowLoudness = audioData.slice(0,8).reduce((prev, next)=> prev + next)/20;
    const highLoudness = audioData.slice(20,28).reduce((prev, next)=> prev + next)/20;

	// A) grab all of the pixels on the canvas and put them in the `data` array
	// `imageData.data` is a `Uint8ClampedArray()` typed array that has 1.28 million elements!
	// the variable `data` below is a reference to that array 
	let imageData = ctx.getImageData(0, 0, canvasWidth, canvasHeight);
    let data = imageData.data;
    let length = data.length;
    let width = imageData.width;

	// B) Iterate through each pixel, stepping 4 elements at a time (which is the RGBA for 1 pixel)
    for(let i = 0; i < length; i += 4)
    {
        // C) randomly change every 20th pixel to red
        if(params.showNoise && Math.random() < highLoudness/255)
        {
            // data[i] is the red channel
            // data[i+1] is the green channel
            // data[i+2] is the blue channel
            // data[i+3] is the alpha channel
            // zero out the red and green and blue channels
            data[i] = data[i + 1] = data[i + 2] = highLoudness;
            // make the red channel 100% red
            data[i] += highLoudness/16;
            data[i + 1] += lowLoudness/8;
            data[i + 2] -= lowLoudness/4;
        }   // end if

        if(params.showInvert)
        {
            let red = data[i], green = data[i + 1], blue = data[i + 2];
            data[i] = 255 - red;
            data[i + 1] = 255 - green;
            data[i + 2] = 255 - blue;
        }
    }	// end for

    if(params.showEmboss)
    {
        for(let i = 0; i < length; i++)
        {
            if(i % 4 == 3)
            {
                continue;
            }

            data[i] = 127 + 2 * data[i] - data[i + 4] - data[i + width * 4];
        }
    }

	// D) copy image data back to canvas
    ctx.save();
    ctx.putImageData(imageData, 0, 0);
    ctx.restore();
}

export {setupCanvas,draw};