export interface ClusterUser {
  id: string;
  cluster: {
    id: string;
    telephone: string;
    websiteUrl: string;
    organizationNumber: string;
    industryCode: string;
    clusterDescription: string;
    services: string;
  };
  address: string;
  firstName: string;
  lastName: string;
  phone: string;
  responsibilities: string;
}

class ClusterUserService {
  private baseUrl = 'http://localhost:5164/api';

  async fetchClusterUsers(clusterId: string): Promise<ClusterUser[]> {
    const response = await fetch(`${this.baseUrl}/ClusterUser/cluster/${clusterId}`, {
      headers: {
        'accept': 'application/json'
      }
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response.json();
  }
}

export const clusterUserService = new ClusterUserService();