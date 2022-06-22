let _webAPIBaseURL = 'https://localhost:44323';
let songURL = `${_webAPIBaseURL}/api/Song`;
let authURL = `${_webAPIBaseURL}/api/Auth`;

export const environment = {
  production: true,

  webAPIBaseURL: _webAPIBaseURL,

  // Song URLs
  songsURL: `${songURL}`,
  rateSongByIdURL: `${songURL}/rate`,
  addSongURL: `${songURL}/add`,
  updateSongByIdURL: `${songURL}/update`,
  
  // AUTH URLs
  loginURL: `${authURL}/login`,


  noPhotoPath: 'assets/no-photo.png',
  loaderGifPath:'assets/loading.gif',
  noResultsPhoto:'assets/no-results.png'
};
