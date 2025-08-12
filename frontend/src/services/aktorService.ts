export interface AktorDetail {
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

class AktorService {
  private baseUrl = 'http://localhost:5164/api';

  async fetchAktorById(id: string): Promise<AktorDetail> {
    const response = await fetch(`${this.baseUrl}/Cluster/${id}`, {
      headers: {
        'accept': 'application/json'
      }
    });

    if (!response.ok) {
      throw new Error(`HTTP error! status: ${response.status}`);
    }

    return response.json();
  }

  async fetchAllAktorer(): Promise<AktorDetail[]> {
    const response = await fetch(`${this.baseUrl}/Cluster`, {
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

export const aktorService = new AktorService();