import * as main from "./main.js";
import {loadJSONFetch} from "./ajax.js";

window.onload = ()=>{
	console.log("window.onload called");
	// 1 - do preload here - load fonts, images, additional sounds, etc...
	let presets = [];
	
	const dataLoaded = json => {
		console.log(json);
		presets = json.preset || ["No 'presets' found"];
		loadPreset();
	};
	  
	//load in the presets from the json
	const loadPreset = () => {
		const currentPresets = presets[0];
		// here we created the <option> elements using 1-liners and string concatenation
		const distortType = document.querySelector("#distortionType");
		const filterUse = document.querySelector("#filterCB");
		const filterType = document.querySelector("#filterType");
		const barUse = document.querySelector("#barsCB");
		const circleUse = document.querySelector("#circlesCB");
		distortType.innerHTML = currentPresets.distortTypes.map(type => `<option value="${type}">Type ${type}</option>`).join("");
		filterUse.checked = currentPresets.filterUsed;
		filterType.innerHTML = currentPresets.filterTypes.map(type => `<option value="${type}">${type}</option>`).join("");
		barUse.checked = currentPresets.barUsed;
		circleUse.checked = currentPresets.circUsed;
		
		barUse.dispatchEvent(new Event("input"));
		circleUse.dispatchEvent(new Event("input"));
		filterUse.dispatchEvent(new Event("input"));
	};

	loadJSONFetch("app-data/presets.json", dataLoaded);

	// 2 - start up app
	main.init();
}