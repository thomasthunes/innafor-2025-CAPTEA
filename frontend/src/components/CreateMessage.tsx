import React, { useState } from 'react';

interface MessageData {
  // id: string;
  content: string;
  from: string;
  to: string;
  about: string;
  // timestamp: string;
}

interface CreateMessageProps {
  currentUser: string;
}

const CreateMessage: React.FC<CreateMessageProps> = ({ currentUser }) => {
  const [messageData, setMessageData] = useState<MessageData>({
    content: '',
    from: currentUser,
    to: '',
    about: ''
  });
  const [loading, setLoading] = useState(false);
  const [success, setSuccess] = useState('');
  const [error, setError] = useState('');

  const handleInputChange = (e: React.ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) => {
    const { name, value } = e.target;
    setMessageData(prev => ({
      ...prev,
      [name]: value
    }));
  };

  const createMessage = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!messageData.content || !messageData.content || !messageData.to) return;
    
    setLoading(true);
    setError('');
    setSuccess('');
    try {
        console.log(messageData);
        const response = await fetch('http://localhost:5164/api/message/send', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(messageData)
      });
      

      if (response.status !== 200) {
          const errorData = await response.json();
          console.error('Error creating message:', errorData);
          // console.log('Response status:', response.status);
          throw new Error('Failed to create message');
      }
      setSuccess(`Message created successfully`);
      setMessageData({ content: '', from: currentUser, to: '', about:'' });
    } catch (err) {
        console.log(err)
      setError(err instanceof Error ? err.message : 'Failed to create message');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Create New Message</h3>
      <form onSubmit={createMessage}>
        <div>
          <input
            type="text"
            name="to"
            placeholder="Receiver ID"
            value={messageData.to}
            onChange={handleInputChange}
            required
          />
        </div>
        <div>
          <input
            type="text"
            name="about"
            placeholder="What is this message about?"
            value={messageData.about}
            onChange={handleInputChange}
            required
          />
        </div>
        <div>
          <textarea
            name="content"
            placeholder="Message content"
            value={messageData.content}
            onChange={handleInputChange}
            rows={4}
            required
          />
        </div>
        <button type="submit" disabled={loading}>
          {loading ? 'Creating...' : 'Create Message'}
        </button>
      </form>
      {error && <p style={{color: 'red'}}>{error}</p>}
      {success && <p style={{color: 'green'}}>{success}</p>}
    </div>
  );
};

export default CreateMessage;