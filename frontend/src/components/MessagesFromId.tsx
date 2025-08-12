import React, { useState } from 'react';

interface Message {
  id: string;
  content: string;
  senderId: string;
  receiverId: string;
  timestamp: string;
}

const MessagesFromId: React.FC = () => {
  const [senderId, setSenderId] = useState('');
  const [messages, setMessages] = useState<Message[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const fetchMessagesFromId = async () => {
    if (!senderId) return;
    
    setLoading(true);
    setError('');
    try {
      const response = await fetch(`http://localhost:5164/api/message/from/${senderId}`);
      if (!response.ok) throw new Error('Failed to fetch messages');
      const data = await response.json();
      setMessages(data);
    } catch (err) {
      setError(err instanceof Error ? err.message : 'Failed to fetch messages');
    } finally {
      setLoading(false);
    }
  };

  return (
    <div>
      <h3>Messages From ID</h3>
      <div>
        <input
          type="text"
          placeholder="Enter sender ID"
          value={senderId}
          onChange={(e) => setSenderId(e.target.value)}
        />
        <button onClick={fetchMessagesFromId} disabled={!senderId || loading}>
          {loading ? 'Loading...' : 'Get Messages'}
        </button>
      </div>
      {error && <p style={{color: 'red'}}>{error}</p>}
      {messages.length > 0 && (
        <div>
          <h4>Messages ({messages.length}):</h4>
          {messages.map((message) => (
            <div key={message.id} style={{border: '1px solid #ccc', margin: '5px', padding: '10px'}}>
              <p>ID: {message.id}</p>
              <p>Content: {message.content}</p>
              <p>To: {message.receiverId}</p>
              <p>Time: {message.timestamp}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default MessagesFromId;