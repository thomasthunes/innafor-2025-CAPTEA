import React, { useState } from 'react';

interface Message {
  id: string;
  content: string;
  senderId: string;
  receiverId: string;
  timestamp: string;
}

interface MessagesSentToProps {
  currentUser: string;
}

const MessagesSentTo: React.FC<MessagesSentToProps> = ({ currentUser }) => {
  const [messages, setMessages] = useState<Message[]>([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState('');

  const fetchMessagesSentTo = async () => {
    if (!currentUser) return;
    
    setLoading(true);
    setError('');
    try {
      const response = await fetch(`http://localhost:5164/api/message/to/${currentUser}`);
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
      <h3>Messages Sent To ID</h3>
      <div>
        <button onClick={fetchMessagesSentTo} disabled={loading}>
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
              <p>From: {message.senderId}</p>
              <p>Time: {message.timestamp}</p>
            </div>
          ))}
        </div>
      )}
    </div>
  );
};

export default MessagesSentTo;