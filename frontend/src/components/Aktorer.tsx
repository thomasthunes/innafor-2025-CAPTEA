import React, { useEffect, useState } from 'react';
import { useNavigate } from 'react-router-dom';

interface Aktor {
  id: string;
  name: string;
  emailAddress: string;
  telephone: string;
  websiteUrl: string;
  organizationNumber: string;
  industryCode: string;
  clusterPurpose: string;
  clusterVision: string;
  clusterDescription: string;
  services: string;
  industry: string;
  dateOfFoundation: string;
  mainContact: string;
}

const Aktorer: React.FC = () => {
  const [aktorer, setAktorer] = useState<Aktor[]>([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchAktorer = async () => {
      try {
        setLoading(true);
        // Replace with your actual API endpoint
        const response = await fetch('http://localhost:5164/api/Cluster', {
          headers: {
            'accept': 'application/json'
          }
        });
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        
        const data = await response.json();
        setAktorer(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchAktorer();
  }, []);

  const handleAktorClick = (aktorId: string) => {
    navigate(`/aktorer/${aktorId}`);
  };

  if (loading) {
    return (
      <div>
        <h2>Akt�rer</h2>
        <p>Loading actors information...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div>
        <h2>Akt�rer</h2>
        <p>Error loading actors: {error}</p>
      </div>
    );
  }

  if (aktorer.length === 0) {
    return (
      <div>
        <h2>Akt�rer</h2>
        <p>No actors found.</p>
      </div>
    );
  }

  return (
    <div>
      <h2>Akt�rer ({aktorer.length})</h2>
      
      {aktorer.map((aktor) => (
        <section 
          key={aktor.id} 
          onClick={() => handleAktorClick(aktor.id)}
          style={{ 
            marginBottom: '30px', 
            padding: '20px', 
            border: '1px solid #ddd', 
            borderRadius: '8px',
            backgroundColor: '#f9f9f9',
            cursor: 'pointer',
            transition: 'background-color 0.2s, transform 0.1s',
          }}
          onMouseEnter={(e) => {
            e.currentTarget.style.backgroundColor = '#e9e9e9';
            e.currentTarget.style.transform = 'translateY(-2px)';
          }}
          onMouseLeave={(e) => {
            e.currentTarget.style.backgroundColor = '#f9f9f9';
            e.currentTarget.style.transform = 'translateY(0)';
          }}>
          <h3>{aktor.name}</h3>
          
          <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '20px' }}>
            <div>
              <h4>Contact Information</h4>
              <p><strong>Email:</strong> {aktor.emailAddress}</p>
              <p><strong>Phone:</strong> {aktor.telephone}</p>
              <p><strong>Website:</strong> <a href={aktor.websiteUrl} target="_blank" rel="noopener noreferrer">{aktor.websiteUrl}</a></p>
              <p><strong>Main Contact:</strong> {aktor.mainContact}</p>
            </div>
            
            <div>
              <h4>Organization Details</h4>
              <p><strong>Organization Number:</strong> {aktor.organizationNumber}</p>
              <p><strong>Industry:</strong> {aktor.industry}</p>
              <p><strong>Industry Code:</strong> {aktor.industryCode}</p>
              <p><strong>Founded:</strong> {new Date(aktor.dateOfFoundation).toLocaleDateString()}</p>
            </div>
          </div>
          
          <div style={{ marginTop: '20px' }}>
            <h4>Cluster Information</h4>
            <p><strong>Purpose:</strong> {aktor.clusterPurpose}</p>
            <p><strong>Vision:</strong> {aktor.clusterVision}</p>
            <p><strong>Description:</strong> {aktor.clusterDescription}</p>
            <p><strong>Services:</strong> {aktor.services}</p>
          </div>
        </section>
      ))}
    </div>
  );
};

export default Aktorer;