import React, { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { aktorService, AktorDetail as AktorDetailType } from '../services/aktorService';
import { clusterUserService, ClusterUser } from '../services/clusterUserService';

const AktorDetail: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  const navigate = useNavigate();
  const [aktor, setAktor] = useState<AktorDetailType | null>(null);
  const [clusterUsers, setClusterUsers] = useState<ClusterUser[]>([]);
  const [loading, setLoading] = useState(true);
  const [clusterUsersLoading, setClusterUsersLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);
  const [clusterUsersError, setClusterUsersError] = useState<string | null>(null);

  useEffect(() => {
    const fetchAktorDetail = async () => {
      if (!id) {
        setError('No Aktor ID provided');
        setLoading(false);
        return;
      }

      try {
        setLoading(true);
        const data = await aktorService.fetchAktorById(id);
        setAktor(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };

    fetchAktorDetail();
  }, [id]);

  useEffect(() => {
    const fetchClusterUsers = async () => {
      if (!id) return;

      try {
        setClusterUsersLoading(true);
        setClusterUsersError(null);
        const users = await clusterUserService.fetchClusterUsers(id);
        setClusterUsers(users);
      } catch (err) {
        setClusterUsersError(err instanceof Error ? err.message : 'Failed to load cluster users');
      } finally {
        setClusterUsersLoading(false);
      }
    };

    fetchClusterUsers();
  }, [id]);

  if (loading) {
    return (
      <div style={{ padding: '20px' }}>
        <button onClick={() => navigate('/aktorer')} style={{ marginBottom: '20px' }}>
          ← Back to Aktører
        </button>
        <p>Loading aktor details...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div style={{ padding: '20px' }}>
        <button onClick={() => navigate('/aktorer')} style={{ marginBottom: '20px' }}>
          ← Back to Aktører
        </button>
        <p>Error loading aktor details: {error}</p>
      </div>
    );
  }

  if (!aktor) {
    return (
      <div style={{ padding: '20px' }}>
        <button onClick={() => navigate('/aktorer')} style={{ marginBottom: '20px' }}>
          ← Back to Aktører
        </button>
        <p>Aktor not found.</p>
      </div>
    );
  }

  return (
    <div style={{ padding: '20px', maxWidth: '1200px' }}>
      <button 
        onClick={() => navigate('/aktorer')} 
        style={{ 
          marginBottom: '20px',
          padding: '10px 15px',
          border: '1px solid #ddd',
          borderRadius: '4px',
          backgroundColor: '#f5f5f5',
          cursor: 'pointer'
        }}
      >
        ← Back to Aktører
      </button>
      
      <div style={{ 
        border: '1px solid #ddd', 
        borderRadius: '8px', 
        padding: '30px',
        backgroundColor: '#fff'
      }}>
        <h1 style={{ marginBottom: '30px', color: '#333' }}>{aktor.name}</h1>
        
        <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '40px', marginBottom: '30px' }}>
          <div>
            <h3 style={{ marginBottom: '15px', color: '#555' }}>Contact Information</h3>
            <div style={{ lineHeight: '1.6' }}>
              <p><strong>Email:</strong> 
                <a href={`mailto:${aktor.emailAddress}`} style={{ marginLeft: '8px' }}>
                  {aktor.emailAddress}
                </a>
              </p>
              <p><strong>Phone:</strong> 
                <a href={`tel:${aktor.telephone}`} style={{ marginLeft: '8px' }}>
                  {aktor.telephone}
                </a>
              </p>
              <p><strong>Website:</strong> 
                <a 
                  href={aktor.websiteUrl} 
                  target="_blank" 
                  rel="noopener noreferrer"
                  style={{ marginLeft: '8px' }}
                >
                  {aktor.websiteUrl}
                </a>
              </p>
              <p><strong>Main Contact:</strong> {aktor.mainContact}</p>
            </div>
          </div>
          
          <div>
            <h3 style={{ marginBottom: '15px', color: '#555' }}>Organization Details</h3>
            <div style={{ lineHeight: '1.6' }}>
              <p><strong>Organization Number:</strong> {aktor.organizationNumber}</p>
              <p><strong>Industry:</strong> {aktor.industry}</p>
              <p><strong>Industry Code:</strong> {aktor.industryCode}</p>
              <p><strong>Founded:</strong> {new Date(aktor.dateOfFoundation).toLocaleDateString()}</p>
            </div>
          </div>
        </div>
        
        <div>
          <h3 style={{ marginBottom: '15px', color: '#555' }}>Cluster Information</h3>
          <div style={{ lineHeight: '1.8' }}>
            <div style={{ marginBottom: '15px' }}>
              <p><strong>Purpose:</strong></p>
              <p style={{ marginLeft: '20px', color: '#666' }}>{aktor.clusterPurpose}</p>
            </div>
            <div style={{ marginBottom: '15px' }}>
              <p><strong>Vision:</strong></p>
              <p style={{ marginLeft: '20px', color: '#666' }}>{aktor.clusterVision}</p>
            </div>
            <div style={{ marginBottom: '15px' }}>
              <p><strong>Description:</strong></p>
              <p style={{ marginLeft: '20px', color: '#666' }}>{aktor.clusterDescription}</p>
            </div>
            <div>
              <p><strong>Services:</strong></p>
              <p style={{ marginLeft: '20px', color: '#666' }}>{aktor.services}</p>
            </div>
          </div>
        </div>
        
        <div style={{ marginTop: '30px' }}>
          <h3 style={{ marginBottom: '15px', color: '#555' }}>Cluster Users</h3>
          {clusterUsersLoading && (
            <p style={{ color: '#666' }}>Loading cluster users...</p>
          )}
          {clusterUsersError && (
            <p style={{ color: '#d32f2f' }}>Error loading cluster users: {clusterUsersError}</p>
          )}
          {!clusterUsersLoading && !clusterUsersError && clusterUsers.length === 0 && (
            <p style={{ color: '#666' }}>No cluster users found.</p>
          )}
          {!clusterUsersLoading && !clusterUsersError && clusterUsers.length > 0 && (
            <div style={{ display: 'grid', gap: '15px' }}>
              {clusterUsers.map((user) => (
                <div 
                  key={user.id} 
                  style={{ 
                    border: '1px solid #e0e0e0', 
                    borderRadius: '6px', 
                    padding: '20px',
                    backgroundColor: '#f9f9f9'
                  }}
                >
                  <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '20px' }}>
                    <div>
                      <h4 style={{ marginBottom: '10px', color: '#333' }}>
                        {user.firstName} {user.lastName}
                      </h4>
                      <p><strong>Phone:</strong> {user.phone}</p>
                      <p><strong>Address:</strong> {user.address}</p>
                      <p><strong>Responsibilities:</strong> {user.responsibilities}</p>
                    </div>
                    <div>
                      <h5 style={{ marginBottom: '10px', color: '#555' }}>Cluster Information</h5>
                      <p><strong>ID:</strong> {user.cluster.id}</p>
                      <p><strong>Phone:</strong> {user.cluster.telephone}</p>
                      <p><strong>Website:</strong> 
                        <a 
                          href={user.cluster.websiteUrl} 
                          target="_blank" 
                          rel="noopener noreferrer"
                          style={{ marginLeft: '8px' }}
                        >
                          {user.cluster.websiteUrl}
                        </a>
                      </p>
                      <p><strong>Organization Number:</strong> {user.cluster.organizationNumber}</p>
                      <p><strong>Industry Code:</strong> {user.cluster.industryCode}</p>
                    </div>
                  </div>
                </div>
              ))}
            </div>
          )}
        </div>
      </div>
    </div>
  );
};

export default AktorDetail;