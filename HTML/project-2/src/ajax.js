export const loadJSONFetch = (url,callback) => {
	fetch(url).then(response => response.json())
    .then(json => callback(json))
    .catch(err => console.error(err));
};