import React, { useEffect, useState } from 'react';

interface Cluster {
  id: string;
  name: string;
  emailAddress: string;
  telephone: string;
  websiteUrl: string;
  organizationNumber: string;
  industryCode: string;
  clusterPurpose: string;
  clusterVision: string;
  dateOfFoundation: string;
  mainContact: string;
}

interface BrukerData {
  id: string;
  cluster: Cluster;
  emailAddress: string;
  firstName: string;
  lastName: string;
  phone: string;
  responsibilities: string;
}

interface BrukerProps {
  uuid: string;
}

const Bruker: React.FC<BrukerProps> = ({ uuid }) => {
  const [brukerData, setBrukerData] = useState<BrukerData | null>(null);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    const fetchBrukerData = async () => {
      try {
        setLoading(true);
        const response = await fetch(`http://localhost:5164/api/ClusterUser/${uuid}`, {
          headers: {
            'accept': 'application/json'
          }
        });
        
        if (!response.ok) {
          throw new Error(`HTTP error! status: ${response.status}`);
        }
        
        const data = await response.json();
        setBrukerData(data);
      } catch (err) {
        setError(err instanceof Error ? err.message : 'An error occurred');
      } finally {
        setLoading(false);
      }
    };

    if (uuid) {
      fetchBrukerData();
    }
  }, [uuid]);

  if (loading) {
    return (
      <div>
        <h2>Bruker</h2>
        <p>Loading your profile information...</p>
      </div>
    );
  }

  if (error) {
    return (
      <div>
        <h2>Bruker</h2>
        <p>Error loading profile: {error}</p>
      </div>
    );
  }

  if (!brukerData) {
    return (
      <div>
        <h2>Bruker</h2>
        <p>No profile information found.</p>
      </div>
    );
  }

  return (
    <div>
      <h2>Bruker Profile</h2>
      
      <section>
        <h3>Personal Information</h3>
        <p><strong>Name:</strong> {brukerData.firstName} {brukerData.lastName}</p>
        <p><strong>Email:</strong> {brukerData.emailAddress}</p>
        <p><strong>Phone:</strong> {brukerData.phone}</p>
        <p><strong>Responsibilities:</strong> {brukerData.responsibilities}</p>
      </section>

      {brukerData.cluster && (
        <section>
          <h3>Cluster Information</h3>
          <p><strong>Cluster Name:</strong> {brukerData.cluster.name}</p>
          <p><strong>Email:</strong> {brukerData.cluster.emailAddress}</p>
          <p><strong>Phone:</strong> {brukerData.cluster.telephone}</p>
          <p><strong>Website:</strong> <a href={brukerData.cluster.websiteUrl} target="_blank" rel="noopener noreferrer">{brukerData.cluster.websiteUrl}</a></p>
          <p><strong>Organization Number:</strong> {brukerData.cluster.organizationNumber}</p>
          <p><strong>Industry Code:</strong> {brukerData.cluster.industryCode}</p>
          <p><strong>Purpose:</strong> {brukerData.cluster.clusterPurpose}</p>
          <p><strong>Vision:</strong> {brukerData.cluster.clusterVision}</p>
          <p><strong>Founded:</strong> {new Date(brukerData.cluster.dateOfFoundation).toLocaleDateString()}</p>
          <p><strong>Main Contact:</strong> {brukerData.cluster.mainContact}</p>
        </section>
      )}
    </div>
  );
};

export default Bruker;