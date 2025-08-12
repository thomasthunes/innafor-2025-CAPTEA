import React, { useState, useEffect } from 'react';
import axios from 'axios';

interface Opportunity {
  cluster: string | null;
  id: string;
  title: string;
  description: string;
  isClosed: boolean;
  customerName: string;
  submittedOn: string;
  lastChangedOn: string;
  assignedTo: string | null;
}

const Muligheter: React.FC = () => {
  const [opportunities, setOpportunities] = useState<Opportunity[]>([]);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchOpportunities = async () => {
      try {
        setLoading(true);
        const response = await axios.get('http://localhost:5164/api/OneWayInOpportunities/all');
        setOpportunities(response.data);
        setError(null);
      } catch (err) {
        setError('Feil ved henting av muligheter');
        console.error('Error fetching opportunities:', err);
      } finally {
        setLoading(false);
      }
    };

    fetchOpportunities();
  }, []);

  if (loading) {
    return (
      <div className="opportunities-container">
        <h2>Muligheter</h2>
        <p>Laster muligheter...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div className="opportunities-container">
        <h2>Muligheter</h2>
        <p>Feil: {error}</p>
      </div>
    );
  }

  return (
    <div className="opportunities-container">
      <h2>Muligheter</h2>
      <div className="opportunities-list">
        {opportunities.map((opportunity) => (
          <div key={opportunity.id} className="opportunity-card">
            <h3>{opportunity.title}</h3>
            <p className="description">{opportunity.description}</p>
            <div className="opportunity-meta">
              <p><strong>Kunde:</strong> {opportunity.customerName}</p>
              <p><strong>Innsendt:</strong> {new Date(opportunity.submittedOn).toLocaleDateString('no-NO')}</p>
              <p><strong>Status:</strong> {opportunity.isClosed ? 'Lukket' : 'Åpen'}</p>
            </div>
          </div>
        ))}
      </div>
    </div>
  );
};

export default Muligheter;