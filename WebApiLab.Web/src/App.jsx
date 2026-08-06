import './App.css'
import React, {useState, useEffect } from 'react'

function App() {
  const [data, setData] = useState(null);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(true);
  
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await fetch('http://localhost:5239/People');

        if (!response.ok)
        {
           throw new Error(`HTTP error! status: ${response.status}`);
        }

        const result = await response.json();
        setData(result);
      } catch (error) {
        setError(error.message);
      } finally {
        setLoading(false);
      }  
    };

    fetchData();
  }, []);

  if (loading) {
    return <div>Loading...</div>
  } else if (error) {
    return <div>Error: {error}</div>
  } else if (data) {
    return (
      <div>
        <h1>Fetched Data:</h1>
        <pre>{JSON.stringify(data, null, 2)}</pre>
      </div>
    )
  }

  return (
    <span>Hello,World!</span>
  );
}

export default App