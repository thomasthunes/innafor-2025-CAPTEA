import React, { useState, useEffect } from 'react';
import './App.css';
import { BrowserRouter as Router, Routes, Route, Link, useLocation } from 'react-router-dom';
import Bruker from './components/Bruker';
import Aktorer from './components/Aktorer';
import AktorDetail from './components/AktorDetail';
import Muligheter from './components/Muligheter';
import Meldinger from './components/Meldinger';

const TabNavigation: React.FC = () => {
  const location = useLocation();
  
  const isActive = (path: string) => location.pathname === path;

  return (
    <nav style={{ display: 'flex', gap: '20px', padding: '20px', borderBottom: '1px solid #ccc' }}>
      <Link 
        to="/bruker" 
        style={{ 
          textDecoration: 'none', 
          padding: '10px 20px',
          backgroundColor: isActive('/bruker') ? '#007bff' : '#f8f9fa',
          color: isActive('/bruker') ? 'white' : '#007bff',
          borderRadius: '4px',
          border: '1px solid #007bff'
        }}
      >
        Bruker
      </Link>
      <Link 
        to="/aktorer" 
        style={{ 
          textDecoration: 'none', 
          padding: '10px 20px',
          backgroundColor: isActive('/aktorer') ? '#007bff' : '#f8f9fa',
          color: isActive('/aktorer') ? 'white' : '#007bff',
          borderRadius: '4px',
          border: '1px solid #007bff'
        }}
      >
        Aktører
      </Link>
      <Link 
        to="/muligheter" 
        style={{ 
          textDecoration: 'none', 
          padding: '10px 20px',
          backgroundColor: isActive('/muligheter') ? '#007bff' : '#f8f9fa',
          color: isActive('/muligheter') ? 'white' : '#007bff',
          borderRadius: '4px',
          border: '1px solid #007bff'
        }}
      >
        Muligheter
      </Link>
      <Link 
        to="/meldinger" 
        style={{ 
          textDecoration: 'none', 
          padding: '10px 20px',
          backgroundColor: isActive('/meldinger') ? '#007bff' : '#f8f9fa',
          color: isActive('/meldinger') ? 'white' : '#007bff',
          borderRadius: '4px',
          border: '1px solid #007bff'
        }}
      >
        Meldinger
      </Link>
    </nav>
  );
};

interface User {
  id: string;
  firstName: string;
  lastName: string;
}

function App() {
  const [uuid, setUuid] = useState('');
  const [users, setUsers] = useState<User[]>([]);
  const [loading, setLoading] = useState(true);

  const fetchUsers = async () => {
    try {
      setLoading(true);
      const response = await fetch('http://localhost:5164/api/ClusterUser', {
        headers: {
          'accept': 'application/json'
        }
      });
      if (response.ok) {
        const data = await response.json();
        setUsers(data);
      }
    } catch (error) {
      console.error('Error fetching users:', error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  (window as any).getUuid = () => uuid;
  (window as any).setUuid = (value: string) => setUuid(value);

  return (
    <Router>
      <div className="App">
        <header className="App-header">
          <h1>Frontend Dashboard</h1>
          <div style={{ marginTop: '10px' }}>
            Bruker-id: <select
              value={uuid}
              onChange={(e) => setUuid(e.target.value)}
              disabled={loading}
              style={{
                padding: '8px 12px',
                border: '1px solid #ccc',
                borderRadius: '4px',
                fontSize: '14px',
                width: '320px'
              }}
            >
              <option value="">
                {loading ? 'Loading users...' : 'Select a user'}
              </option>
              {users.map((user) => (
                <option key={user.id} value={user.id}>
                  {user.firstName} {user.lastName}
                </option>
              ))}
            </select>
          </div>
        </header>
        <TabNavigation />
        <main style={{ padding: '20px' }}>
          <Routes>
            <Route path="/bruker" element={<Bruker uuid={uuid} />} />
            <Route path="/aktorer" element={<Aktorer />} />
            <Route path="/aktorer/:id" element={<AktorDetail />} />
            <Route path="/muligheter" element={<Muligheter />} />
            <Route path="/meldinger" element={<Meldinger currentUser={uuid} />} />
            <Route path="/" element={<Bruker uuid={uuid} />} />
          </Routes>
        </main>
      </div>
    </Router>
  );
}

export default App;
