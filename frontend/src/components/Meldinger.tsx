import React from 'react';
import MessageById from './MessageById';
import MessagesSentTo from './MessagesSentTo';
import MessagesFromId from './MessagesFromId';
import CreateMessage from './CreateMessage';

interface MeldingerProps {
  currentUser: string;
}

const Meldinger: React.FC<MeldingerProps> = ({ currentUser }) => {
    console.log('Meldinger component rendered with currentUser:', currentUser);
  return (
    <div>
      <h2>Meldinger</h2>
      {currentUser}
      <div style={{ display: 'grid', gridTemplateColumns: '1fr 1fr', gap: '20px' }}>
        <MessageById />
        <MessagesSentTo currentUser={currentUser} />
        <MessagesFromId />
        <CreateMessage currentUser={currentUser}/>
      </div>
    </div>
  );
};

export default Meldinger;