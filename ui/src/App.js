import React, { useState } from 'react';
import axios from 'axios';
import './App.css';

const App = () => {
    const [searchText, setSearchText] = useState('');
    const [recentSearches, setRecentSearches] = useState([]);
    const [movies, setMovies] = useState([]);
    const [selectedMovie, setSelectedMovie] = useState(null);

    const handleSearch = async () => {
        if (searchText.trim() === '') return;

        setRecentSearches(prev => {
            const data = [searchText, ...prev.filter(term => term !== searchText)];
            return data.slice(0, 5);
        });

        const response = await axios.get(`http://localhost:5000/movies/${searchText}/search`);
        setMovies(response.data || []);
        setSearchText('');
    };

    const handleClick = async (id) => {
        const response = await axios.get(`http://localhost:5000/movies/${id}`);
        setSelectedMovie(response.data);
    };

    const close = () => {
        setSelectedMovie(null);
    };

    return (
        <div className="body">
           <h1 className='search'>Search Movie</h1><br/>
             <div className="search">
          
            <input
                type="text"
                value={searchText}
                onChange={(e) => setSearchText(e.target.value)}
                placeholder="Enter movie title..."
            />
            <button onClick={handleSearch}>Search</button>
          </div>
            

            <h2>Recent Searches:</h2>
            <ul>
                {recentSearches.map((text, index) => (
                    <li key={index} onClick={() => setSearchText(text)}>
                        {text}
                    </li>
                ))}
            </ul>

            <h2>Results:</h2>
            <div className="search_results">
                {movies.map(movie => (
                    <div key={movie.imdbID} className="movie-card" onClick={() => handleClick(movie.imdbID)}>
                        <img src={movie.poster} alt={movie.title} />
                        <h3>{movie.Title}</h3>
                    </div>
                ))}
            </div>

            {selectedMovie && (
                <div className="modal">
                    <div className="card modal-content">
                        <span className="close" onClick={close}>&times;</span>
                        <h2>{selectedMovie.title}</h2>
                        <img width={200} height={200} src={selectedMovie.poster} alt={selectedMovie.title} />
                        <p>{selectedMovie.plot}</p>
                        <p><strong>IMDB Score:</strong> {selectedMovie.imdbRating}</p>
                    </div>
                </div>
            )}
        </div>
    );
};

export default App;