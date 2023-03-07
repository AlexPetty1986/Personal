const options = {
    method: 'GET',
    headers: {
        'X-RapidAPI-Key': 'a88e05f782msh9a3a1257e276400p1bb2e0jsn95babed53bcc',
        'X-RapidAPI-Host': 'pokemon-go1.p.rapidapi.com'
    }
};

export const loadJSONFetch = (url, callback) => {
    fetch(url, options).then(response => response.json())
    .then(json => callback(json))
    .catch(err => console.error(err));
}