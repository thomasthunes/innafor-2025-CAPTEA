import React, { useState, useEffect } from 'react';

interface Message {
  content: string;
  from: string;
  to: string;
  timestamp: string;
}

const MessageById: React.FC = () => {
  const [messageId, setMessageId] = useState('');
  const [message, setMessage] = useState<Message | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const fetchMessageById = async () => {
    if (!messageId) return;
    
    setLoading(true);
    setError('');
    try {
      const response = await fetch(`http://localhost:5164/api/message/${messageId}`);
      if (!response.ok) throw new Error('Message not found');
      const data = await response.json();
      setMessage(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to fetch message');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Get Message by ID</h3>
      <div>
        <input
          type="text"
          placeholder="Enter message ID"
          value={messageId}
          onChange={(e) => setMessageId(e.target.value)}
        />
        <button onClick={fetchMessageById} disabled={!messageId || loading}>
          {loading ? 'Loading...' : 'Get Message'}
        </button>
      </div>
      {error && <p style={{color: 'red'}}>{error}</p>}
      {message && (
        <div>
          <h4>Message Details:</h4>
          <p>Content: {message.content}</p>
          <p>From: {message.from}</p>
          <p>To: {message.to}</p>
          <p>Time: {message.timestamp}</p>
        </div>
      )}
    </div>
  );
};

export default MessageById;